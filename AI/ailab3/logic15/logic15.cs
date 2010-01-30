using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;

namespace logic15
{
    public class Cell
    {
        /// <summary>
        /// neihbours
        /// </summary>
        //Cell nUp, nDown, nLeft, nRight;

        Button val;
        public string Text;

        public Button Button { get { return val; } set { val = value; } }

        public Cell()
        {
            isEmpty = false;
        }

        public Cell(bool Empty)
        {
            isEmpty = Empty;
        }

        bool isEmpty;

        public bool IsEmpty
        {
            get { return isEmpty; }
            protected set { isEmpty = value; }
        }
    }

    public enum Direction { Up=0, Down, Left, Right }

    // TODO Validation: Only 1 empty cell should be
    public class Board
    {
        Cell[,] map;

        internal float g;
        internal Board previous;
        internal Direction turn;

        int iEmpty, jEmpty;

        public int EmptyCol
        {
            get { return jEmpty; }
        }

        public int EmptyRow
        {
            get { return iEmpty; }
        }

        public Board(int rows, int cols)
        {
            previous = null;
            map = new Cell[rows, cols];
        }

        public Board(Board b)
        {
            map = (Cell[,])b.map.Clone();

            this.g = b.g;
            previous = null;
            turn = b.turn;
            iEmpty = b.iEmpty;
            jEmpty = b.jEmpty;
        }

        public Cell this[int i, int j]
        {
            get { return map[i, j]; }
            set { map[i, j] = value; }
        }

        public int Rows { get { return map.GetLength(0); } }
        public int Columns { get { return map.GetLength(1); } }

        public IEnumerable<Direction> EnumerateValidTurns()
        {
            // eval which cells are around ijEmpty
            // than check if they can take the empty place

            if (iEmpty + 1 < map.GetLength(0))
                yield return Direction.Down;

            if (jEmpty + 1 < map.GetLength(1))
                yield return Direction.Right;

            if (iEmpty - 1 >= 0)
                yield return Direction.Up;

            if (jEmpty - 1 >= 0)
                yield return Direction.Left;

            yield break;
        }

        public static Board Load(string FileName)
        {
            Board board;

            StreamReader f = null;
            try
            {
                f = new StreamReader(FileName);

                string line = f.ReadLine();
                string[] strs = line.Split(';');
                int n = int.Parse(strs[0]);
                int m = int.Parse(strs[1]);


                board = new Board(n, m);

                int i = 0;
                while (!f.EndOfStream && (i < n))
                {
                    line = f.ReadLine();
                    strs = line.Split(';');

                    if (strs.Length != m) throw new FormatException(
                        "Wrong columns number at line " + i.ToString());

                    for (int j = 0; j < m; j++)
                    {
                        if (strs[j].Length == 0)
                        {
                            board.map[i, j] = new Cell(true);
                            board.iEmpty = i;
                            board.jEmpty = j;
                        }
                        else
                        {
                            board.map[i, j] = new Cell(false);
                        }

                        board.map[i, j].Text = strs[j];
                    }

                    i++;
                }

                if (i != n)
                {
                    throw new FormatException(string.Format(
                        "Wrong rows number at line {0} in file '{1}'", i, FileName));
                }
            }
            finally
            {
                if (f != null) f.Close();
            }

            return board;
        }

        public bool Turn(Direction dir)
        {
            int x = iEmpty, y = jEmpty;

            switch (dir)
            {
                case Direction.Left:
                    x = iEmpty;
                    y = jEmpty - 1;
                    break;
                case Direction.Right:
                    x = iEmpty;
                    y = jEmpty + 1;
                    break;
                case Direction.Up:
                    x = iEmpty - 1;
                    y = jEmpty;
                    break;
                case Direction.Down:
                    x = iEmpty + 1;
                    y = jEmpty;
                    break;
            }

            // check if turn is valid;
            if (x < 0 || x > Rows - 1) Debug.Fail("Wrong turn attempt: "+dir.ToString());// return false;
            if (y < 0 || y > Columns - 1) Debug.Fail("Wrong turn attempt: " + dir.ToString());// return false;
            

            Swap(x, y, iEmpty, jEmpty);

            iEmpty = x;
            jEmpty = y;

            turn = dir;
            return true;
        }

        /// <summary>
        /// Moves the cell at (r,c) to the empty position.
        /// </summary>
        /// <returns>True if successfull.</returns>
        public bool Turn(int r, int c)
        {
            int di, dj;
            di = r - iEmpty;
            dj = c - jEmpty;

            // cannot turn far cells 
            if (di > 1) return false;
            if (dj > 1) return false;
            // check if no move should occure
            if (di == 0 && dj == 0) return true;
            // can turn only in horizontal or vertical axe
            if (Math.Abs(di) * Math.Abs(dj) != 0) return false;

            Swap(r, c, iEmpty, jEmpty);

            // set this.turn
            if (di != 0) this.turn = di == 1 ? Direction.Down : Direction.Up;
            if (dj != 0) this.turn = dj == 1 ? Direction.Right : Direction.Left;

            iEmpty = r;
            jEmpty = c;

            return true;
        }

        protected void Swap(int i1, int j1, int i2, int j2)
        {
            Cell t = map[i1, j1];

            map[i1, j1] = map[i2, j2];
            map[i2, j2] = t;
        }

        public static bool HeuristicsSearch(Board initState, Board etalonState, out Board lastBoard)
        {
            int q;

            //init all
            List<Board> lOpen, lClosed;
            
            lOpen = new List<Board>();
            lClosed = new List<Board>();
            //this.previous = null;
            q = 0;

            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(initState);

            bool traversed = false;
            while (!traversed)
            {
                //Log(string.Format("Open: {0}, closed: {1}.", lOpen.Count, lClosed.Count));

                if (lOpen.Count == 0)
                {
                    traversed = true;
                    break;
                }

                // search [open] for pos and q
                int pos = 0;
                float f = float.MaxValue;
                foreach (Board bd in lOpen)
                {
                    float h = MeasureNotAtPlace(bd, etalonState);
                    if (h + bd.g < f)
                    {
                        f = h+bd.g;
                        q = pos;
                    }

                    pos++;
                }

                if (MeasureNotAtPlace(lOpen[q], etalonState) == 0)
                {
                    lastBoard = lOpen[q];
                    return true;
                }

                Board t = null;
               //q = 0; // в ширину
                //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                foreach (Direction dir in lOpen[q].EnumerateValidTurns())
                {
                    if (dir == ReverseTurn(lOpen[q].turn)) continue;

                    // TODO: Create copy-constructor for Board and use it here instead of MemberwiseClone()
                    t = (Board)lOpen[q].MemberwiseClone();
                    t.map = (Cell[,])lOpen[q].map.Clone();

                    t.g = t.g + 1;
                    t.Turn(dir);
                    t.previous = lOpen[q];

                    //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                    if (MeasureNotAtPlace(t, etalonState) == 0) // TODO: is this check ext
                    {
                        lastBoard = lOpen[q];
                        return true;
                    }
                    else
                    {
                        lOpen.Add(t);
                        //lOpen.Insert(p, t);
                        //if (q >= p) q += p;
                    }
                }

                lClosed.Add(lOpen[q]);
                lOpen.RemoveAt(q);
            }

            //Log(string.Format("Best path EVR: {0:#.##}", bestPathLen));
            lastBoard = null;
            return false;
        }

        private static Direction ReverseTurn(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static float MeasureNotAtPlace(Board bd, Board etalonState)
        {
            int count = 0;
            for (int i = 0; i < bd.Rows; i++)
            {
                for (int j = 0; j < bd.Columns; j++)
                {
                    if (bd[i, j].Text != etalonState[i, j].Text) count++;
                }
            }
            return count;
        }

        private static Board etalonState;
        public static Board Etalon
        {
            get
            {
                return etalonState;
            }
            set
            {
                etalonState = (Board)value.MemberwiseClone();
                etalonState.map = (Cell[,])value.map.Clone();
            }
        }

        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].IsEmpty) res += "    ";
                    else res += " " + map[i, j].Text + " ";
                }
                res += Environment.NewLine;
            }

            return res;
        }

        List<Board> path = null;
        public List<Board> GeneratePath()
        {
            if (path == null)
                path = new List<Board>();
            else
                path.Clear();

            Board curr = this;
            while (curr != null)
            {
                path.Add(curr);
                curr = curr.previous;
            }

            return path;
        }
    }
}