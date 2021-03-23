using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _210316_197_IoTSensorMonApp
{
    public partial class FrmMain : Form
    {
        private Timer timerSimul = new Timer();
        private Random randPhoto = new Random();
        private bool IsSimulation = false;
        private List<SensorData> sensors = new List<SensorData>();  // 차트, 리스트박스에 출력될 데이터
        private string connString = "Data Source=127.0.0.1;Initial Catalog=IoTData;" +
                                    "User ID=sa;Password=mssql_p@ssw0rd!";

        private double xCount = 100;  // 차트에 보이는 데이터 수
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 콤보박스 초기화
            foreach (var port in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(port);
            }
            CboSerialPort.Text = "Select Port";

            // IoT장비에서 받을 값의 범위
            PrbPhotoResistor.Minimum = 0;
            PrbPhotoResistor.Maximum = 1023;
            PrbPhotoResistor.Value = 0;

            // 차트 모양 초기화
            InitChartStyle();

            // BtnDisplay 초기화
            BtnDisplay.BackColor = Color.BlueViolet;
            BtnDisplay.ForeColor = Color.WhiteSmoke;
            BtnDisplay.Text = "Unknown";
            BtnDisplay.Font = new Font("맑은 고딕", 14, FontStyle.Bold);

            // 나머지 초기화
            LblConnectTime.Text = "Connection Time";
            TxtSensorNum.TextAlign = HorizontalAlignment.Right;
            TxtSensorNum.Text = "0";
            BtnConnect.Enabled = BtnDisConnect.Enabled = false;
        }

        // 차트 초기 설정
        private void InitChartStyle()
        {
            ChtPhotoResistors.ChartAreas[0].BackColor = Color.Blue;
            ChtPhotoResistors.ChartAreas[0].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas[0].AxisX.Maximum = xCount;
            ChtPhotoResistors.ChartAreas[0].AxisX.Interval = xCount / 4;
            ChtPhotoResistors.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.WhiteSmoke;
            ChtPhotoResistors.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ChtPhotoResistors.ChartAreas[0].AxisY.Minimum = 0;
            ChtPhotoResistors.ChartAreas[0].AxisY.Maximum = 1024;
            ChtPhotoResistors.ChartAreas[0].AxisY.Interval = xCount;
            ChtPhotoResistors.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.WhiteSmoke;
            ChtPhotoResistors.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ChtPhotoResistors.ChartAreas[0].CursorX.AutoScroll = true;
            ChtPhotoResistors.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ChtPhotoResistors.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            ChtPhotoResistors.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            ChtPhotoResistors.Series.Clear();  // Series1 값 지움.
            ChtPhotoResistors.Series.Add("PhotoValue");
            ChtPhotoResistors.Series[0].ChartType = SeriesChartType.Line;
            ChtPhotoResistors.Series[0].Color = Color.Coral;
            ChtPhotoResistors.Series[0].BorderWidth = 3;

            // 범례 삭제
            if (ChtPhotoResistors.Legends.Count > 0)
            {
                for (int i = 0; i < ChtPhotoResistors.Legends.Count; i++)
                {
                    ChtPhotoResistors.Legends.RemoveAt(i);
                }
            }
        }

        private void MnuBeginSimulation_Click(object sender, EventArgs e)
        {
            IsSimulation = true;
            timerSimul.Enabled = true;
            timerSimul.Interval = 200;
            timerSimul.Tick += TimerSimul_Tick;
            timerSimul.Start();
        }

        private long timeSpan = 0; // 시간 흐름 값
        private int randMaxVal = 0; // 랜덤값 담을 변수

        private void MnuEndSimulation_Click(object sender, EventArgs e)
        {

            IsSimulation = false;
            timerSimul.Stop();
        }

        private void TimerSimul_Tick(object sender, EventArgs e)
        {
            timeSpan += 1;
            var temp = timeSpan % 30; // 30부터 0으로 다시 시작(플래그)

            if(temp.ToString().Length == 2)
            {
                randMaxVal = 980;
            }
            else
            {
                randMaxVal = 120;
            }

            int value = randPhoto.Next(randMaxVal-40, randMaxVal); // 
            ShowSensorValue(value.ToString());
        }

        // 센서값 화면 출력 메서드
        private void ShowSensorValue(string value)
        {
            int.TryParse(value, out int v);

            var currentTime = DateTime.Now;
            SensorData data = new SensorData(currentTime, v, IsSimulation);
            sensors.Add(data);
            InsertTable(data);

            // 센서값 개수 출력
            TxtSensorNum.Text = $"{sensors.Count}";

            // 현재 프로그레스 값 출력
            PrbPhotoResistor.Value = v;

            // 리스트박스의 데이터 출력
            var item = $"{currentTime.ToString("yyyy-MM-dd HH:mm:ss")} \t {v}";
            LsbPhotoResistors.Items.Add(item);
            LsbPhotoResistors.SelectedIndex = LsbPhotoResistors.Items.Count - 1; // 이 구문으로인해 포커스가 스크롤과함께 내려감
            // 이렇게 스크롤처리 안해놓으면 스크롤내려가도 포커스가 맨위에 멈춰있다.

            // 차트에 데이터 출력
            ChtPhotoResistors.Series[0].Points.Add(v);

            // 200개 넘으면
            ChtPhotoResistors.ChartAreas[0].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas[0].AxisX.Maximum = (sensors.Count >= xCount) ? sensors.Count : xCount;

            // Zoom처리
            if (sensors.Count > xCount)
                ChtPhotoResistors.ChartAreas[0].AxisX.ScaleView.Zoom(sensors.Count - xCount, sensors.Count); // 10에서 200까지
            else 
                ChtPhotoResistors.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);  // 0에서 200까지

            // BtnDisplay 표시
            if (IsSimulation)
                BtnDisplay.Text = v.ToString();
            else
                BtnDisplay.Text = "~" + "\n" + v.ToString();
        }


        // IoTData데이터베이스 내 tbl_PhotoResistor 테이블에 센서 데이터 입력
        private void InsertTable(SensorData data)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var query = $"insert into tbl_PhotoResistor " +
                        $"(CurrentDt, Value, SimulFlag)" +
                        $"values" +
                        $"('{data.Current.ToString("yyyy-MM-dd HH:mm:ss")}','{data.Value}','{(data.SimulFlag == true ? "1" : "0")}');";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"예외 발생 : {ex.Message}");
            }
        }

        // 종료 버튼 클릭
        private void MnuExit_Click(object sender, EventArgs e)
        {
            if (IsSimulation)
            {
                MessageBox.Show("시뮬레이션을 멈춘 후 프로그램을 종료하세요.", "종료",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Environment.Exit(0);
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            ChtPhotoResistors.ChartAreas[0].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas[0].AxisX.Maximum = sensors.Count;

            ChtPhotoResistors.ChartAreas[0].AxisX.ScaleView.Zoom(0, sensors.Count);
            ChtPhotoResistors.ChartAreas[0].AxisX.Interval = sensors.Count / 4;
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {
            ChtPhotoResistors.ChartAreas[0].AxisX.Minimum = 0;
            ChtPhotoResistors.ChartAreas[0].AxisX.Maximum = sensors.Count;

            ChtPhotoResistors.ChartAreas[0].AxisX.ScaleView.Zoom(sensors.Count - xCount, sensors.Count);
            ChtPhotoResistors.ChartAreas[0].AxisX.Interval = xCount / 4;
        }


        // 시뮬레이션 끝
        private void BtnDisConnect_Click(object sender, EventArgs e)
        {
            // TODO 나중에 실제 작업시 작성
        }


        // 시뮬레이션 시작
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            // TODO 나중에 실제 작업시 작성
        }
    }
}
