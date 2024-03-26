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
    /// Логика взаимодействия для Candel.xaml
    /// </summary>
    /// 
    public class fire
    {
        Random random = new Random();
        Rectangle rectangle = new Rectangle();
        public fire(Canvas canvas)
        {
            rectangle.Width = 3;
            rectangle.Height = 3;

            Canvas.SetLeft(rectangle, random.Next(235,260));
            Canvas.SetTop(rectangle, 250);
            canvas.Children.Add(rectangle);
            int a = random.Next(1, 6);
            switch (a)
            {
                case 0:
                    rectangle.Fill = Brushes.Gold;
                    break;
                case 1:
                    rectangle.Fill = Brushes.Red;
                    break;
                case 2:
                    rectangle.Fill = Brushes.OrangeRed;
                    break;
                case 3:
                    rectangle.Fill = Brushes.Yellow;
                    break;
                case 4:
                    rectangle.Fill = Brushes.DarkRed;
                    break;
                case 5:
                    rectangle.Fill = Brushes.LightYellow;
                    break;
                default:
                    rectangle.Fill = Brushes.Blue;
                    break;
            }
            
            moveup();
        }
        async private void moveup()
        {
            for (int i = 250; i > random.Next(180,230); i--)
            {
                Canvas.SetTop(rectangle, i);
                await Task.Delay(10);
            }
            rectangle.Fill = Brushes.White;
        }
        ~fire()
        {// ясно
            //MessageBox.Show("da");
        }
    }
    public partial class Candel : Window
    {
        public Canvas canvas = new Canvas();
        Rectangle rectangle = new Rectangle();
        public Candel()
        {
            InitializeComponent();
            DrawOnCanvas();           
            nemogu();
        }
        async private void nemogu()
        {
            while (true == true)
            {
                fire fire = new fire(canvas);
                await Task.Delay(10);
            }
           
        }
        private void DrawOnCanvas()
        {
            // Создаем элемент Canvas

            canvas.Width = 500;
            canvas.Height = 500;

            // Создаем прямоугольник и добавляем его на Canvas
            rectangle.Width = 500;
            rectangle.Height = 500;
            rectangle.Fill = Brushes.White;
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 0);
            canvas.Children.Add(rectangle);
            this.Content = canvas;
        }
    }
}
