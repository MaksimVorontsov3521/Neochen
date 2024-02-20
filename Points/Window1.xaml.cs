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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int s;
        Canvas canvas = new Canvas();
        Rectangle rectangle = new Rectangle();
        int[,] fild = new int[500, 500];
        public Window1(int s)
        {
            this.s=s;
            InitializeComponent();
            DrawOnCanvas();
            newblock(0, 0);
            met();
            for (int i = 0; i < 500; i++)
            {
                fild[i,500-s] = 1;
            }
        }
        async void met()
        {
            for (int i = 0; i < 10000; i++)
            {
                await Task.Delay(100);
                Point position = Mouse.GetPosition(canvas);
                newblock(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
            }
        }
        public void newblock(int x, int y)
        {
            if (x < 0 && y < 0)
            {

            }
            else
            {
                Rectangle rec2 = new Rectangle();
                rec2.Width = s;
                rec2.Height = s;
                rec2.Fill = Brushes.Red;
                Canvas.SetLeft(rec2, x);
                Canvas.SetTop(rec2, y);
                canvas.Children.Add(rec2);
                fall(rec2, x, y);
            }
        }
        async void fall(Rectangle rec2, int x, int y)
        {
            try
            {
                int a = 0;
                for (int i = y; fild[x, i] != 1; i++)
                {
                    Canvas.SetTop(rec2, i);
                    Canvas.SetLeft(rec2, x);
                    await Task.Delay(10);
                    a = i;
                }
                for (int i = 0; i < s; i++)
                {
                    fild[x, a - i] = 1;
                }
                for (int i = 0; i < s; i++)
                {
                    fild[x + i, a - s] = 1;
                }

            }
            catch
            {

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
            rectangle.Fill = Brushes.Blue;
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 0);
            canvas.Children.Add(rectangle);
            this.Content = canvas;
        }
    }
}
