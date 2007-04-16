using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab3
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

            public Card(string Word)
            {
                if (Word == null)
                    throw new ArgumentNullException();

                this.id = ++lastCardId;
                this.alter_ids = new uint[Word.Length];

                Word += _EndMarker;
                this.symbols = Word.ToCharArray();
            }
        }

        public ExtendingTerminalAutomat()
        {
            dictonary = new List<Card>();
        }

        protected bool _find(string Word, bool WeNeedToAddIfNotFound)
        {
            // add ''—|''
            Word += _EndMarker;

            // initialize search loop
            List<Card>.Enumerator i = dictonary.GetEnumerator();
            i.MoveNext();
            int cardPos = 0;

            // start to search for a given Word
            for (int wordPos = 0; wordPos < Word.Length; wordPos++)
            {
                if (cardPos == i.Current.Symbols.Length-1)
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

                    if (alternativeCardId == 0 && WeNeedToAddIfNotFound)
                    {
                        // i.e. no alternative card, so there we can …                       

                        if (WeNeedToAddIfNotFound)
                        {
                            // … either create new card and place Word in the dictonary …
                            Card card = new Card(Word.ToCharArray(wordPos, Word.Length - wordPos));
                            i.Current.AlternativeCardIds[cardPos-1] = card.Id;
                            dictonary.Add(card);
                            return true;
                        }
                        else
                        {
                            // … or say about absence
                            return false;
                        }
                    }

                    while (i.Current.Id < alternativeCardId)
                        i.MoveNext();

                    // set position in the new card to zero
                    cardPos = 0;

                    continue;
                }
            }

            return false;
        }

        public void Add(string Word)
        {
            _find(Word, true);
        }

        public bool Find(string Word)
        {
            return _find(Word, false);
        }
    }
}
