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
    /// Логика взаимодействия для _2Arrays.xaml
    /// </summary>
    public partial class _2Arrays : Window
    {
        private int num = 100;
        public _2Arrays(int num)
        {
            InitializeComponent();         
            updatelength();
            startwork();
        }
        public void updatelength()
        {
            LengthArray.Content = num;
            startwork();
            newone.Value = 0;
            newtwo.Value = 0;
        }
        public int Num
        {
            get { return num; }
            set {
                if (value < 100)
                {
                    num = 100;
                }
                else
                {
                    num = value;
                }
                }
        }
        async Task startwork()
        {
           createArray(newone);
           createArray(newtwo);
        }
        async void createArray(ProgressBar bar)
        {
            int[] array = new int[num];
            Random random = new Random();
            int progres=0;
            bar.Value = progres;
            for (int i = 0; i < num; i++)
            {
                array[i] = random.Next(0, 100);
                progres += 1;
                bar.Value = progres;
                await Task.Delay(10);
            }
        }
    }
}
