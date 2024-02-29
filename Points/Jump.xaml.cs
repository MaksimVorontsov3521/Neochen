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
    /// Логика взаимодействия для Jump.xaml
    /// </summary>
    public partial class Jump : Window
    {
        Canvas canvas = new Canvas();
        Rectangle rectangle = new Rectangle();
        int[,] fild = new int[500, 500];
        bool down = true;
        public Jump()
        {
            InitializeComponent();
            DrawOnCanvas();        
        }
        private void center()
        {
            // первые 2 цифры - левый верхний угол (x,y) вторые  - правый нижний (x,y)
            int[] block = { 200, 200, 210, 210 };
            Rectangle rec2 = new Rectangle();
            rec2.Width = 10;
            rec2.Height = 10;
            rec2.Fill = Brushes.Red;
            Canvas.SetLeft(rec2, 200);
            Canvas.SetTop(rec2, 200);
            canvas.Children.Add(rec2);
            fall(rec2,block,0);
            rdblock();
        }
        async void rdblock()
        {
            await Task.Delay(1000);
            int[] block2 = { 200, 200, 210, 210 };
            Rectangle rec3 = new Rectangle();
            rec3.Width = 10;
            rec3.Height = 10;
            rec3.Fill = Brushes.Green;
            Canvas.SetLeft(rec3, 200);
            Canvas.SetTop(rec3, 200);
            canvas.Children.Add(rec3);
            fall(rec3, block2, 0);
        }
        async void fall(Rectangle rec2, int[] block,int LR)
        {
            while (block[3] < 500 && block[0] > 0 && block[2]<500)
            {
                    Canvas.SetTop(rec2, block[1]);
                    Canvas.SetLeft(rec2, block[0]);
                    await Task.Delay(10);
                block[1]++;
                block[3]++;
                block[0] = block[0] + LR;
                block[2] = block[2] + LR;
            }
            down = true;
            touch(rec2,block);
        }
        async void touch(Rectangle rec2,int[] block)
        {
            Random random = new Random();
            int LR = 0;
            if (block[1]<10)
            {
                LR = random.Next(-5, 5);
                fall(rec2,block,LR);
            }
            else if (block[3] > 490)
            {
                LR = random.Next(-5, 5);
                up(rec2, block, LR);
            }
            else if (block[0]<10)
            {
                block[2] += 2;
                block[0] += 2;
                LR = random.Next(1, 5);
                if (down == true)
                {
                    fall(rec2, block, LR);
                }
                else
                {
                    up(rec2, block, LR);
                }
            }
            else if (block[2]>490)
            {
                block[2] += -2;
                block[0] += -2;
                LR = random.Next(-5,-1);
                if (down == true)
                {
                    fall(rec2, block, LR);
                }
                else
                {
                    up(rec2, block, LR);
                }
            }                
        }
        async void up(Rectangle rec2, int[] block, int LR)
        {
            while (block[1] > 0 && block[0] > 0 && block[2] < 500)
            {
                Canvas.SetTop(rec2, block[1]);
                Canvas.SetLeft(rec2, block[0]);
                await Task.Delay(1);
                block[1]--;
                block[3]--;
                block[0] = block[0] + LR;
                block[2] = block[2] + LR;
            }
            down = false;
            touch(rec2, block);
            
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
            center();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
