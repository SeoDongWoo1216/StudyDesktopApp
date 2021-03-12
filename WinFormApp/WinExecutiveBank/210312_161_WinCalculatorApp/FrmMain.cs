using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _210312_161_WinCalculatorApp
{
    public partial class FrmMain : Form
    {
        public double Saved { get; set; }   // 연산자 이전에 숫자를 저장할 프로퍼티
        public double Memory { get; set; }
        public bool MemFlag { get; set; }
        public bool PercentFlag { get; set; }
        public char Op { get; set; }
        public bool OpFlag { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void TxtExp_Load(object sender, EventArgs e)
        {
            TxtExp.Text = TxtResult.Text = "";
            BtnMc.Enabled = BtnMr.Enabled = false;
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            var Btn = sender as Button;  // sender에서 button으로 형변환 -> 오브젝트형 sender는 메서드가 별로없는데 형변환을 통해 버튼 메서드를 사용할 수 있음
            var str = Btn.Text;  // 0 ~ 9

            TxtResult.Text += str;
        }

        private void BtnOp_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Saved = double.Parse(TxtResult.Text);  // 
            TxtExp.Text += $"{TxtResult.Text} {btn.Text} ";
            Op = btn.Text[0];
            OpFlag = true;

            TxtResult.Text = "";
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            var value = double.Parse(TxtResult.Text);

            switch (Op)
            {
                case '+':
                    TxtResult.Text = (Saved + value).ToString();
                    break;
                case '-':
                    TxtResult.Text = (Saved - value).ToString();
                    break;
                case '×':
                    TxtResult.Text = (Saved * value).ToString();
                    break;
                case '÷':
                    TxtResult.Text = (Saved / value).ToString();
                    break;
                    

            }
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtResult.Text = TxtExp.Text = "";
            Saved = 0;
            Op = '\0';
            OpFlag = false;
            PercentFlag = false;
        }

        private void BtnMc_Click(object sender, EventArgs e)
        {
            TxtResult.Text = "";
            Memory = 0;
            BtnMr.Enabled = BtnMr.Enabled = false;
        }

        private void BtnMr_Click(object sender, EventArgs e)
        {
            TxtResult.Text = Memory.ToString();

        }

        private void BtnMplus_Click(object sender, EventArgs e)
        {

        }

        private void BtnMminus_Click(object sender, EventArgs e)
        {

        }

        private void BtnMs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtResult.Text)) return;

            Memory = double.Parse(TxtResult.Text);
            BtnMc.Enabled = BtnMc.Enabled = true;
            MemFlag = true;
        }
    }
}
