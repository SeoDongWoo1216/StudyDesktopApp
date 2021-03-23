using LiveCharts;
using MahApps.Metro.Controls;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Threading;

namespace _210323_PhotoSensorMonApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public class SensorData
    {
        public int Idx { get; set; }
        public DateTime CurrentDt { get; set; }
        public int Value { get; set; } 
        public bool SimulFlag { get; set; }

        // 그냥 Alt+엔터로 생성자 생성가능.(매개변수로 받을거 선택하고 만들면됨)
        public SensorData(int idx, DateTime currentDt, int value, bool simulFlag)
        {
            Idx = idx;
            CurrentDt = currentDt;
            Value = value;
            SimulFlag = simulFlag;
        }
    }
 
    public partial class MainWindow : MetroWindow
    {
        // NLog 사용 : NLog를 통해서 일일이 지정하고 코딩해야하는 로그를 편하게 세팅할 수 있다. => 유지 보수에 굉장한 메리트가 있음.
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();

            logger.Info("PhotoSensorMonApp Initialized...");
        }

        public ChartValues<int> ChartValues { get; set; }

        public int SensorValue { get; set; }
        public DispatcherTimer CustomTimer { get; set; }


        // DB 연결할때 제일 중요한건 연결 문자열이다.
        // Data Source=210.119.12.87;Initial Catalog=IoTData;User ID=sa;Password=***********
        private string connString = $"Data Source=210.119.12.87;" +
                                    $"Initial Catalog=IoTData;" +
                                    $"User ID=sa;Password=mssql_p@ssw0rd!";

        // 메서드로 DB 연결
        public SensorData GetRealTimeSensor()
        {
            SensorData result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT TOP 1 Idx 
                                        , CurrentDt 
                                        , Value 
                                        , SimulFlag 
                                     FROM  Tbl_PhotoResistor 
                                   ORDER BY Idx DESC;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    var temp = cmd.ExecuteReader();
                    if (temp.Read())
                    {
                        result = new SensorData(Convert.ToInt32(temp["Idx"]),
                                                Convert.ToDateTime(temp["CurrentDT"]),
                                                Convert.ToInt32(temp["Value"]),
                                                Convert.ToBoolean(temp["SimulFlag"]));
                    }
                }
                
                logger.Info("GetRealTimeSensor() Completed");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외발생 : {ex.Message}");
                logger.Error($"GetRealTimeSensor() error occured : {ex}");
            }

            return result;

        }



        private void Window_Initialized(object sender, EventArgs e)
        {
            // 기본 WPF 차트 사용
            //var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
            //var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();
            //ChtLine.Plot(x, y);

            // Live Chart 사용
            ChartValues = new ChartValues<int>();     // 최초의 데이터(일단 주석처리) { 5, 7, 8, 9, 15, 20, 16, 3, 20, 40};
            GrdHistory.DataContext = ChartValues;

            CustomTimer = new DispatcherTimer();
            CustomTimer.Interval = TimeSpan.FromSeconds(1);     // 1초마다
            CustomTimer.Tick += CustomTimer_Tick;
            // CustomTimer.Start();
        }

        private void CustomTimer_Tick(object sender, EventArgs e)
        {
            SensorValue = GetRealTimeSensor().Value;
            GrdRealTime.DataContext = SensorValue;
        }
     
        private void MnuStart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CustomTimer.Start();
        }

        private void MnuStop_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CustomTimer.Stop();
        }

        private void MnuExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuLoad_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            HistoryValues.ItemsSource = GetHistorySensors();
        }


        // 라이브차트 데이터 바인딩 : 대용량의 데이터를 처리하기에는 너무 시간이 걸린다는 단점이있다.
        // 그래서 oxyPlot으로 사용했음
        private List<DataPoint>  GetHistorySensors()
        {
            List<DataPoint> result = new List<DataPoint>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = $@"SELECT Top 250 Idx, Value 
                                    FROM Tbl_PhotoResistor 
                                   WHERE CurrentDt > CONVERT(DATETIME, '{DateTime.Now:yyyy-MM-dd}' )
                                  ORDER BY IDX;";

                     SqlCommand cmd = new SqlCommand(query, conn);
                     SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(new DataPoint(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1])));
                    }
                }

                logger.Info("GetHistorySensors() Completed");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외발생 : {ex.Message}");
                logger.Error($"GetHistorySensors error occured : {ex}");
            }

            return result;
        }
    }
}
