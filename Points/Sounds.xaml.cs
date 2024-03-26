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
using System.Net.Http;

namespace Points
{
    /// <summary>
    /// Логика взаимодействия для Sounds.xaml
    /// </summary>
    /// 
    
    public partial class Sounds : Window
    {

        public Sounds()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            media.Play();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

    }
}
