using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NeuroNetwork;

namespace NeuroGenes
{
    public class CharRecognizerNetwork : NeuroNetwork.BaseNeuroNetwork
    {
        double[][][] w;
        double[][] x;
        double[][] s, d;

        public double bias = 0.1;
        private double eps = 1e-2;

        public double Eps
        {
            get { return eps; }
            set { eps = value; }
        }
        int maxEpoch = (int)1e4;

        public int MaxEpoch
        {
            get { return maxEpoch; }
            set { maxEpoch = value; }
        }
        public double const_a = 5e-3;
        public double const_Eta = 2e-1;

        static Random rnd = new Random();

        public double F(double s)
        {
            return Math.Tanh(const_a * s);
            //return ((2/(1+Math.Exp(-1*const_a*s)))-1); // Bipolar
        }
        public double dF(double s)
        {
            double tanh = Math.Tanh(const_a * s);
            return 1 - tanh * tanh;
            //return const_a*(1-Math.Pow(F(s),2));

            //return 0.5 * (1 - Math.Pow(s, 2)); // Bipolar
        }

        public void AllocateNetwork(bool allocateWeights, int inputs, params int[] NeuronCounts)
        {
            int layersCount = NeuronCounts.Length;           

            if (allocateWeights) w = new double[layersCount][][];
            s = new double[layersCount][];
            d = new double[layersCount][];
            x = new double[1 + layersCount][];

            x[0] = new double[inputs+1];//+bias

            int prevLayerNeurons = inputs;

            for (int L = 0; L < layersCount; L++)
            {
                int neuronsInLayer = NeuronCounts[L];

                if (allocateWeights)
                {
                    w[L] = new double[neuronsInLayer][];
                    for (int i = 0; i < neuronsInLayer; i++)
                        w[L][i] = new double[prevLayerNeurons + 1]; // perv layer outs, +1 for bias
                }

                s[L] = new double[neuronsInLayer];
                d[L] = new double[neuronsInLayer];

                if (L == layersCount - 1)
                    x[L + 1] = new double[neuronsInLayer]; // no bias
                else
                    x[L + 1] = new double[neuronsInLayer + 1]; // +1 for bias

                prevLayerNeurons = neuronsInLayer;
            }
        }

        public void SetWeights(double[][][] new_weights, bool doValidation)
        {
            if (!doValidation || ValidateDimensions(new_weights))
            {
                this.w = new_weights;
            }
            else 
                throw new ArgumentException();
        }

        public bool ValidateDimensions(double[][][] m)
        {
            if (w.GetLength(0) != m.GetLength(0)) return false;
            for (int i = 0; i < w.GetLength(0); i++)
            {
                if (w[i].GetLength(0) != m[i].GetLength(0)) return false;
                for (int j = 0; j < w[i].GetLength(0); j++)
                {
                    if (w[i][j].GetLength(0) != m[i][j].GetLength(0)) return false;
                }
            }
            return true;
        }

        public void FillSmallRandom(double smallNumber)
        {
            for (int i = 0; i < w.GetLength(0); i++)
                for (int j = 0; j < w[i].GetLength(0); j++)
                    for (int k = 0; k < w[i][j].GetLength(0); k++)
                        w[i][j][k] = smallNumber * (rnd.NextDouble() * 2.0 - 1.0);
        }

        public double[] FeedForward(double[] x_inp)
        {
            Debug.Assert(x[0].Length == x_inp.Length + 1);

            x[0][0] = bias;
            for (int i = 0; i < x_inp.Length; i++)
            {
                x[0][i + 1] = x_inp[i];
            }

            Debug.Assert(w.Length + 1 == x.Length);

            for (int lay = 0; lay < w.Length - 1; lay++)
            {
                x[lay + 1][0] = bias;
                for (int neu = 0; neu < w[lay].Length; neu++)
                {
                    s[lay][neu] = MatrixArithmetics.Sum(MatrixArithmetics.PairMult(x[lay], w[lay][neu]));
                    x[lay + 1][neu + 1] = F(s[lay][neu]);
                }
            }

            // the last layer has no bias in outputs
            int last = w.Length - 1;
            {
                for (int neu = 0; neu < w[last].Length; neu++)
                {
                    s[last][neu] = MatrixArithmetics.Sum(MatrixArithmetics.PairMult(x[last], w[last][neu]));
                    x[last + 1][neu] = F(s[last][neu]);
                }
            }

            return x[x.Length - 1];
        }

        public void Train(double[][] xCookedSamples, double[][] yCookedSamples)
        {
            int outputs = w[w.Length - 1].Length;

            //Debug.Assert(outputs == chars.Length);

            int P = xCookedSamples.GetLength(0);
            
            double netError;
            int epoch = 0;
            // ready to start
            do
            {
                double localEta = const_Eta;
                netError = 0;
                // passing all samples
                for (int p = 0; p < P; p++)
                {
                    double[] y = FeedForward(xCookedSamples[p]);

                    double[] D = MatrixArithmetics.Minus(y, yCookedSamples[p]);

                    netError += MatrixArithmetics.Sum(MatrixArithmetics.PairMult(D, D));

                    // do the last layer
                    int last = w.Length - 1;
                    for (int j = 0; j < outputs; j++)
                        d[last][j] = D[j] * dF(s[last][j]);

                    // do inner layers
                    for (int lay = last - 1; lay >= 0; lay--)
                    {
                        for (int j = 0; j < d[lay].Length; j++)
                        {
                            double sum_dw = 0;
                            for (int k = 0; k < d[lay + 1].Length; k++)
                                sum_dw += d[lay + 1][k] * w[lay + 1][k][j];

                            // d = dF(s) * Sum(d * w)
                            d[lay][j] = dF(s[lay][j]) * sum_dw;
                        }
                    }

                    for (int lay = 0; lay < w.Length; lay++)
                    {
                        for (int neu = 0; neu < w[lay].Length; neu++)
                        {
                            for (int i = 0; i < w[lay][neu].Length; i++)
                                w[lay][neu][i] -= localEta * d[lay][neu] * x[lay][i];
                        }
                    }
                }
                epoch++;
                //if (backgroundWorkerTrain.CancellationPending)
                //    goto stopTrain;
                //if (epoch % 5 == 0)
                //{
                //    backgroundWorkerTrain.ReportProgress(epoch);
                //    reportEpoc = epoch;
                //    reportError = netError;
                //}
            }
            while (Math.Abs(netError) > eps && epoch < maxEpoch);
            
            //stopTrain:
            //reportEpoc = epoch;
            //reportError = netError;
            //Debug.Print("Trainig finished with Error: {0}, at epoch #{1}", netError, epoch);
        }

        public static double CalculateError(double[] etalonOut, double[] sampleOut)
        {
            double[] D = MatrixArithmetics.Minus(sampleOut, etalonOut);

            return MatrixArithmetics.Sum(MatrixArithmetics.PairMult(D, D));
         }

        double[] GetChromosomes()
        {
            // TODO cast w[][][] to result[] (TIME OPT)
            unsafe
            {
                return w[0][0];
            }
        }

        public CharRecognizerNetwork()
        {}
    }
}
