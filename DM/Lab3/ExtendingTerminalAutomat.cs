using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace automats
{
    public class ExtendingTerminalAutomat
    {
        const char _EndMarker = '¶';

        List<Card> dictonary = null;

        public List<Card> Dictonary
        {
            get
            {
                return dictonary;
            }
        }

        public struct Card
        {
            static uint lastCardId = 0;

            public static uint LastCardId
            {
                get
                {
                    return Card.lastCardId;
                }
            }

            uint id;
            public uint Id
            {
                get
                {
                    return id;
                }
            }

            char[] symbols;
            public char[] Symbols
            {
                get
                {
                    return symbols;
                }
            }

            uint[] alter_ids;
            public uint[] AlternativeCardIds
            {
                get
                {
                    return alter_ids;
                }
                set
                {
                    alter_ids = value;
                }
            }

            public Card(char[] Symbols)
            {
                if (Symbols == null)
                    throw new ArgumentNullException();

                this.id = ++lastCardId;
                this.alter_ids = new uint[Symbols.Length];
                this.symbols = Symbols;
            }

            public static void ResetIndices()
            {
                lastCardId = 0;
            }
        }

        public ExtendingTerminalAutomat()
        {
            dictonary = new List<Card>();
        }

        uint lastSearchComparsions = 0;

        public uint LastSearchComparsionsCount
        {
            get
            {
                return lastSearchComparsions;
            }
        }

        protected bool _find(string Word, uint StartFrom, bool WeNeedToAddIfNotFound)
        {
            lastSearchComparsions = 0;

            // add ''—|''
            Word += _EndMarker;

            if (dictonary.Count == 0)
            {
                if (WeNeedToAddIfNotFound)
                {
                    dictonary.Add(new Card(Word.ToCharArray()));
                    return true;
                }
                else
                    return false;
            }

            // initialize search loop
            List<Card>.Enumerator i = dictonary.GetEnumerator();
            while (i.MoveNext() && StartFrom-- > 0)
                ;

            int cardPos = 0;

            // start to search for a given Word
            for (int wordPos = 0; wordPos < Word.Length; )
            {
                lastSearchComparsions++;

                if (i.Current.Symbols[cardPos] == _EndMarker && Word[wordPos] == _EndMarker)
                {
                    // we're at the end of the current card, 
                    // so we've found a Word in the dictonary.
                    return true;
                }

                // compare letters in the Word and in the Card.
                if (i.Current.Symbols[cardPos] == Word[wordPos])
                {
                    // qual
                    cardPos++;
                    wordPos++;
                    continue;
                }
                else
                {
                    // not equal, so follow by the alternative way.
                    uint alternativeCardId = i.Current.AlternativeCardIds[cardPos];

                    if (alternativeCardId == 0)
                    {
                        // i.e. no alternative card, so there we can either …                       

                        if (WeNeedToAddIfNotFound)
                        {
                            // … create new card and place Word in the dictonary, …
                            Card card = new Card(Word.ToCharArray(wordPos, Word.Length - wordPos));
                            i.Current.AlternativeCardIds[cardPos] = card.Id;
                            dictonary.Add(card);
                            return true;
                        }
                        else
                        {
                            // … or say about absence
                            return false;
                        }
                    }

                    while (i.Current.Id != alternativeCardId)
                        i.MoveNext();

                    // set position in the new card to zero
                    cardPos = 0;

                    continue;
                }
            }

            return false;
        }

        virtual public void Add(string Word)
        {
            _find(Word, 0, true);
        }

        virtual public bool Find(string Word)
        {
            return _find(Word, 0, false);
        }

        virtual public void Clear()
        {
            dictonary.Clear();
            Card.ResetIndices();
        }

        virtual public void Print(DataGridView dgv)
        {
            dgv.SuspendLayout();

            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.ColumnCount = 1;
            dgv.Rows.Add(3);

            dgv.Rows[0].HeaderCell.ToolTipText = "Номер состояния";
            dgv.Rows[1].HeaderCell.ToolTipText = "Входной символ";
            dgv.Rows[2].HeaderCell.ToolTipText = "Альтернативный переход";

            dgv.Rows[0].HeaderCell.Value = "i";
            dgv.Rows[1].HeaderCell.Value = "A";
            dgv.Rows[2].HeaderCell.Value = "d";

            int i = 0;
            foreach (Card card in dictonary)
            {
                Color backColor = SystemColors.Control;

                dgv.Columns.Add("a", "a");
                dgv[i, 0].Value = card.Id.ToString();
                dgv[i, 0].Style.BackColor = backColor;

                dgv.ColumnCount = dgv.ColumnCount + card.Symbols.Length;

                for (int j = 0; j < card.Symbols.Length; j++)
                {
                    uint alt = card.AlternativeCardIds[j];

                    dgv[i + j, 1].Value = card.Symbols[j];
                    dgv[i + j, 2].Value = alt == 0 ? "" : alt.ToString();

                    dgv[i + j, 1].Style.BackColor = backColor;
                    dgv[i + j, 2].Style.BackColor = backColor;
                }

                i += card.Symbols.Length + 1;
            }

            dgv.Columns.RemoveAt(dgv.ColumnCount - 1);

            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();

            dgv.ResumeLayout(false);

            if (dgv.SelectedCells != null && dgv.SelectedCells.Count > 0)
                dgv.SelectedCells[0].Selected = false;
        }
    }
}
