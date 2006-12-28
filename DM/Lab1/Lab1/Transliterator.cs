using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Lab1
{
	[ComVisible(true)]
	public class Transliterator
	{
		public class TranslitResult : IAsyncResult
		{
			private string m_result;

			public TranslitResult(string result)
			{
				m_result = result;
			}

			#region IAsyncResult Members

			public object AsyncState
			{
				get { return m_result; }
			}

			public WaitHandle AsyncWaitHandle
			{
				get { throw new Exception("The method or operation is not implemented."); }
			}

			public bool CompletedSynchronously
			{
				get { return false; }
			}

			public bool IsCompleted
			{
				get { throw new Exception("The method or operation is not implemented."); }
			}

			#endregion
		}

		protected Dictionary<string, string> tabIdentificators;
		protected Dictionary<string, string> tabNumbers;
		protected Dictionary<string, string> tabOther;

		public Transliterator()
		{
			tabIdentificators = new Dictionary<string, string>();
			tabNumbers = new Dictionary<string, string>();
			tabOther = new Dictionary<string, string>();
		}

		public Dictionary<string, string> NameTableIdentificators
		{
			get
			{ return tabIdentificators; }
		}
		public Dictionary<string, string> NameTableNumbers
		{
			get
			{ return tabNumbers; }
		}
		public Dictionary<string, string> NameTableOther
		{
			get
			{ return tabOther; }
		}

		enum KindOfChar { Letter, Digit, Sign }

		KindOfChar Kind(char ch)
		{
			if ( Char.IsLetter(ch) ||(ch=='_'))
				return KindOfChar.Letter;
			if ( Char.IsDigit(ch) )
				return KindOfChar.Digit;
			return KindOfChar.Sign;
		}

		public string Do(string input)
		{
			string output="";

			tabIdentificators.Clear();
			tabNumbers.Clear();
			tabOther.Clear();

			bool error;

			string[] tokens = input.Split(
				new char[] { ' ' },
				StringSplitOptions.RemoveEmptyEntries);
			foreach ( string token in tokens )
			{
				error = false;

				if ( Kind(token[0]) == KindOfChar.Letter )
				{

					// scan
					for ( int i = 1; i < token.Length; i++ )
					{
						if ( Kind(token[i]) == KindOfChar.Sign )
							error=true;
					}
					if ( !error )
					{
						output += TranslateIdentificator(token) + " ";
						continue;
					}
				}
				
				if ( Kind(token[0]) == KindOfChar.Digit )
				{
					// scan
					for ( int i = 1; i < token.Length; i++ )
					{
						if ( Kind(token[i]) != KindOfChar.Digit)
							error =true;
					}
					if ( !error )
					{
						output += TranslateNumber(token) + " ";
						continue;
					}
				}


				if (( Kind(token[0]) == KindOfChar.Sign )||(error))
				{
					output += TranslateOther(token) + " ";
				}
			}

			return output;
		}

		private string TranslateNumber(string token)
		{
			if ( !tabNumbers.ContainsKey(token) )
			{
				tabNumbers.Add(token, "×" +
					( tabNumbers.Count + 1 ).ToString());
			}

			return tabNumbers[token];
		}
		private string TranslateOther(string token)
		{
			if ( !tabOther.ContainsKey(token) )
			{
				tabOther.Add(token, "Ä" + 
					( tabOther.Count + 1 ).ToString());
			}

			return tabOther[token];
		}
		private string TranslateIdentificator(string token)
		{
			if ( !tabIdentificators.ContainsKey(token) )
			{
				tabIdentificators.Add(token, "È" +
					( tabIdentificators.Count + 1 ).ToString());
			}

			return tabIdentificators[token];
		}

		private sealed class _Blah
		{
			public string str;
			public AsyncCallback callback;

			public _Blah(string str, AsyncCallback callback)
			{
				this.str = str;
				this.callback = callback;
			}
		}

		void _asyncWorker(object obj)
		{
			_Blah blah = obj as _Blah;

			TranslitResult trAsyncResult =
				new TranslitResult(Do(blah.str));

			blah.callback(trAsyncResult);
		}

		public void DoAsync(string input, AsyncCallback callback)
		{
			Thread worker = new Thread(
				new ParameterizedThreadStart(this._asyncWorker));

			_Blah blah = new _Blah(input, callback);
			worker.Start(blah);
		}
	}

}
