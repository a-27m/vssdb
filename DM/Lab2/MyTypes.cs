using System.Collections.Generic;

namespace MyTypes
{

	public class Lexema
	{
		public object lexemClass;
		public object value;

		public Lexema(object lexClass, object value)
		{
			this.lexemClass = lexClass;
			this.value = value;
		}

        public static object[] GetDistinctClasses(Lexema[] setOfLexemas)
        {
            List<object> preResult = new List<object>(setOfLexemas.Length);

            for (int i = 0; i < setOfLexemas.Length; i++)
            {
                if (null ==
                    preResult.Find(delegate(object obj)
                    {
                        return setOfLexemas[i].lexemClass.Equals(obj);
                    }))
                { preResult.Add(setOfLexemas[i].lexemClass); }
            }
            return preResult.ToArray();
        }

        public static object[] GetClasses(Lexema[] arrayOfLexemas)
        {
            object[] preResult = new object[arrayOfLexemas.Length];

            for (int i = 0; i < arrayOfLexemas.Length; i++)
                preResult[i] = arrayOfLexemas[i].lexemClass;

            return preResult;
        }

        public static object[] GetValues(Lexema[] arrayOfLexemas)
        {
            object[] preResult = new object[arrayOfLexemas.Length];

            for (int i = 0; i < arrayOfLexemas.Length; i++)
                preResult[i] = arrayOfLexemas[i].value;

            return preResult;
        }

        public override bool Equals(object obj)
        {
            return this.lexemClass.Equals((obj as Lexema).lexemClass);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}