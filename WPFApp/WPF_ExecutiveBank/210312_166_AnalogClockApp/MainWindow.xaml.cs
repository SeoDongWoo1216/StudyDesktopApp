using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _210312_166_AnalogClockApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public int HourHand { get; set; }  // 시침
        public int MinHand { get; set; }   // 분침
        public int SecHand { get; set; }   // 초침
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, RoutedEventArgs e)
        {
            SetClock();
            SetTimer();

        }

        // DispatcherTimer 객체 생성하고 interval 속성을 0.01초로 지정. Timer_Tick 메서드로 timer 시작
        private void SetClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);  // 1초
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // 현재 시간을 가져오고 그림이 그려져있는 canvas를 Clear()로 지우고, DrawClockFace를 호출하여 시계판을 그리고
        // DrawHands를 호출하여 시침, 분침, 초침을 그린다.
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime curTime = DateTime.Now;

            CvsClock.Children.Clear();
            DrawClockFace();  // 시계판 그리기

            double radHour = (curTime.Hour % 12 + curTime.Minute / 60.0) * 30 * Math.PI / 180;    // 현재 시간의 각도
            double radMin  = (curTime.Minute + curTime.Second / 60.0) * 6 * Math.PI / 180;        // 현재 분의 각도
            double radSec  = (curTime.Second + curTime.Millisecond / 1000.0) * 6 * Math.PI / 180; // 현재 초의 각도
            DrawHands(radHour, radMin, radSec);
        }

        // 시계바늘 그리기. (Draw.Line 메서드로 시계바늘을 그린후, core를 통해 시계 배꼽을 구현)
        private void DrawHands(double radHour, double radMin, double radSec)
        {
            // 시침
            DrawLine(HourHand * Math.Sin(radHour), -SecHand * Math.Cos(radHour), 0, 0,
                Brushes.RoyalBlue, 8, new Thickness(Center.X, Center.Y, 0, 0));

            // 분침
            DrawLine(MinHand * Math.Sin(radMin), -SecHand * Math.Cos(radMin), 0, 0,
                Brushes.SkyBlue, 6, new Thickness(Center.X, Center.Y, 0, 0));

            // 초침
            DrawLine(SecHand * Math.Sin(radSec), -SecHand * Math.Cos(radSec), 0, 0, 
                Brushes.OrangeRed, 3, new Thickness(Center.X, Center.Y, 0, 0));

            // 시계 배꼽
            Ellipse core = new Ellipse();
            core.Margin = new Thickness(CvsClock.Width / 2 - 10, CvsClock.Height / 2 - 10, 0, 0);
            core.Stroke = Brushes.RoyalBlue;
            core.Fill = Brushes.RoyalBlue;
            core.Width = 20;
            core.Height = 20;
            CvsClock.Children.Add(core);
        }

        // (x1, y1)에서 (x2, y2)까지 color색으로 두께가 thick인 선을 만든다.
        // 위치는 margin 속성,   CvsClock.Children를 호출해서 선이 나타나게만듬.
        private void DrawLine(double x1, double y1, int x2, int y2, SolidColorBrush color, int thick, Thickness margin)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = color;
            line.StrokeThickness = thick; // 두께
            line.Margin = margin;
            line.StrokeStartLineCap = PenLineCap.Round; // 선 시작 부분
            CvsClock.Children.Add(line);
        }

        private void DrawClockFace()
        {
            ElsClock.Stroke = Brushes.LightSteelBlue;
            ElsClock.StrokeThickness = 30;
            CvsClock.Children.Add(ElsClock);
        }

        private void SetTimer()
        {
            Center = new Point(CvsClock.Width / 2, CvsClock.Height / 2);  // 시계 중심
            Radius = CvsClock.Width / 2;     // 시계 반지름
            HourHand = (int)(Radius * 0.45); // 시침 길이
            MinHand = (int)(Radius * 0.55);  // 분침 길이
            SecHand = (int)(Radius * 0.65);  // 초침 길이

        }
    }
}
