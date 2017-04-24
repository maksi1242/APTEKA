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

namespace ПРАКТИКА__АПТЕКА_
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow kekushki = new MainWindow();
            
            this.Hide();
            kekushki.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow kokushki = new MainWindow();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Sotrudnik kok = new Sotrudnik();
           kok.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Tovar kak = new Tovar();
            kak.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Klient kik = new Klient();
            kik.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Postavshik sasha = new Postavshik();
            sasha.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Доставка sas = new Доставка();
            sas.Show();
        }
    }
}
