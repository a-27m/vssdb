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
        Cell nUp, nDown, nLeft, nRight;

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

    public enum Direction { Up, Down, Left, Right }

    public class Board
    {
        Cell[,] map;

        int iEmpty, jEmpty;

        int[] positions;
        int N;

        public Board(int rows, int cols)
        {
            //N = n;
            //positions = new int[n];

            map = new Cell[rows, cols];
        }

		public IEnumerable<Direction> EnumerateValidTurns()
		{
			return null;
		}
		
        public void Load(string FileName)
        {
            StreamReader f = null;
            try
            {
                f = new StreamReader(FileName);

                string line = f.ReadLine();
                string[] strs = line.Split(';');
                int n = int.Parse(strs[0]);
                int m = int.Parse(strs[1]);

                map = new Cell[n, m];

                int i = 0;
                while (!f.EndOfStream && (i < n))
                {
                    line = f.ReadLine();
                    strs = line.Split(';');

                    if (strs.Length != m) throw new FormatException(
                        "Wrong columns number at line " + i.ToString());

                    for (int j = 0; j < m; j++)
                    {
                        switch (strs[j][0])
                        { 
                            case '.':
                                map[i, j] = null;
                                break;
                            case '1':
                                map[i, j] = new Cell(false);
                                break;
                            case '0':
                                map[i, j] = new Cell(true);
                                break;
                            default:
                                Debug.WriteLine(string.Format("Wrong input character '{0}' in file '{1}'",
                                    strs[i][0], FileName));

                                map[i, j] = null;
                                break;
                        }
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
        }

        public bool Turn(Direction dir)
        {
            int x, y;

            switch (dir)
            {
                case Direction.Up:
                    x = iEmpty;
                    y = jEmpty - 1;
                    break;
                case Direction.Down:
                    x = iEmpty;
                    y = jEmpty + 1;
                    break;
                case Direction.Left:
                    x = iEmpty - 1;
                    y = jEmpty;
                    break;
                case Direction.Right:
                    x = iEmpty + 1;
                    y = jEmpty;
                    break;
            }

            if (1 == 1) return false;// check if turn is valid;

            Swap(x, y, iEmpty, jEmpty);
        }

        protected void Swap(int i1, int j1, int i2, int j2)
        {
            Cell t = map[i1, j1];

            map[i1, j1] = map[i2, j2];
            map[i2, j2] = t;
        }
    }
}
