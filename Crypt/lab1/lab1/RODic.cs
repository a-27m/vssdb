using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    //public struct Letter
    //{
    //    public char Symbol;
    //    public string Code;

    //    public Letter(Char symbol)
    //    {
    //        Symbol = symbol;
    //        Code = "";
    //    }

    //    //public override bool Equals(object obj)
    //    //{
    //    //    return Symbol.Equals(obj);
    //    //}

    //    //public override int GetHashCode()
    //    //{
    //    //    return Symbol.GetHashCode();
    //    //}

    //    //public static bool operator ==(Letter l1, Letter l2)
    //    //{
    //    //    return l1.Symbol == l2.Symbol;
    //    //}
    //    //public static bool operator !=(Letter l1, Letter l2)
    //    //{
    //    //    return l1.Symbol != l2.Symbol;
    //    //}
    //}

    public class RODic
    {
        public class LetterItem
        {
            public KeyValuePair<char, string>[] ltrs;
            public float cost;
        }

        List<LetterItem> items;

        public RODic()
        {
            items = new List<LetterItem>();
        }
   
        public void Add(KeyValuePair<char, string>[] letters, float cost)
        {
            // check no updates-duplicates
            if (Search(letters) != null) return;

            LetterItem item = new LetterItem();
            item.ltrs = letters;
            item.cost = cost;

            items.Add(item);
        }

        public float Read(KeyValuePair<char, string>[] letters)
        {
            LetterItem i = Search(letters);
            if (i == null)
                throw new ArgumentException("Not found");
                //return -1; // TODO throw?
            return i.cost;
        }

        public LetterItem Search(KeyValuePair<char, string>[] letters)
        {
            foreach (LetterItem li in items)
            {
                if (li.ltrs.Length != letters.Length) continue;

                for (int i = 0; i < letters.Length; i++)
                {
                    if (li.ltrs[i].Key != letters[i].Key) { i = letters.Length + 1; continue; }

                    return li;
                }
            }
            return null;        
        }
    }
}
















