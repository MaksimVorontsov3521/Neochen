﻿using System;
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
    /// Логика взаимодействия для Snake.xaml
    /// </summary>
    /// 

    public class TheSnake
    {
        public int numebr;
        public Rectangle part = new Rectangle();
        protected int[,] coordinates = new int[2,2];
        public bool a = true;
        public void collisia()
        { 
        
        }
    }

    public class SnakesHead : TheSnake
    {
        public int[] adirection;
        public SnakesHead(int[] direction,Canvas canvas)
        {
            this.adirection = direction;
            part.Fill = Brushes.DarkGreen;
            part.Width = 15;
            part.Height = 15;
            Canvas.SetLeft(part, 100);
            Canvas.SetTop(part, 100);
            // честно я запутался, что за что отвечает. 
            // 00 - x1,10-x2, 01-y1,11-y2 - но это не точно
            coordinates[0, 0] = 100; 
            coordinates[1, 0] = 115; 
            coordinates[0, 1] = 100; 
            coordinates[1, 1] = 115;
            canvas.Children.Add(part);
            move(adirection);
            numebr = 0;
        }
        async void move(int[] direction)
        {
            int sped = 10;
            while (a==true)
            {               
                coordinates[0, 0] += direction[0];
                coordinates[1, 0] += direction[0];
                coordinates[0, 1] += direction[1];
                coordinates[1, 1] += direction[1];
                await Task.Delay(sped);
                Canvas.SetLeft(part, coordinates[0, 0]);
                Canvas.SetTop(part, coordinates[0, 1]);
                if (coordinates[0, 0] < 0 || coordinates[0, 1] < 0 || coordinates[1, 0] > 250 || coordinates[1, 1] > 250)
                {
                    a = false;
                    MessageBox.Show("Вы проиграли");
                }
            }
        }
    }
    public partial class Snake : Window
    {//                     x   y
        int[] direction = { 0, 1 };
        Canvas canvas = new Canvas();
        Rectangle rectangle = new Rectangle();
        Rectangle left = new Rectangle();
        Rectangle right = new Rectangle();
        Rectangle down = new Rectangle();
        Rectangle up = new Rectangle();
        SnakesHead snake;
        public Snake()
        {
            InitializeComponent();
            DrawOnCanvas();            
            this.KeyDown += fourDirections;
            SnakesHead snake = new SnakesHead(direction, canvas);
            this.snake=snake;
        }
        private void fourDirections(object sender, KeyEventArgs e)
        {
            allblue();
            switch (e.Key)
            {
                case Key.W:
                    up.Fill = Brushes.Red;
                    snake.adirection[0] = 0;
                    snake.adirection[1] = -1;
                    break;
                case Key.S:
                    down.Fill = Brushes.Red;
                    snake.adirection[0] = 0;
                    snake.adirection[1] = 1;
                    break;
                case Key.D:
                    right.Fill = Brushes.Red;
                    snake.adirection[0] = 1;
                    snake.adirection[1] = 0;
                    break;
                case Key.A:
                    left.Fill = Brushes.Red;
                    snake.adirection[0] = -1;
                    snake.adirection[1] = 0;
                    break;
            }
        }
        private void allblue()
        {
            left.Fill = Brushes.Blue;
            right.Fill = Brushes.Blue;
            down.Fill = Brushes.Blue;
            up.Fill = Brushes.Blue;
        }
        private void DrawOnCanvas()
        {
            canvas.Width = 500;
            canvas.Height = 500;

            rectangle.Width = 500;
            rectangle.Height = 500;
            rectangle.Fill = Brushes.White;
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 0);

           //move
            left.Width = 50;
            left.Height = 50;
            left.Fill = Brushes.Blue;
            Canvas.SetLeft(left, 350);
            Canvas.SetTop(left, 350);

            right.Width = 50;
            right.Height = 50;
            right.Fill = Brushes.Blue;
            Canvas.SetLeft(right, 450);
            Canvas.SetTop(right, 350);

            down.Width = 50;
            down.Height = 50;
            down.Fill = Brushes.Blue;
            Canvas.SetLeft(down, 400);
            Canvas.SetTop(down, 400);

            up.Width = 50;
            up.Height = 50;
            up.Fill = Brushes.Blue;
            Canvas.SetLeft(up, 400);
            Canvas.SetTop(up, 300);
            //border
            Line lb = new Line();
            lb.Stroke = System.Windows.Media.Brushes.Black;
            lb.X1 = 0;
            lb.Y1 = 0;
            lb.X2 = 0;         
            lb.Y2 = 250;
            Line rb = new Line();
            rb.Stroke = System.Windows.Media.Brushes.Black;
            rb.X1 = 250;
            rb.Y1 = 0;
            rb.X2 = 250;
            rb.Y2 = 250;
            Line db = new Line();
            db.Stroke = System.Windows.Media.Brushes.Black;
            db.X1 = 250;
            db.Y1 = 250;
            db.X2 = 0;
            db.Y2 = 250;
            Line ub = new Line();
            ub.Stroke = System.Windows.Media.Brushes.Black;
            ub.X1 = 0;
            ub.Y1 = 0;
            ub.X2 = 250;
            ub.Y2 = 0;
            //add
            canvas.Children.Add(rectangle);
            canvas.Children.Add(left);
            canvas.Children.Add(right);
            canvas.Children.Add(down);
            canvas.Children.Add(up);
            canvas.Children.Add(lb);
            canvas.Children.Add(rb);
            canvas.Children.Add(db);
            canvas.Children.Add(ub);
            this.Content = canvas;
        }
    }
}

