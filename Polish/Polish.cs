using System;
using System.Text;

using automats;

namespace Polish
{
    public class Polish
    {
        public delegate double DoubleFunction(double x);

        string prefix;

        //static protected DoubleFunction[] functions = new DoubleFunction[] {
        //    new DoubleFunction(Math.Sin),
        //    new DoubleFunction(Math.Cos),      
        //    new DoubleFunction(Math.Tan),      
        //    new DoubleFunction(Math.),      
        //    new DoubleFunction(Math),      
        //    new DoubleFunction(Math),      
        //    new DoubleFunction(Math),      
        //    new DoubleFunction(Math),      
        //    new DoubleFunction(Math),      
        //    new DoubleFunction(Math),};

        enum State
        {
            Initial,
        }


        public Polish(string infix)
        {
            double c;
            State currState;

            for (int i = 0; i < infix.Length; i++)
            {
                char s = infix[i];

                switch (currState)
                {
                    case State.Initial:

                        break;
                }
            }
        }
    }
}