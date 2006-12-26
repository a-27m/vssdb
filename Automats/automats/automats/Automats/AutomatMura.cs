using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace automats
{
    public class AutomatMura : TerminalAutomat
    {
        protected int[] TOuts;
        protected int[,] TStates;

        public AutomatMura(object[] A, object[] Z, object[] S,
            int[,] nju, int[] zeta)
            : base(A, Z, S)
        {
            TStates = (int[,])nju.Clone();
            TOuts = (int[])zeta.Clone();

            CheckAutomatConsistency();
        }

        public override StepResult ProcessOne(
            int indexA,
            out int new_state,
            out int output)
        {
            StateIndex = TStates[StateIndex, indexA];
            output = TOuts[StateIndex];
            new_state = StateIndex;
            return StepResult.Success;
        }

        public override void Reset()
        {
            StateIndex = 0;
        }

        protected void CheckTables()
        {
            if ((TStates.GetLength(0) != S.Length) ||
                (TStates.GetLength(1) != A.Length))
                throw new AutomatException("Wrong nju table size!");
            if (TOuts.Length != S.Length)
                throw new AutomatException("Wrong zeta table size!");
        }

        protected void CheckIndices()
        {
            for (int i = 0; i < S.Length; i++)
            {
                if ((TOuts[i] < 0) && (TOuts[i] >= Z.Length))
                    throw new AutomatException("Wrong out-symbol index!");

                for (int j = 0; j < A.Length; j++)
                {
                    if ((TStates[i, j] < 0) && (TStates[i, j] >= S.Length))
                        throw new AutomatException("Wrong state index!");
                }
            }
        }

        /// <summary>validating tables</summary>
        protected override void CheckAutomatConsistency()
        {
            CheckTables();
            CheckIndices();
        }

        protected override bool EqOuts(int i1, int i2)
        {
            return TOuts[i1] == TOuts[i2];
        }

        protected override TerminalAutomat BuildAutomatFromPiClasses(List<List<int>> classes)
        {
            #region  copy new states

            int[,] NewTStates = new int[classes.Count, A.Length];
            int[] NewTOuts = new int[classes.Count];
            int currentPiClassIndex = 0;

            foreach (List<int> PiClass in classes)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    NewTStates[currentPiClassIndex, j] = TStates[PiClass[0], j];
                }
                NewTOuts[currentPiClassIndex] = TOuts[PiClass[0]];
                currentPiClassIndex++;
            }
            #endregion

            #region Replacement of equal states

            int ci;
            for (int i = 0; i < NewTStates.GetLength(0); i++)
                for (int j = 0; j < NewTStates.GetLength(1); j++)
                {
                    for (ci = 0; ci < classes.Count; ci++)
                        foreach (int cs in classes[ci])
                            if (cs == NewTStates[i, j])
                                goto found;
                found:
                    NewTStates[i, j] = ci;
                }

            #endregion

            object[] NewS = new object[classes.Count];
            for (int i = 0; i < NewS.Length; i++)
                NewS[i] = S[i];

            return new AutomatMura(A, Z, NewS, NewTStates, NewTOuts);
        }

        public override void PrintAutomat(object o)
        {
            DataGridView grid = (DataGridView)o;
            grid.Rows.Clear();
            grid.Columns.Clear();
            for (int i = 0; i < A.Length; i++)
                grid.Columns.Add("column" + i.ToString(), A[i].ToString());

            grid.Columns.Add("column" + A.Length.ToString(), "—");

            grid.Rows.Add(S.Length);

            for (int i = 0; i < S.Length; i++)
                grid.Rows[i].HeaderCell.Value = S[i].ToString();

            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                    grid.Rows[i].Cells[j].Value = S[TStates[i, j]].ToString();

                grid.Rows[i].Cells[A.Length].Value = Z[TOuts[i]].ToString();
            }
            grid.AutoResizeColumns();
            grid.AutoResizeRows();
        }
    }
}
