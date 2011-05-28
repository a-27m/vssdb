using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroGenes.Genetic;
using NeuroGenes;
using System.Diagnostics;

namespace NeuroGenes
{
    public class CharRecognSpecies : BaseDoubleSpecies<CharRecognSpecies>
    {
        private CharRecognizerNetwork charNetwork;
        private CookedSamples samples;
        private int samplesToPass;

        public CharRecognSpecies(CookedSamples cooked, int netInputs, params int[] neuronCounts)
        {
            charNetwork = new CharRecognizerNetwork();
            charNetwork.AllocateNetwork(false, netInputs, neuronCounts);
            
            charNetwork.SetWeights(WeightsFromChromosomes(), );
            charNetwork = net;
            samples = cooked;
            samplesToPass = cooked.Length;
        }

        new private Interval[] Intervals {get}

        public static int IntervalsNeeded(
        { get { return } }

        private double[][][] WeightsFromChromosomes()
        {
            return (double[][][])m_Chromosomes;
        }


        protected override double CalcFinalFunc()
        {
            double[] smpOutput, smpInput;
            double netError = 0;

            for (int i = 0; i < samplesToPass; i++)
            {
                samples.GetRandomSample(out smpInput, out smpOutput);

                double[] netOutput = charNetwork.FeedForward(smpInput);
                netError += CharRecognizerNetwork.CalculateError(smpOutput, netOutput);
            }

            // TODO try 1/netError
            return -netError;
        }
    }
}
