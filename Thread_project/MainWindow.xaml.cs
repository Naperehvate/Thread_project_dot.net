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

    }

}
