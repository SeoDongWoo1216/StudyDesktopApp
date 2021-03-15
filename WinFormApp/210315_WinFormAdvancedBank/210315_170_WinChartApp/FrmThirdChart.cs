using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _210315_170_WinChartApp
{
    public partial class FrmThirdChart : Form
    {
        public FrmThirdChart()
        {
            InitializeComponent();
        }

        private void FrmThirdChart_Load(object sender, EventArgs e)
        {
            this.Text = "Graph Chart";
        }

        private void FrmThirdChart_Paint(object sender, PaintEventArgs e)
        {
            ChtMain.ChartAreas[0].BackColor = Color.Black;

            // ChartArea x, y 축 설정
            ChtMain.ChartAreas[0].AxisX.Minimum = -20;
            ChtMain.ChartAreas[0].AxisX.Maximum = 20;
            ChtMain.ChartAreas[0].AxisX.Interval = 2;
            ChtMain.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            ChtMain.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            ChtMain.ChartAreas[0].AxisY.Minimum = -2;
            ChtMain.ChartAreas[0].AxisY.Maximum = 2;
            ChtMain.ChartAreas[0].AxisY.Interval = 0.5;
            ChtMain.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            ChtMain.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Series 설정(sin)
            ChtMain.Series[0].ChartType = SeriesChartType.Line;
            ChtMain.Series[0].Color = Color.LightGreen;
            ChtMain.Series[0].BorderWidth = 2;
            ChtMain.Series[0].LegendText = "sin(x)/x";

            // Series 추가, 설정(cos)
            if(ChtMain.Series.Count == 1)
            {
                ChtMain.Series.Add("Cos");
                ChtMain.Series[1].ChartType = SeriesChartType.Line;
                ChtMain.Series[1].Color = Color.LightGreen;
                ChtMain.Series[1].BorderWidth = 2;
                ChtMain.Series[1].LegendText = "cos(x)/x";
            }

            for(double x = -20; x < 20; x += 0.1)
            {
                double y = Math.Sin(x) / x;
                ChtMain.Series[0].Points.AddXY(x, y);
                y = Math.Cos(x) / x;
                ChtMain.Series[1].Points.AddXY(x, y);
            }
        }
    }
}
