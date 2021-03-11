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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _21_03_11_159_BlinkerApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStartBlink_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void BtnStopBlick_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(2000000);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(BtnStartBlink.Background == Brushes.Red)
            {
                BtnStartBlink.ClearValue(Button.BackgroundProperty);
                BtnStopBlick.Background = Brushes.Green;
            }
            else
            {
                BtnStopBlick.ClearValue(Button.BackgroundProperty);
                BtnStartBlink.Background = Brushes.Red;
            }
        }
    }
}
