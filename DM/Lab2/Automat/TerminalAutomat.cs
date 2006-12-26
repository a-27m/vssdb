using System;
using System.Collections.Generic;
using System.Text;

namespace automats
{
    public delegate void ClassesChangedHandler(List<List<int>> list, object[] S);
    public delegate bool TerminalStepDelegate(int inIndex, int newStateIndex, int outSymbolIndex);

    public abstract class TerminalAutomat : Automat
    {
        public event ClassesChangedHandler ClassesChanged;

        public event TerminalStepDelegate Step;

        public TerminalAutomat(object[] A, object[] Z, object[] S)
            : base(A, Z, S)
        {
        }

        #region Minimization
        public TerminalAutomat GetMinimized()
        {
            List<List<int>> classes = new List<List<int>>();
            bool changes = true;

            #region First division

            classes.Add(new List<int>());
            classes[0].Add(0);

            for (int i = 1; i < S.Length; i++)
            {
                PlaceInList(ref classes, i);
            }

            #endregion

            OnClassesChanged(classes);

            while (changes)
            {
                changes = Division(ref classes);
                OnClassesChanged(classes);
            }

            //Building new automat
            return BuildAutomatFromPiClasses(classes);
        }

        private void PlaceInList(ref List<List<int>> cls, int state)
        {
            foreach (List<int> list in cls)
            {
                if (EqOuts(state, list[0]))
                {
                    list.Add(state);
                    return;
                }
            }
            cls.Add(new List<int>());
            cls[cls.Count - 1].Add(state);
        }

        private bool Division(ref List<List<int>> classes)
        {
            bool changes = false;
            // class for dropped out states
            List<int> newclass = new List<int>();

            List<List<int>> nextPi = new List<List<int>>();

            // check all classes of equality
            foreach (List<int> list in classes)
            {
                nextPi.Add(new List<int>());
                nextPi[nextPi.Count - 1].Add(list[0]);
                // for all states in class, exept first
                for (int i = 1; i < list.Count; i++)
                {
                    int Ai;//passed
                    // for each input symbol
                    for (Ai = 0; Ai < A.Length; Ai++)
                    {
                        int temp, ns1, ns2;

                        StateIndex = list[0];
                        ProcessOne(Ai, out ns1, out temp);

                        StateIndex = list[i];
                        ProcessOne(Ai, out ns2, out temp);

                        // doesn't new states belong to the same class?
                        if (!AreInSameClass(classes, ns1, ns2))
                        {
                            break;//after first difference
                        }
                    }
                    if (Ai == A.Length)
                    {
                        // add state to new class
                        nextPi[nextPi.Count - 1].Add(list[i]);
                    }
                    else
                    {
                        changes = true;
                        newclass.Add(list[i]);
                    }

                }
            }

            if (newclass.Count > 0)
                nextPi.Add(newclass);
            classes = nextPi;
            return changes; // reporting changes
        }

        private bool AreInSameClass(List<List<int>> cls, int ns1, int ns2)
        {
            int count = 0;
            foreach (List<int> list in cls)
            {
                count = 0;
                foreach (int s in list)
                {
                    count += s == ns1 ? 1 : 0;
                    count += s == ns2 ? 1 : 0;
                }
                if (count == 2)
                    return true;
            }
            return false;
        }

        private void OnClassesChanged(List<List<int>> classes)
        {
            if (ClassesChanged != null)
                ClassesChanged(classes, S);
        }

        protected abstract bool EqOuts(int i1, int i2);
        protected abstract TerminalAutomat BuildAutomatFromPiClasses(List<List<int>> classes);
        
        #endregion

        protected object CurrentInputSymbol = null;	

        public virtual void Process(object[] input, out object[] states, out object[] output)
        {
            int new_state = StateIndex;
            int outed = -1;
            int queuedLength = input.Length;

            states = new object[queuedLength];
            output = new object[queuedLength];

            int di = 1;

            for (int i = 0; i < queuedLength; i += di)
            {
                CurrentInputSymbol = input[i];

                int indexA = Array.IndexOf(A, input[i]);
                if (indexA != -1)
                {
                    di = ProcessOne(indexA, out new_state, out outed)
                        == StepResult.Success ? 1 : 0;

                    states[i] = S[new_state];
                    output[i] = Z[outed];
                    OnStep(indexA, new_state, outed);
                }
                else
                {
                    #region bad input symb

                    if ((Step != null) &&
                      (Step(indexA, new_state, outed) == true))
                    {
                        states[i] = null;
                        output[i] = null;
                        continue;
                    }
                    // stop
                    Array.Resize(ref states, i);
                    Array.Resize(ref output, i);
                    return;
                    #endregion
                }

            }
        }

        abstract public StepResult ProcessOne(int indexA, out int new_state_index, out int output_index);

        protected bool OnStep(int inIndex, int newStateIndex, int outSymbolIndex)
        {
            if (Step != null)
                return Step(inIndex, newStateIndex, outSymbolIndex);
            return true;
        }
    }
}
