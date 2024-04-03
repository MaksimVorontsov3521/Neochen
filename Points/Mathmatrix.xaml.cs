using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Points
{
    /// <summary>
    /// Логика взаимодействия для Mathmatrix.xaml
    /// </summary>
    public partial class Mathmatrix : Window
    {
        Mathmatrix mathmatrix;
        public void itself(Mathmatrix mathmatrix)
        {
            this.mathmatrix = mathmatrix;
            some_work();
        }
        public Mathmatrix()
        {
            //InitializeComponent();
        }
        private void some_work()
        {
            Border myBorder = new Border();
            myBorder.Background = Brushes.LightBlue;
            myBorder.BorderBrush = Brushes.Black;
            myBorder.Padding = new Thickness(15);
            myBorder.BorderThickness = new Thickness(2);

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;

            TextBox firstleft = new TextBox();
            firstleft.Margin = new Thickness(5, 5, 0, 0);
            firstleft.Height = 20;
            firstleft.Width = 20;
            firstleft.FontSize = 18;
            firstleft.Text = Convert.ToString(firstleft.Margin);

            // Add child elements to the parent StackPanel.
            myStackPanel.Children.Add(firstleft);
            // Add the StackPanel as the lone Child of the Border.
            myBorder.Child = myStackPanel;
            // Add the Border as the Content of the Parent Window Object.
            mathmatrix.Content = myBorder;
            mathmatrix.Show();
        }
    }
}
