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

    /// <summary>
    /// Direction of the piece move.
    /// Inversion (A xor 11²) of bits of the numerical values 
    /// gives us the opposite direction:
    /// Up = 01², Left = 00², Down = 10², Right = 11².
    /// </summary>
    public enum Direction
    {

        Up = 1, Down = 2, Left = 0, Right = 3,
        NotApplicable = 4,
    }

    // TODO Validation: Only 1 empty cell should be -- ?
    public class Board
    {
        public static Board t = null;
        
        Cell[,] map;

        internal float f, g;
        internal Board previous;
        internal Direction lastTurn;

        public Direction LastTurn { get { return lastTurn; } }

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
            lastTurn = b.lastTurn;
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

        /// <summary>
        /// Evaluate which cells are around ijEmpty,
        /// than check if they can take the empty cell's place
        /// </summary>
        /// <returns>Enumeration of acceptable turns</returns>
        public IEnumerable<Direction> EnumerateValidTurns()
        {

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

        /// <summary>
        /// Performs the move in the specifed direction.
        /// </summary>
        /// <returns>True if successfull.</returns>
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

            lastTurn = dir;
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
            if (di < -1) return false;
            if (dj < -1) return false;
            // check if no move should occure
            if (di == 0 && dj == 0) return true;
            // can turn only in horizontal or vertical axe
            if (Math.Abs(di) * Math.Abs(dj) != 0) return false;

            Swap(r, c, iEmpty, jEmpty);

            // set this.turn
            if (di != 0) this.lastTurn = di == 1 ? Direction.Down : Direction.Up;
            if (dj != 0) this.lastTurn = dj == 1 ? Direction.Right : Direction.Left;

            iEmpty = r;
            jEmpty = c;

            return true;
        }

        /// <summary>
        /// Swaps any two cells on the board
        /// </summary>
        /// <param name="i1">First cell's row</param>
        /// <param name="j1">First cell's column</param>
        /// <param name="i2">Second cell's row</param>
        /// <param name="j2">Second cell's column</param>
        protected void Swap(int i1, int j1, int i2, int j2)
        {
            Cell t = map[i1, j1];

            map[i1, j1] = map[i2, j2];
            map[i2, j2] = t;
        }

        /// <summary>
        /// Converts every board on the list to a CSV string
        /// and sends it out to the Debugger
        /// </summary>
        public static void PrintOut(List<Board> list)
        {
            foreach (Board b in list)
            {
                Debugger.Log(0, "", b.ToCSV()+Environment.NewLine);
            }
        }

        /// <summary>
        /// Performs the search of solution
        /// </summary>
        /// <param name="initState">Initial board state</param>
        /// <param name="etalonState">Target board state</param>
        /// <param name="listBoard">The list of board states on the way to the solution</param>
        /// <param name="L">L - длинна найденного пути до цели.
        /// L is equal to the lenght of the path generated by GeneratePath() method.</param>
        /// <param name="T">Т - общее число раскрытых вершин при переборе.
        /// T equals to the length of CLOSED list at exit.</param>
        /// <returns>True if successfull</returns>
        public static bool HeuristicsSearch(Board initState, Board etalonState, out List<Board> listBoard,
            out int L, out int T)
        {
            //init all
            List<Board> lOpen, lClosed;

            lOpen = new List<Board>();
            lClosed = new List<Board>();

            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(initState);
            initState.f = MeasureNotAtPlace(initState, etalonState);
            initState.g = 0;
            initState.lastTurn = Direction.NotApplicable;
            initState.previous = null;
            
            while (true)
            {
                //Log(string.Format("Open: {0}, close: {1}.", lOpen.Count, lClosed.Count));

                if (lOpen.Count == 0)
                {
                    listBoard = null;
                    L = 0;
                    T = lClosed.Count;
                    return false;
                }

                // search [open] for pos and q of min f
                int iMin = 0;
                float fMin = float.MaxValue;

                int pos = 0;
                foreach (Board bd in lOpen)
                {
                    if (bd.f < fMin)
                    {
                        fMin = bd.f;
                        iMin = pos;
                    }

                    pos++;
                }

                // Раскрыть n ≡ lOpen[iMin]. Порождённые - в OPEN, настроив указатели на предка.
                foreach (Direction dir in lOpen[iMin].EnumerateValidTurns())
                {
                    if (dir == ReverseTurn(lOpen[iMin].lastTurn)) continue;

                    // TODO: Write copy-constructor and use it instead of next 2 lines
                    t = (Board)lOpen[iMin].MemberwiseClone();
                    t.map = (Cell[,])lOpen[iMin].map.Clone();

                    // do turn
                    t.Turn(dir);
                    t.previous = lOpen[iMin];

                    // update f
                    t.g++;
                    t.f = t.g + MeasureNotAtPlace(t, etalonState);

                    // Если порожденная вершина целевая - == ВЫХОД ==.
                    if (t.f == t.g) // f=g => h=0
                    {
                        listBoard = lOpen[iMin].GeneratePath();
                        L = listBoard.Count;
                        T = lClosed.Count;
                        return true;
                    }
                    else
                    {
                        // search for equal nodes in lOpen and lClosed, update their f
                        bool inList = false;
                        foreach (Board bd in lOpen)
                        {
                            for (int i = 0; i < bd.Rows; i++)
                                for (int j = 0; j < bd.Columns; j++)
                                    if (bd[i, j].Text != t.map[i, j].Text) goto nextItem;

                            if (bd.f > t.f)
                            {
                                bd.f = t.f;
                                bd.g = t.g;                                
                                bd.previous = t.previous;
                                bd.lastTurn = t.lastTurn;
                                inList = true;
                            }
                            break; // stop search open list
                        nextItem: ;
                        }

                        if (!inList)
                            foreach (Board bd in lClosed)
                            {
                                for (int i = 0; i < bd.Rows; i++)
                                    for (int j = 0; j < bd.Columns; j++)
                                        if (bd[i, j].Text != t.map[i, j].Text) goto nextItem;

                                inList = true;
                                break; // stop search closed list

                            nextItem: ;
                            }

                        if (!inList) lOpen.Add(t);
                    }
                }

                lClosed.Add(lOpen[iMin]);
                lOpen.RemoveAt(iMin);
            }
            throw new InvalidOperationException("This execution point never will be reached");
        }

        private static Direction ReverseTurn(Direction direction)
        {
            return (Direction)((byte)direction ^ 3);
        }

        public static float MeasureNotAtPlace(Board bd, Board etalonState)
        {
            int h = 0;
            int n = bd.Rows;
            int m = bd.Columns;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    // поиск в эталоне
                    int ie, je;
                    for (ie = 0; ie < n; ie++)
                        for (je = 0; je < m; je++)
                        {
                            if (bd[i, j].Text == etalonState[ie, je].Text)
                            {
                                goto etaFound;
                            }
                        }

                    throw new InvalidOperationException("Etalon does not contain the piece");

                etaFound:
                    h += Math.Abs(i - ie) + Math.Abs(j - je);
                }

            return h;
            //int count = 0;
            //for (int i = 0; i < bd.Rows; i++)
            //{
            //    for (int j = 0; j < bd.Columns; j++)
            //    {
            //        if (bd[i, j].Text != etalonState[i, j].Text) count++;
            //    }
            //}
            //return count;
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
            string res = string.Format("f:{0} g:{1} h:{2}|", f, g, MeasureNotAtPlace(this, Board.Etalon));

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].IsEmpty) res += "    ";
                    else res += " " + map[i, j].Text + " ";
                }
                res += "||";
            }

            return res;
        }

        public string ToCSV()
        {
            string res = "";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].IsEmpty) res += "-;";
                    else res += map[i, j].Text + ";";
                }
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