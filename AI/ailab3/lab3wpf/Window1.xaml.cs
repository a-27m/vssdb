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

        public Window1()
        {
            InitializeComponent();
            but1.Visibility = Visibility.Hidden;
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

            // redundant
            if (board[r, c].IsEmpty) return;

            if (!board.Turn(r, c))
            {
                // no such turn
                return;
            }

            // log
            //textBox1.Text += c.ToString() + ";" + r.ToString() + Environment.NewLine;

            // update buttons
            Grid.SetColumn(board[OldEmptyRow, OldEmptyCol].Button, OldEmptyCol);
            Grid.SetRow(board[OldEmptyRow, OldEmptyCol].Button, OldEmptyRow);
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
                    pce.Effect = but1.Effect;
                    pce.Margin = but1.Margin;
                    pce.Style = but1.Style;
                    pce.FontFamily = but1.FontFamily;
                    pce.FontSize = but1.FontSize;
                    pce.FontStyle = but1.FontStyle;
                    pce.FontWeight = but1.FontWeight;
                    pce.Content = board[i, j].Text;

                    Grid.SetColumn(pce, j);
                    Grid.SetRow(pce, i);
                    gridField.Children.Add(pce);

                    board[i, j].Button = pce;
                }
            }
        }

        private void mix_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                IEnumerable<Direction> turns;
                turns = board.EnumerateValidTurns();
                Direction dir;
                do
                {
                    dir = turns.ElementAt<Direction>(rnd.Next(turns.Count()));
                }
                while (dir == board.LastTurn);

                board.Turn(dir);
            }

            SyncGridUpToBoard();
        }

        public void SyncGridUpToBoard()
        {
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
            List<Board> list;
            int L, T;

            try
            {
                if (Board.HeuristicsSearch(board, Board.Etalon, out list, out L, out T))
                {
                    if (list != null)
                    {
                        board = list[0];
                        SyncGridUpToBoard();
                    }
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error",  
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }

            textBox1.Text = string.Format(
                "L = {0}," + Environment.NewLine +
                "T = {1}," + Environment.NewLine +
                "P = L/T = {2}",
                L,
                T, 
                ((float)L/T).ToString("F2")
                );

        }
    }
}
