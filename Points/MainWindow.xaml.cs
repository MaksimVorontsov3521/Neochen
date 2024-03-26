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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Points
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BigFallsend_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(10);
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(1);
            window.Show();
        }

        private void Jump_Click(object sender, RoutedEventArgs e)
        {
            Jump jump = new Jump();
            jump.Show();
        }


        private void Cube_button_Click(object sender, RoutedEventArgs e)
        {
            //"Мне не удалась перевести с С++ на C#. с++ код по ссылке в файле я не очень умный
            Cube cube = new Cube();
            cube.Show();
        }

        private void Snake_Click(object sender, RoutedEventArgs e)
        {
            // я сам себя переиграл и сделал слишком сложно для доьавления хвоста
            Snake snake = new Snake();
            snake.Show();
        }

        private void CandelBtt_Click_1(object sender, RoutedEventArgs e)
        {
            Candel candel = new Candel();
            candel.Show();
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Sounds sounds = new Sounds();
            sounds.Show();
        }
    }
}
