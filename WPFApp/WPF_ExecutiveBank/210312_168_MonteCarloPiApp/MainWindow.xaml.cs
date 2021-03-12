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
using System.Windows.Threading;

namespace _210312_168_MonteCarloPiApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        int iCnt = 0;
        int oCnt = 0;

        DispatcherTimer timer;
        Random rand;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            rand = new Random();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10);  // 1ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 1;
            rect.Height = 1;

            int x = rand.Next(0, 400);
            int y = rand.Next(0, 400);

            if((x - 200) * (x - 200) + (y - 200) * (y - 200) <= 40000)
            {
                rect.Stroke = Brushes.Red;   // 원 안쪽
                iCnt++;
            }
            else 
            {
                rect.Stroke = Brushes.Blue;  // 원 바깥
                oCnt++;
            }

            int count = iCnt + oCnt;
            double Pi = (double)iCnt / count * 4;
            TxtStatus.Text = $"n: {count}, In: {iCnt}, Out: {oCnt}, PI: {Pi}";
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            CvsPi.Children.Add(rect);

        }
    }
}
