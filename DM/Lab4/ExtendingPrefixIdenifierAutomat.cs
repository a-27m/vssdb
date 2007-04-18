using System;

namespace automats
{
    public class ExtendingPrefixIdenifierAutomat : ExtendingTerminalAutomat
    {
        uint[] vector;

        public ExtendingPrefixIdenifierAutomat()
        {
            vector = new char[26];
        }

        virtual protected uint CharToIndex(char ch)
        {
            int index = (int)(Word[0]) - (int)'A';
            if (!Char.IsLetter(ch) || index < 0 || index >= 26)
                throw new ArgumentException("The word you trying to add starts with invalid symbol, it has to be in range 'A'..'Z' or 'a'..'z'");
            return index;
        }

        public override void Add(string Word)
        {
            Word = Word.ToUpper();
            base.Add(Word.Substring(1));
            int index = CharToIndex(Word[0]);
            if (index < 0 || index >= 26)
                throw new ArgumentException("The word you trying to add starts with invalid symbol, it has to be in range 'A'..'Z' or 'a'..'z'");
            if (vector[index] == 0)
                vector[index] = ExtendingPrefixIdenifierAutomat.Card.LastCardId;
        }

        public override bool Find(string Word)
        {
            return _find(Word.Substring(1), CharToIndex(Word[0]), false);
        }
    }
}
