using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_133_FlagWinApp
{

   

    public partial class Form1 : Form
    {
        // flag를 이용한 이벤트 처리

        private bool IsHello = false;   // flag 상태를 저장하는 값
        
        public Form1()
        {
            InitializeComponent();

            IsHello = true;   // 아침임. (초기화)
        }

        private void BtnGreeting_Click(object sender, EventArgs e)
        {
            if(IsHello == true)
            {
                LblGreeting.Text = "굳모닝";
                IsHello = false;
                BtnGreeting.Text = "저녁인사";
            }
            else if(IsHello == false)
            {
                LblGreeting.Text = "Good Bye~~!";
                IsHello = true;
                BtnGreeting.Text = "아침인사";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblGreeting.Text = string.Empty;
        }
    }
}
