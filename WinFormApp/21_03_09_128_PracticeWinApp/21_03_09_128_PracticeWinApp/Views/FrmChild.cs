using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_128_PracticeWinApp.Views
{
    public partial class FrmChild : Form
    {
        public FrmChild()
        {
            InitializeComponent();
        }

        private void FrmChild_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(300, 300);
            this.Text = "자식폼";

            this.CenterToParent();
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("정답입니까?", "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //// 메세지박스.show는 DialogResult를 반환함
            //MessageBox.Show(result.ToString());


            // 보편적으로쓰는 메세지박스 응답요청
            if(MessageBox.Show("정답입니까?", "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                MessageBox.Show("정답이랍니다");
            }
            else
            {
                MessageBox.Show("틀렸다네요");
            }
        }
    }
}
