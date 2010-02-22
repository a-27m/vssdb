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
        Button[,] pieces;

        public Window1()
        {
            InitializeComponent();
            but1.Visibility = Visibility.Hidden;
        }

        private void textBox1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
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
            Grid.SetColumn(pieces[r, c], OldEmptyCol);
            Grid.SetRow(pieces[r, c], OldEmptyRow);
            Swap(r, c, OldEmptyRow, OldEmptyCol);
        }

        protected void Swap(int i1, int j1, int i2, int j2)
        {
            Button t = pieces[i1, j1];

            pieces[i1, j1] = pieces[i2, j2];
            pieces[i2, j2] = t;
        }

        private void but1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void but1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void load_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            board = Board.Load("4x4.csv");
            board.SetAsEtalon();

            GenerateMesh(board.Rows, board.Columns);

            //int no = 1;
            pieces = new Button[board.Rows, board.Columns];

            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (board[i, j].IsEmpty) { continue; }

                    pieces[i, j] = new Button();
                    pieces[i, j].Click += but1_Click;
                 //  pieces[i, j].MouseEnter += Triggers).First());//.MouseEnter; OnMouseEnter1;
                    pieces[i, j].Effect = but1.Effect;
                    pieces[i, j].Margin = but1.Margin;
                    pieces[i, j].Style = but1.Style;
                    pieces[i, j].FontFamily = but1.FontFamily;
                    pieces[i, j].FontSize = but1.FontSize;
                    pieces[i, j].FontStyle = but1.FontStyle;
                    pieces[i, j].FontWeight = but1.FontWeight;
                    pieces[i, j].Content = board[i, j].Value;//no++.ToString(); //(i * board.Columns + j + 1).ToString();

                    Grid.SetColumn(pieces[i, j], j);
                    Grid.SetRow(pieces[i, j], i);
                    gridField.Children.Add(pieces[i, j]);
                }
            }
        }

        private void mix_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            textBox1.AppendText(string.Join("; ",
                board.EnumerateValidTurns().AsQueryable<Direction>().Select(d => d.ToString()).ToArray()));

            return;

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

            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (pieces[i, j] == null) continue;
                    Grid.SetColumn(pieces[i, j], j);
                    Grid.SetRow(pieces[i, j], i);
                }
            }
        }

        private void solve_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            board.HeuristicsSearch();
            List<Board> list = board.GeneratePath();

            board = list[0];

            gridField.Children.Clear();
            pieces = new Button[board.Rows, board.Columns];

            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (board[i, j].IsEmpty) { continue; }

                    pieces[i, j] = new Button();
                    pieces[i, j].Click += but1_Click;
                    //  pieces[i, j].MouseEnter += Triggers).First());//.MouseEnter; OnMouseEnter1;
                    pieces[i, j].Effect = but1.Effect;
                    pieces[i, j].Margin = but1.Margin;
                    pieces[i, j].Style = but1.Style;
                    pieces[i, j].FontFamily = but1.FontFamily;
                    pieces[i, j].FontSize = but1.FontSize;
                    pieces[i, j].FontStyle = but1.FontStyle;
                    pieces[i, j].FontWeight = but1.FontWeight;
                    pieces[i, j].Content = board[i, j].Value;//no++.ToString(); //(i * board.Columns + j + 1).ToString();

                    Grid.SetColumn(pieces[i, j], j);
                    Grid.SetRow(pieces[i, j], i);
                    gridField.Children.Add(pieces[i, j]);
                }
            }
        }
    }
}
