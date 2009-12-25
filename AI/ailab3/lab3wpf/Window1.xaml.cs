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

namespace lab3wpf
{
	/// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
		
        public Window1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			textBox1.Text += 
			textBox1.Visibility.ToString();
			textBox1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {	
			
		}

        private void but1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			int r, c;
			
			c = Grid.GetColumn(but1);
			r = Grid.GetRow(but1);

			textBox1.Text += c.ToString() + ";" + r.ToString() + Environment.NewLine;
			//gridField.Children.Remove(but1);
			Grid.SetColumn(but1, c+1);
			Grid.SetRow(but1, r+1);
			//gridField.Children.Add(but1);
        }
    }
}
