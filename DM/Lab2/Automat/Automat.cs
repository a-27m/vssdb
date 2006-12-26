using System;
using System.Collections.Generic;
using System.Text;

namespace automats
{
    class AutomatException : Exception
    {
        public AutomatException(string msg)
            : base(msg)
        {
        }
    }

    /// <summary>Class for a generic automat</summary>
    abstract public class Automat
    {
        object[] a,s,z;
        int stateIndex;

        /// <summary>Current automate's state object</summary>
        public object State
        {
            get
            {
                return s[stateIndex];
            }
            set
            {
                int t = Array.IndexOf(s, value);
                if (t != -1)
                    stateIndex = t;
                else
                    throw new ArgumentOutOfRangeException("Automat has no such state.");
            }
        }

        /// <summary>Current state's index in S[]</summary>
        public int StateIndex
        {
            get
            {
                return stateIndex;
            }
            set
            {
                if ((value < s.Length) && (value >= 0))
                    stateIndex = value;
                else
                    throw new ArgumentOutOfRangeException("Automat has no such state.");
            }
        }

        /// <summary>Set of input symbols</summary>
        public object[] A
        {
            get
            {
                return a;
            }
            protected set
            {
                Set(value, ref a);
            }
        }

        /// <summary>Set of states of automat</summary>
        public object[] S
        {
            get
            {
                return s;
            }
            protected set
            {
                Set(value, ref s);
            }
        }

        /// <summary>Set of output symbols</summary>
        public object[] Z
        {
            get
            {
                return z;
            }
            protected set
            {
                Set(value, ref z);
            }
        }

        protected void Set(object[] value, ref object[] to)
        {
            if (value == null)
                return;
            to = (object[])value.Clone();
        }

        public Automat(object[] A, object[] Z, object[] S)
        {
            this.A = A;
            this.Z = Z;
            this.S = S;
            stateIndex = 0;
        }
        public Automat(Automat o)
        {
            A = o.A;
            S = o.S;
            Z = o.Z;
            stateIndex = o.stateIndex;
        }
        abstract public void Reset();
        abstract public void PrintAutomat(object o);
        abstract protected void CheckAutomatConsistency();
    }

    public enum StepResult
    {
        Success,
        BadInput,
    }
}
