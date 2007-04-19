using System;

namespace automats
{
    public class ExtendingPrefixIdenifierAutomat : ExtendingTerminalAutomat
    {
        uint[] vector;

        public ExtendingPrefixIdenifierAutomat()
        {
            vector = new uint[26];
        }

        virtual protected uint CharToVectorIndex(char ch)
        {
            ch = Char.ToUpperInvariant(ch);

            uint index = Convert.ToUInt32(ch) - Convert.ToUInt32('A');
            if (!Char.IsLetter(ch) || index < 0 || index >= vector.Length)
                throw new ArgumentException("The word you trying to add starts with invalid symbol, it has to be in range 'A'..'Z' or 'a'..'z'");
            return index;
        }

        public override void Add(string Word)
        {
            Word = Word.ToUpper();

            uint index = CharToVectorIndex(Word[0]);

            if (vector[index] == 0)
            {
                this.Dictonary.Add(new Card(Word.ToCharArray(1, Word.Length - 1)));
                vector[index] = Card.LastCardId;
                return;
            }
            else
            {
                base._find(Word.Substring(1), vector[index], true);
            }

            //if (vector[index] >= Card.LastCardId)
            //{
            //   
            //}
            //else
            // 
        }

        public override bool Find(string Word)
        {
            return _find(Word.Substring(1), vector[CharToVectorIndex(Word[0])], false);
        }

        public override void Clear()
        {
            base.Clear();
            Array.Clear(vector, 0, vector.Length);
        }

        public override void Print(System.Windows.Forms.DataGridView dgv)
        {
            base.Print(dgv);
            // now first three rows are filled with dictonary data

            dgv.SuspendLayout();

            dgv.ColumnCount = dgv.ColumnCount + 2;

            // we want to print vector at the begining, so shift current rows down
            dgv.Rows.Insert(0, 3);

            // prepare enought room to fit vector in width
            if (dgv.ColumnCount < vector.Length)
                dgv.ColumnCount = vector.Length;

            // Print (up?) vector
            for (int j = 0; j < vector.Length; j++)
            {
                dgv[j, 0].Value = Convert.ToChar(Convert.ToUInt32('A') + j);
                if (vector[j] != 0)
                    dgv[j, 1].Value = vector[j].ToString();
            }

            dgv.Columns.RemoveAt(dgv.ColumnCount - 1);

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ResumeLayout(false);

            if (dgv.SelectedCells != null && dgv.SelectedCells.Count > 0)
                dgv.SelectedCells[0].Selected = false;

        }

        //public event MyEventHandler WordFound;
        //public delegate void MyEventHandler(string word);

        //void Processor(string input)
        //{

        //    if (WordFound != null)
        //        WordFound(
        //}
    }
}
