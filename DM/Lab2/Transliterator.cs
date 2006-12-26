using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MyTypes;
using System.Collections;

namespace Lab2
{
    public class Transliterator
    {
        static bool skip_garbage = false;

        public class TranslitResult : IAsyncResult
        {
            private Lexema[] m_result;

            public TranslitResult(Lexema[] result)
            {
                m_result = result;
            }

            #region IAsyncResult Members

            public object AsyncState
            {
                get
                {
                    return m_result;
                }
            }

            public WaitHandle AsyncWaitHandle
            {
                get
                {
                    throw new Exception("The method or operation is not implemented.");
                }
            }

            public bool CompletedSynchronously
            {
                get
                {
                    return false;
                }
            }

            public bool IsCompleted
            {
                get
                {
                    throw new Exception("The method or operation is not implemented.");
                }
            }

            #endregion
        }

        public enum KindOfSymbol
        {
            Digit,
            Dot,
            E,
            Sign,
            EndToken
        }

        static KindOfSymbol Kind(char ch)
        {
            if (Char.IsDigit(ch))
                return KindOfSymbol.Digit;

            if (ch == '.')
                return KindOfSymbol.Dot;

            if (Char.ToUpper(ch) == 'E')
                return KindOfSymbol.E;

            if (ch == '+' || ch == '-')
                return KindOfSymbol.Sign;

            if (ch == '~')
                return KindOfSymbol.EndToken;

            throw new Exception(
                String.Format("Wrong char in constant: {0}!", ch)
                );
        }

        public static Lexema[] Do(string input, bool SkipGarbage)
        {
            Transliterator.skip_garbage = SkipGarbage;

            int len = input.Length;
            List<Lexema> result = new List<Lexema>(len);

            for (int pos = 0; pos < len; pos++)
            {
                KindOfSymbol kind;
                try
                {
                    kind = Kind(input[pos]);
                }
                catch (Exception e)
                {
                    if (!skip_garbage)
                        throw e;
                    else
                        continue;
                }

                Object value;

                if (kind == KindOfSymbol.Digit)
                {
                    value = byte.Parse(input.Substring(pos, 1));
                }
                else
                {
                    value = input[pos];
                }

                result.Add(new Lexema(kind, value));
            }
            return result.ToArray();
        }

        /// <summary>
        /// used as async state object
        /// </summary> 
        private sealed class _Blah
        {
            public string str;
            public bool SkipGarbage;
            public AsyncCallback callback;

            public _Blah(string str, bool SkipGarbage, AsyncCallback callback)
            {
                this.str = str;
                this.SkipGarbage = SkipGarbage;
                this.callback = callback;
            }
        }

        static void _asyncWorker(object obj)
        {
            _Blah blah = obj as _Blah;

            TranslitResult trAsyncResult =
                new TranslitResult(Do(blah.str, blah.SkipGarbage));

            blah.callback(trAsyncResult);
        }

        public static void DoAsync(string input, bool SkipGarbage, AsyncCallback callback)
        {
            Thread worker = new Thread(
                new ParameterizedThreadStart(Transliterator._asyncWorker));

            _Blah blah = new _Blah(input, SkipGarbage, callback);
            worker.Start(blah);
        }
    }

}
