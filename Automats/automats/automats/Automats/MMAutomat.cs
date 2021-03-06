using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace automats
{
    public enum MMAutomatActTypes
    {
        Hold,
        Shift,
        Push,
        Pop,
        Reject,
        Accept,
        Replace,
        SetState,
        Put,
    }

    public struct MMAutomatAct
    {
        public MMAutomatActTypes type;
        /// <summary>
        /// indexes of stack symbols
        /// </summary>
        public int[] args;

        public MMAutomatAct(MMAutomatActTypes ruleType, int[] Arguments)
        {
            type = ruleType;
            args = Arguments;
        }
    }

    public class MMAutomat : Automat
    {
        public static readonly string[] RulesNames = { "HOLD", "SHIFT", "PUSH", "POP", "REJECT", "ACCEPT", "REPLACE", "SETSTATE", "PUT"};

        int Переменная_Номер_Один_Которая_Указывает_Нам_На_Индекс_В_Алфавате_Последнего_Прочитанного_Символа = -1;
        List<int> translationIndexes = null;

        public string[] Translation
        {
            get
            {
                if (translationIndexes == null)
                    return new string[] { "" };
                if (translationIndexes.Count == 0)
                    return new string[] { "" };
                string[] result = new string[translationIndexes.Count];

                int i = 0;
                List<int>.Enumerator e;
                for (e = translationIndexes.GetEnumerator(); e.MoveNext(); )
                {
                    result[i++] = ((string)(M[e.Current])).Substring(1, ((string)M[e.Current]).Length - 2);
                }
                return result;
            }
        }

        public string TranslationString
        {
            get
            {
                string result = "";
                foreach (string str in Translation)
                    result += str+" ";
                return result;
            }
        }

        object[] m;
        int axiomaIndex;
        int bottomMarkIndex;
        internal int[][,] ManDevice;
        MMAutomatAct[][] rules;
        int di = 1;

        Stack<int> stk;

        public delegate bool MMStepDelegate(int inIndex, int newStateIndex, int outSymbolIndex, int[] stackState, int[] transIndex);
        public event MMStepDelegate Step;


        public int[] GetStackAsArray()
        {
            return stk.ToArray();
        }

        public object[] M
        {
            get
            {
                return m;
            }
            set
            {
                Set(value, ref m);
            }
        }

        private void Set(object[] value, ref object[] m)
        {
            m = (object[])(value.Clone());
        }

        public MMAutomat(object[] A, object[] Z, object[] S,
            object[] M, int[][,] MD, MMAutomatAct[][] Rules)
            : base(A, Z, S)
        {
            this.M = M;
            ManDevice = MD;
            this.rules = Rules;
            StateIndex = 0;
            stk = new Stack<int>();
            axiomaIndex = 0;
            bottomMarkIndex = M.Length - 1;
            stk.Push(bottomMarkIndex);
            stk.Push(axiomaIndex);

            CheckAutomatConsistency();
        }

        /// <summary>
        /// Does some set of actions called "rule"
        /// </summary>
        /// <param name="ruleNo">index of applying rule</param>
        /// <returns>Indicates weather processing is allowed to go on</returns>
        private bool Rule(int ruleNo, out int outed, out int[] transIndex)
        {
            bool res = true;
            outed = -1;
            transIndex = null;

            for (int i = 0; i < rules[ruleNo].Length; i++)
            {
                MMAutomatAct action = rules[ruleNo][i];
                switch (action.type)
                {
                    case MMAutomatActTypes.Hold:
                        di = 0;
                        break;
                    case MMAutomatActTypes.Shift:
                        di = 1;
                        break;
                    case MMAutomatActTypes.Push:
                        foreach (int el in action.args)
                            stk.Push(el);
                        break;
                    case MMAutomatActTypes.Pop:
                        if (stk.Peek() != bottomMarkIndex)
                            stk.Pop();
                        else
                        {
                            throw new AutomatException("There is an attempt to pop \"bottom\"");
                        }
                        break;
                    case MMAutomatActTypes.Reject:
                        outed = 0;
                        res = false;
                        break;
                    case MMAutomatActTypes.Accept:
                        outed = 1;
                        res = false;
                        break;
                    case MMAutomatActTypes.Replace:
                        if (stk.Peek() != bottomMarkIndex)
                            stk.Pop();
                        else
                        {
                            throw new AutomatException("There is an attempt to pop \"bottom\"");
                        }
                        foreach (int el in action.args)
                            stk.Push(el);
                        break;
                    case MMAutomatActTypes.SetState:
                        StateIndex = action.args[0];
                        break;
                    case MMAutomatActTypes.Put:
                        if (action.args[0] != -1)
                        {
                            transIndex = new int[action.args.Length];
                            Array.Copy(action.args, 0, transIndex, 0, action.args.Length);
                        }
                        else
                        {
                            transIndex = new int[1];
                            transIndex[0] = Переменная_Номер_Один_Которая_Указывает_Нам_На_Индекс_В_Алфавате_Последнего_Прочитанного_Символа;
                        }
                        break;
                }

            }
            return res;
        }

        public override void Reset()
        {
            stk.Clear();
            stk.Push(bottomMarkIndex);
            stk.Push(axiomaIndex);
            StateIndex = 0;
            di = 1;
        }

        public void Process(object[] input, out object[] states, out object[] output, out object[] finalStackState)
        {
            int outed = -1;
            states = null;//new object[queuedLength];
            output = null;//new object[queuedLength];
            translationIndexes = new List<int>();
            finalStackState = null;

            for (int i = 0; i < input.Length; i += di)
            {
                int indexA = Array.IndexOf(A, input[i]);
                int[] transIndex=null;
                bool goOn = false;
                if (indexA != -1)
                {
                    Переменная_Номер_Один_Которая_Указывает_Нам_На_Индекс_В_Алфавате_Последнего_Прочитанного_Символа = stk.Peek();
                    try
                    {
                        goOn = Rule(ManDevice[StateIndex][stk.Peek(), indexA], out outed, out transIndex);
                    }
                    catch (AutomatException aex)
                    {
                        MessageBox.Show(aex.Message);
                    }
                    OnStep(indexA + di, StateIndex, outed, GetStackAsArray());
                    if (transIndex != null)
                        translationIndexes.AddRange(transIndex);

                    if (!goOn)
                        return;
                }
                else
                {
                    #region bad input symb

                    if (OnStep(indexA, StateIndex, outed, GetStackAsArray()) == true)
                    {
                        //states[i] = null;
                        //output[i] = null;
                        continue;
                    }
                    // stop
                    //Array.Resize(ref states, i);
                    //Array.Resize(ref output, i);
                    return;
                    #endregion
                }
            }

            return;
        }

        private bool OnStep(int indexA, int new_state, int outed, int[] stackState)
        {
            if (Step != null)
                return Step(indexA, new_state, outed, stackState, null);
            return true;
        }

        [Obsolete("It was a mistake to use this method, lol", true)]
        public override void PrintAutomat(object o)
        {
            if (o is DataGridView)
            {
                DataGridView grid = (DataGridView)o;
                grid.Rows.Clear();
                grid.Columns.Clear();
                for (int i = 0; i < A.Length; i++)
                    grid.Columns.Add("column" + i.ToString(), A[i].ToString());

                grid.Rows.Add((M.Length - 5)* S.Length);

                for (int i = 0; i < S.Length; i++)
                {
                    for (int j = 0; j < M.Length - 5 - 1; j++)
                    {
                        grid.Rows[j].HeaderCell.Value =
                            "(" + S[i].ToString() + ") " + M[j].ToString();
                        grid.Rows[j].HeaderCell.Style.Alignment =
                            DataGridViewContentAlignment.MiddleLeft;
                    }

                    grid.Rows[M.Length -1].HeaderCell.Value =
    "(" + S[i].ToString() + ") " + M[M.Length - 1].ToString();
                    grid.Rows[M.Length - 1].HeaderCell.Style.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;

                }

                for (int k = 0; k < S.Length; k++)
                {
                    for (int i = 0; i < M.Length; i++)
                        for (int j = 0; j < A.Length; j++)
                        {
                            grid.Rows[i].Cells[j].Value = "#" + ManDevice[k][i, j].ToString();
                        }
                }
                grid.AutoResizeColumns();
                grid.AutoResizeRows();
            }
        }

        protected override void CheckAutomatConsistency()
        {
            for (int st = 0; st < ManDevice.GetLength(0); st++)
            {
                foreach (int ruleNo in ManDevice[st])
                {
                    if ((ruleNo > rules.Length) || (ruleNo < 0))
                    {
                        throw new AutomatException("Manage table for state No." + st.ToString() +
                            "contains not existing rule number");
                    }
                }

            }
            if (Z.Length < 2)
                throw new AutomatException(@"MM automat must have at least two states.
This one dosen't");
        }

    }
}