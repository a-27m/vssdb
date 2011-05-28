using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NeuroGenes
{
    public class CookedSamples
    {
        private int countSamples;
        private double[][] xCookedSamples;
        private double[][] yCookedSamples;
        private Random rnd = new Random();

        public CookedSamples(double[][] x, double[][] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            Debug.Assert(x.GetLength(0) == y.GetLength(0), "Size of inputs set does not match outputs set");

            xCookedSamples = x;
            yCookedSamples = y;

            countSamples = x.GetLength(0);
        }

        public CookedSamples(int count, int size)
        {
            xCookedSamples = new double[count][];
            yCookedSamples = new double[count][];

            for (int i = 0; i < count; i++)
            {
                xCookedSamples[i] = new double[size];
                yCookedSamples[i] = new double[size];
            }
        }

        public double[] GetInputs(int index)
        {
            return xCookedSamples[index];
        }
        public double[] GetOutputs(int index)
        {
            return yCookedSamples[index];
        }

        public void GetRandomSample(out double[] input, out double[] output)
        {
            int index = rnd.Next(countSamples);
            input = xCookedSamples[index];
            output = yCookedSamples[index];
        }

        public int Length {
            get { return countSamples; }
        }
    }
}
