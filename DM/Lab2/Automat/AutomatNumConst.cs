using System;
using System.Collections.Generic;
using automats;
using MyTypes;
using System.Diagnostics;

namespace Lab2
{
    public delegate void ActionOnLexem(Lexema lexema, ref int ��, ref int ��, ref int ��, ref int ��, out int new_state_index);

    class AutomatNumConst : AutomatMura
    {
        public int �� = 0, �� = 0, �� = 0, �� = 0;

        public AutomatNumConst(object[] A, object[] Z, object[] S, int[,] nju, int[] zeta)
            : base(A, Z, S, nju, zeta)
        {
        }

        public override StepResult ProcessOne(int indexA, out int new_state_index, out int output_index)
        {
            //output_index = TOuts[StateIndex];

            try
            {
                (S[TStates[StateIndex, indexA]] as ActionOnLexem)((CurrentInputSymbol as Lexema), ref ��, ref  ��, ref  ��, ref  ��, out  new_state_index);
            }
            catch (Exception)
            {
                new_state_index = StateIndex;
                output_index = TOuts[new_state_index];
                return StepResult.BadInput;
            }

            StateIndex = new_state_index;
            output_index = TOuts[new_state_index];
            return StepResult.Success;
        }

        protected override void CheckAutomatConsistency()
        {
            return;
        }
    }
}
