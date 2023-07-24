using Microsoft.VisualBasic;
using System;
using System.Threading;
using System.Windows;

namespace Thread_project
{
    public partial class MainWindow : Window
    {
        private int min;
        private int max;
        private Thread? _thread;
        private Thread? _thread_fibo;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (But_Start.Content.ToString() == "Стоп")
            {
                if(_thread!=null && _thread.IsAlive)
                {
                    _thread.Abort();
                }
                But_Start.Content = "Старт";
            }
            min = Convert.ToInt32(TextBox_Min.Text);
            max = Convert.ToInt32(TextBox_Max.Text);
            _thread = new Thread(GeneratedNumber);
            _thread.Start();
            But_Start.Content = "Стоп";
        }

        private void Button_Click_Fibo(object sender, RoutedEventArgs e)
        {
            if (But_Start_Fibo.Content.ToString() == "Стоп")
            {
                if (_thread_fibo != null && _thread_fibo.IsAlive)
                {
                    _thread_fibo.Abort();
                    But_Start_Fibo.Content = "Старт";
                }
            }
            _thread_fibo = new Thread(GeneratedFibonachi);
            _thread_fibo.Start();
        }

        private void GeneratedNumber()
        {
            for (int i = min; i <= max; i++)
            {
                if (IsPrime(i))
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        
                        TextBox_Result.Text += " " + i.ToString();
                    });
                    Thread.Sleep(200);
                }

            }
        }

        private void GeneratedFibonachi()
        {
            int a = 0;
            int b = 1;

            while (true)
            {
                int c = a + b;
                a = b;
                b = c;
                this.Dispatcher.Invoke(() =>
                {
                    TextBox_Result_Fibo.Text += " " + a.ToString();
                });
                
                Thread.Sleep(200);
            }
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;

            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0) return false;
            }
            
            return true;
        }
    }

}
