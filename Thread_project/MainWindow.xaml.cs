using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Thread_project
{
    public partial class MainWindow : Window
    {
        private int min;
        private int max;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public MainWindow()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (But_Start.Content.ToString() == "Стоп")
            {
                cancellationTokenSource.Cancel();
                But_Start.Content = "Старт";
            }
            else
            {
                min = Convert.ToInt32(TextBox_Min.Text);
                max = Convert.ToInt32(TextBox_Max.Text);
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
                But_Start.Content = "Стоп";

                await Task.Run(() => GeneratedNumber(cancellationToken));
            }
        }

        private async void Button_Click_Fibo(object sender, RoutedEventArgs e)
        {
            if (But_Start_Fibo.Content.ToString() == "Стоп")
            {
                cancellationTokenSource.Cancel();
                But_Start_Fibo.Content = "Старт";
            }
            else
            {
                min = Convert.ToInt32(TextBox_Min.Text);
                max = Convert.ToInt32(TextBox_Max.Text);
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
                But_Start_Fibo.Content = "Стоп";

                await Task.Run(() => GeneratedFibonachi(cancellationToken));
            }
        }

        private void GeneratedNumber(CancellationToken cancellationToken)
        {
            for (int i = min; i <= max; i++)
            {
                if (IsPrime(i) && !cancellationToken.IsCancellationRequested)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        TextBox_Result.Text += " " + i.ToString();
                    });
                    Thread.Sleep(200);
                }
            }
        }

        private void GeneratedFibonachi(CancellationToken cancellationToken)
        {
            int a = 0;
            int b = 1;

            while (!cancellationToken.IsCancellationRequested && a <= max)
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
