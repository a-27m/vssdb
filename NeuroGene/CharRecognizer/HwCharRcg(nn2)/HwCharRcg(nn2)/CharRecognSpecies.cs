using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroGenes.Genetic;
using NeuroGenes;

namespace NeuroGenes
{
    internal class CharRecognSpecies : BaseDoubleSpecies<CharRecognSpecies>, CharRecognizerNetwork
    {

        public CharRecognSpecies()
            : base()
        { }
        
        protected override double CalcFinalFunc()
        {
            
            throw new NotImplementedException();
        }
    }
}
