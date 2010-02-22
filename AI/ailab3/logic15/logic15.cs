using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace logic15
{
    public class Cell
    {
        /// <summary>
        /// neihbours
        /// </summary>
        //Cell nUp, nDown, nLeft, nRight;

        object val;

        public object Value { get { return val; } set { val = value; } }

        public Cell()
        {
            isEmpty = false;
        }

        public Cell(bool Empty)
        {
            isEmpty = Empty;
        }

        int gridLocationRow;
        int gridLocationColumn;

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

        internal float f, g, h;
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

        int[] positions;
        int N;

        public Board(int rows, int cols)
        {
            //N = n;
            //positions = new int[n];

            map = new Cell[rows, cols];
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

                        board.map[i, j].Value = strs[j];
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

            if (1 != 1) return false;// check if turn is valid;

            Swap(x, y, iEmpty, jEmpty);

            iEmpty = x;
            jEmpty = y;

            turn = dir;
            return true;
        }

        public bool Turn(int r, int c)
        {
            if (r - iEmpty > 1) return false;
            if (c - jEmpty > 1) return false;


            if (Math.Abs(r - iEmpty) * Math.Abs(c - jEmpty) != 0) return false;

            Swap(r, c, iEmpty, jEmpty);

            // set this.turn

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

        List<Board> lOpen, lClosed;
        bool traversed;
        int q = 0;
        public Board initState;
        public Board etalonState;

        public bool HeuristicsSearch()
        {
            //init all
            lOpen = new List<Board>();
            lClosed = new List<Board>();
            this.previous = null;
            g = 0;
            initState = this;

            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(initState);

            traversed = false;
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
                f = float.MaxValue;
                foreach (Board bd in lOpen)
                {
                    h = MeasureNotAtPlace(bd, etalonState);
                    if (h + bd.g < f)
                    {
                        f = h+bd.g;
                        q = pos;
                    }

                    pos++;
                }

                if (MeasureNotAtPlace(lOpen[q], etalonState) == 0)
                {
                    return true;
                }

                Board t = null;
               //q = 0; // в ширину
                //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                foreach (Direction dir in lOpen[q].EnumerateValidTurns())
                {
                    if (dir == ReverseTurn(lOpen[q].turn)) continue;

                    t = (Board)lOpen[q].MemberwiseClone();
                    t.map = (Cell[,])lOpen[q].map.Clone();
                    t.g = lOpen[q].g + 1;
                    t.Turn(dir);
                    t.previous = lOpen[q];

                //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                if (MeasureNotAtPlace(t, etalonState) == 0)
                {
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
            return false;
        }

        private Direction ReverseTurn(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Down;
                    break;
                case Direction.Down:
                    return Direction.Up;
                    break;
                case Direction.Left:
                    return Direction.Right;
                    break;
                case Direction.Right:
                    return Direction.Left;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
        }

        private float MeasureNotAtPlace(Board bd, Board etalonState)
        {
            int count = 0;
            for (int i = 0; i < bd.map.GetLength(0); i++)
            {
                for (int j = 0; j < bd.map.GetLength(1); j++)
                {
                    if (bd[i, j].Value != etalonState[i, j].Value) count++;
                }
            }
            return count;
        }


        public void SetAsEtalon()
        {
            etalonState = (Board)this.MemberwiseClone();
            etalonState.map = (Cell[,])this.map.Clone();
        }

        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].IsEmpty) res += "    ";
                    else res += " " + map[i, j].Value + " ";
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

            path.Add(lOpen[q]);
            Board curr = lOpen[q];
            while (curr != null)
            {
                path.Add(curr);
                curr = curr.previous;
            }

            return path;
        }
    }
}