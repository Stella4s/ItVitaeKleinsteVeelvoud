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
        private static List<int> Primes;
        public MainWindow()
        {
            InitializeComponent();
            GetPrimes();
        }

        public static void GetPrimes()
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

        public List<int> DoFactorisation(int product)
        {
            List<int> factors = new List<int>();
            foreach (int prime in Primes)
            {
                while (product % prime == 0)
                {
                    product /= prime;
                    factors.Add(prime);
                }
                if (product == 1)
                    break;
            }
            return factors;
        }

        public int CalculateVeelvoud(int getalA, int getalB)
        {
            List<int> factorsA = DoFactorisation(getalA);
            List<int> factorsB = DoFactorisation(getalB);

            var difference = factorsA.Intersect(factorsB);

            int getalC = getalA * getalB;
            foreach (var item in difference)
                getalC /= item;

            return getalC;
        }

        //Reuseable Variables for this method.
        string str1, str2;
        int num1, num2;

        private void Btn_Click_GetVeelvoud(object sender, RoutedEventArgs e)
        {
            try
            {
                str1 = TextBx1.Text.ToString();
                str2 = TextBx2.Text.ToString();
                num1 = Convert.ToInt32(str1);
                num2 = Convert.ToInt32(str2);
                TextB1.Text = string.Format("De kleinste gemene veelvoud van {0} en {1} is {2}.", str1, str2, CalculateVeelvoud(num1, num2));
            }
            catch
            {
                if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                    TextB1.Text = "Vul allebei de nummers in.";
                else
                    TextB1.Text = "Vul alleen nummers in.";
            }
           
        }

 
    }
}
