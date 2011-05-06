using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroGenes.Genetic;

namespace NeuroGenes
{
    internal class CharRecognSpecies : BaseDoubleSpecies<CharRecognSpecies>, CharRecogizerNetwork
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
