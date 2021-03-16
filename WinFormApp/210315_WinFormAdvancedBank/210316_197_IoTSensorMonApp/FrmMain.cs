using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _210316_197_IoTSensorMonApp
{
    public partial class FrmMain : Form
    {
        private double xCount = 200;  // 차트에 보이는 데이터 수
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
            // ChtPhotoResistors.ChartAreas.Clear();
            // ChtPhotoResistors.ChartAreas.Add("Chart");
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

        private Timer timerSimul = new Timer();
        private Random randPhoto = new Random();
        private bool IsSimulation = false;
        private List<SensorData> sensors = new List<SensorData>();  // 차트, 리스트박스에 출력될 데이터
        private void MnuBeginSimulation_Click(object sender, EventArgs e)
        {
            IsSimulation = true;
            timerSimul.Enabled = true;
            timerSimul.Interval = 1000; // 1초
            timerSimul.Tick += TimerSimul_Tick;
            timerSimul.Start();
        }
        private void MnuEndSimulation_Click(object sender, EventArgs e)
        {
            IsSimulation = false;
            timerSimul.Stop();
        }

        private void TimerSimul_Tick(object sender, EventArgs e)
        {
            int value = randPhoto.Next(1, 1023); // 1 ~ 1023 사이의 값
            ShowSensorValue(value.ToString());
        }

        // 센서값 화면 출력 메서드
        private void ShowSensorValue(string value)
        {
            int.TryParse(value, out int v);

            var currentTime = DateTime.Now;
            SensorData data = new SensorData(currentTime, v, IsSimulation);
            sensors.Add(data);

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
