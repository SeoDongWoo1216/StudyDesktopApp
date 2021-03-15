using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// 버튼누르면 그래프가 합쳐지고, 다른 버튼누르면 그래프가 쪼개지는 프로그램을 구현해보자.
// 버튼.Enabled 메서드를통해 나눠져있는상태에서 나누기 버튼을 클릭못하게 T/F로 지정해주었다.
namespace _210315_170_WinChartApp
{
    public partial class FrmSub : Form
    {
        public FrmSub()
        {
            InitializeComponent();
        }

        private void FrmSub_Load(object sender, EventArgs e)
        {
            this.Text = "중간고사 성적2";

            ChtScore.Titles.Add("중간고사 성적");
            ChtScore.Series.Add("Series2");   // 새로운 데이터 시리즈 추가
            ChtScore.Series["Series1"].LegendText = "수학";
            ChtScore.Series["Series2"].LegendText = "영어";

            ChtScore.ChartAreas.Add("ChartArea2");
            ChtScore.Series["Series2"].ChartArea = "ChartArea2";

            Random rand = new Random();
            for (int i = 0; i <= 10; i++)
            {
                ChtScore.Series[0].Points.AddXY(i, rand.Next(10, 100));   // 수학값
                ChtScore.Series[1].Points.AddXY(i, rand.Next(10, 100));   // 영어값
            }

            // 차트타입을 지정해서 종류에따라 차트 출력을 지정할수도 있다.
            ChtScore.Series[0].ChartType = SeriesChartType.Line;
            ChtScore.Series[0].ChartType = SeriesChartType.Area;

            BtnSplit.Enabled = false;

        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            ChtScore.ChartAreas.RemoveAt(ChtScore.ChartAreas.IndexOf("ChartArea2"));
            ChtScore.Series["Series2"].ChartArea = "ChartArea1";

            BtnMerge.Enabled = false;
            BtnSplit.Enabled = true;
        }

        private void BtnSplit_Click(object sender, EventArgs e)
        {
            ChtScore.ChartAreas.Add("ChartArea2");
            ChtScore.Series["Series2"].ChartArea = "ChartArea2";


            BtnMerge.Enabled = true; 
            BtnSplit.Enabled = false;
        }
    }
}
