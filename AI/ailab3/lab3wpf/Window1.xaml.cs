using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using logic15;

namespace lab3wpf
{
	/// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
		Board board;
        //Button[,] pieces;

        public Window1()
        {
            InitializeComponent();
            but1.Visibility = Visibility.Hidden;
        }

        private void textBox1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			//textBox1.Text += 
			//textBox1.Visibility.ToString();
            //textBox1.Visibility = System.Windows.Visibility.Hidden;
        }

        protected void GenerateMesh(int rows, int cols)
        {
            gridField.RowDefinitions.Clear();
            gridField.ColumnDefinitions.Clear();

            RowDefinition rd;
            ColumnDefinition cd;

            for (int i = 0; i < rows; i++)
            {
                rd = new RowDefinition();
                rd.Height = new GridLength(1f / rows, GridUnitType.Star);
                gridField.RowDefinitions.Add(rd);
            }

            for (int j = 0; j < cols; j++)
            {
                cd = new ColumnDefinition();
                cd.Width = new GridLength(1f / cols, GridUnitType.Star);
                gridField.ColumnDefinitions.Add(cd);
            }
        }

        // the button-piece i mean
        private void but1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			int r, c;
            Button bt = (sender as Button);
			
			c = Grid.GetColumn(bt);
            r = Grid.GetRow(bt);
            int OldEmptyCol = board.EmptyCol;
            int OldEmptyRow = board.EmptyRow;


            if (board[r, c].IsEmpty) return;

            if (!board.Turn(r, c))
            {
                // no such turn
                bt.Background = Brushes.Red;
                return;
            }

            // log
			textBox1.Text += c.ToString() + ";" + r.ToString() + Environment.NewLine;

            // update buttons
            Grid.SetColumn(board[OldEmptyRow, OldEmptyCol].Button, OldEmptyCol);
            Grid.SetRow(board[OldEmptyRow, OldEmptyCol].Button, OldEmptyRow);
            //Swap(r, c, OldEmptyRow, OldEmptyCol);
        }

        protected void Swap(int i1, int j1, int i2, int j2)
        {
            Cell t = board[i1, j1];
            board[i1, j1] = board[i2, j2];
            board[i2, j2] = t;
        }

        private void but1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

        private void but1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }

        private void load_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            board = Board.Load("4x4.csv");
            //board = Board.Load("3x3.csv");
            Board.Etalon = board;

            GenerateMesh(board.Rows, board.Columns);

            //int no = 1;
            //pieces = new Button[board.Rows, board.Columns];

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board[i, j].IsEmpty) { continue; }

                    Button pce = new Button();
                    
                    pce.Click += but1_Click;
                 //  pce.MouseEnter += Triggers).First());//.MouseEnter; OnMouseEnter1;
                    pce.Effect = but1.Effect;
                    pce.Margin = but1.Margin;
                    pce.Style = but1.Style;
                    pce.FontFamily = but1.FontFamily;
                    pce.FontSize = but1.FontSize;
                    pce.FontStyle = but1.FontStyle;
                    pce.FontWeight = but1.FontWeight;
                    pce.Content = board[i, j].Text;//no++.ToString(); //(i * board.Columns + j + 1).ToString();

                    Grid.SetColumn(pce, j);
                    Grid.SetRow(pce, i);
                    gridField.Children.Add(pce);

                    board[i, j].Button = pce;
                }
            }
        }

        private void mix_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //textBox1.AppendText(string.Join("; ",
            //    board.EnumerateValidTurns().AsQueryable<Direction>().Select(d => d.ToString()).ToArray()));

            //return;

			Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                int oldi, oldj;
                oldi = board.EmptyRow;
                oldj = board.EmptyCol;

                IEnumerable<Direction> turns;
                turns = board.EnumerateValidTurns();
                board.Turn(turns.ToArray()[rnd.Next(turns.Count())]);

                // update buttons
                Swap(oldi, oldj, board.EmptyRow, board.EmptyCol);
            }

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board[i, j].IsEmpty) continue;
                    Grid.SetColumn(board[i, j].Button, j);
                    Grid.SetRow(board[i, j].Button, i);
                }
            }
        }

        public void some_Turn(object sender, EventArgs e)
        {
            board = Board.t;

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board[i, j].IsEmpty) continue;
                    Grid.SetColumn(board[i, j].Button, j);
                    Grid.SetRow(board[i, j].Button, i);
                }
            }            
        }

        private void solve_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Board boardResult;
            Board.ehan = some_Turn;

            Board.HeuristicsSearch(board, Board.Etalon, out boardResult);

            List<Board> list = boardResult.GeneratePath();

            board = list[0];

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board[i, j].IsEmpty) continue;
                    Grid.SetColumn(board[i, j].Button, j);
                    Grid.SetRow(board[i, j].Button, i);
                }
            }

            /*
            for (int i = 0; i < 10; i++)
            {
                int oldi, oldj;
                oldi = board.EmptyRow;
                oldj = board.EmptyCol;

                IEnumerable<Direction> turns;
                turns = board.EnumerateValidTurns();
                board.Turn(turns.ToArray()[rnd.Next(turns.Count())]);

                // update buttons
                Swap(oldi, oldj, board.EmptyRow, board.EmptyCol);
            }

             */
            //gridField.Children.Clear();
            //pieces = new Button[board.Rows, board.Columns];

            //for (int i = 0; i < pieces.GetLength(0); i++)
            //{
            //    for (int j = 0; j < pieces.GetLength(1); j++)
            //    {
            //        if (board[i, j].IsEmpty) { continue; }

            //        board[i, j].Value = new Button();
            //        board[i, j].Value.Click += but1_Click;
            //        //  board[i, j].Value.MouseEnter += Triggers).First());//.MouseEnter; OnMouseEnter1;
            //        board[i, j].Value.Effect = but1.Effect;
            //        board[i, j].Value.Margin = but1.Margin;
            //        board[i, j].Value.Style = but1.Style;
            //        board[i, j].Value.FontFamily = but1.FontFamily;
            //        board[i, j].Value.FontSize = but1.FontSize;
            //        board[i, j].Value.FontStyle = but1.FontStyle;
            //        board[i, j].Value.FontWeight = but1.FontWeight;
            //        board[i, j].Content = board[i, j].Value.Value;//no++.ToString(); //(i * board.Columns + j + 1).ToString();

            //        Grid.SetColumn(board[i, j].Value, j);
            //        Grid.SetRow(board[i, j].Value, i);
            //        gridField.Children.Add(board[i, j].Value);
            //    }
            //}
        }
    }
}
