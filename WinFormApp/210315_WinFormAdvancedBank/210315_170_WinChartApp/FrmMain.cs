using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


// 버튼을 누를때마다 랜덤한 숫자가 들어가는 차트를 구현해보자(랜덤수 random rand 사용)

namespace _210315_170_WinChartApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnRegen_Click(object sender, EventArgs e)
        {
            GenNewChart();  // 차트 그리는 메서드
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ChtScore.Titles.Add("중간고사 성적");
            this.Text = "중간고사 성적";
            GenNewChart();  
        }

        // 차트 그리는 메서드
        private void GenNewChart()
        {
            ChtScore.Series["Score"].Points.Clear();   // 메서드 실행될때마다 차트 데이터를 삭제해줌.(데이터가 누적되는것을 막아줌)
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                // series는 차트에 표시되는 데이터. (컬렉션으로 이름과 종류를 지정할 수 있음)
                // rand를 통해 10~100 값을 랜덤으로 넣어줌.
                ChtScore.Series["Score"].Points.Add(rand.Next(10, 100));   
            }
            ChtScore.Series["Score"].LegendText = "수학";
            ChtScore.Series["Score"].ChartType = SeriesChartType.Line;  // 기본값은 막대 그래프임.
        }
    }
}
