using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace automats
{
    /// <summary>
    /// This class represents a non-initial Mili's automat
    /// </summary>
    public class AutomatMili : TerminalAutomat
    {
        int[,] TStates, TOuts;

        public AutomatMili(object[] A, object[] Z, object[] S, int[,] nju, int[,] zeta)
            : base(A, Z, S)
        {
            if ((nju.GetLength(0) != S.Length) ||
                (nju.GetLength(1) != A.Length))
                throw new AutomatException("Wrong nju table size!");
            if ((zeta.GetLength(0) != S.Length) ||
                (zeta.GetLength(1) != A.Length))
                throw new AutomatException("Wrong zeta table size!");

            TStates = (int[,])nju.Clone();
            TOuts = (int[,])zeta.Clone();

            CheckAutomatConsistency();
        }

        public override StepResult ProcessOne(int inIndex,
            out int new_state, out int output)
        {
            int state = StateIndex;

            new_state = TStates[state, inIndex];
            output = TOuts[state, inIndex];
            StateIndex = new_state;

            return StepResult.Success;
        }

        public override void PrintAutomat(object o)
        {
            DataGridView grid = (DataGridView)o;
            grid.Rows.Clear();
            grid.Columns.Clear();
            for (int i = 0; i < A.Length; i++)
                grid.Columns.Add("column" + i.ToString(), A[i].ToString());

            for (int i = 0; i < A.Length; i++)
                grid.Columns.Add("column" + (i + A.Length).ToString(), A[i].ToString());

            grid.Rows.Add(S.Length);

            for (int i = 0; i < S.Length; i++)
                grid.Rows[i].HeaderCell.Value = S[i].ToString();

            for (int i = 0; i < S.Length; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    grid.Rows[i].Cells[j].Value = S[TStates[i, j]].ToString();
                    grid.Rows[i].Cells[j + A.Length].Value = Z[TOuts[i, j]].ToString();
                }
            grid.AutoResizeColumns();
            grid.AutoResizeRows();
        }

        /// <summary>validating tables</summary>
        protected override void CheckAutomatConsistency()
        {
            for (int i = 0; i < S.Length; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    if ((TStates[i, j] < 0) && (TStates[i, j] >= S.Length))
                        throw new AutomatException("Wrong state index!");
                    if ((TOuts[i, j] < 0) && (TOuts[i, j] >= Z.Length))
                        throw new AutomatException("Wrong out-symbol index!");
                }
        }

        public override void Reset()
        {
            StateIndex = 0;
        }

        protected override bool EqOuts(int i1, int i2)
        {
            for (int j = 0; j < A.Length; j++)
            {
                if (TOuts[i1, j] != TOuts[i2, j])
                    return false;
            }
            return true;
        }

        protected override TerminalAutomat GetAutomatFromPiClasses(List<List<int>> classes)
        {
            #region  copy new states

            int[,] NewTStates = new int[classes.Count, A.Length];
            int[,] NewTOuts = new int[classes.Count, A.Length];
            int currentPiClassIndex = 0;

            foreach (List<int> PiClass in classes)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    NewTStates[currentPiClassIndex, j] = TStates[PiClass[0], j];
                    NewTOuts[currentPiClassIndex, j] = TOuts[PiClass[0], j];
                }
                currentPiClassIndex++;
            }
            #endregion

            #region replacement of equal states

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

            return new AutomatMili(A, Z, NewS, NewTStates, NewTOuts);
        }
    }
}

            //int PiClassNumber = 0;
            //foreach (List<int> PiClass in classes)
            //{
            //    int replaceTo = PiClassNumber++;
            //    while (PiClass.Count > 0)
            //    {
            //        int findWhat = PiClass[0];

            //        // Look througth table TStates
            //        for (int i = 0; i < classes.Count; i++)
            //            for (int j = 0; j < A.Length; j++)
            //                if (NewTStates[i, j] == findWhat)
            //                    NewTStates[i, j] = replaceTo;

            //        PiClass.RemoveAt(0);
            //    }
            //}            //int PiClassNumber = 0;
