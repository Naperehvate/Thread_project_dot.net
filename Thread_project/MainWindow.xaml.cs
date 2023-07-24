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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            min = Convert.ToInt32(TextBox_Min.Text);
            max = Convert.ToInt32(TextBox_Max.Text);
            _thread = new Thread(GeneratedNumber);
            _thread.Start();
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
                }
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
