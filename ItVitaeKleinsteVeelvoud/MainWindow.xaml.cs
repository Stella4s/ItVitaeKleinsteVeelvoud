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

namespace ItVitaeKleinsteVeelvoud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> Primes;
        public MainWindow()
        {
            InitializeComponent();
            GetPrimes();
        }

        public void GetPrimes()
        {
            int x = 100;
            Primes = new List<int> { 2 };
            for (int i = 3; i < x; i += 2)
            {
                Primes.Add(i);
            }
            for (int i = 3; i < (x/2); i += 2)
            {
                if (Primes.Contains(i))
                {
                    for (int j = 2 * i; j < x; j += i)
                    {
                        Primes.Remove(j);
                    }
                }
            }
        }

        private void Btn_Click_ShowPrimes(object sender, RoutedEventArgs e)
        {
            foreach (int prime in Primes)
            {
                TextBlock1.Text += " " + prime.ToString();
            }
        }
    }
}
