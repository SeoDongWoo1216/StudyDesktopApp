using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_136_LoginApp
{
    // 로그인 창 만들기
    // 비밀번호의 텍스트박스는 PasswordChar 속성에 ● 을 설정해주면 텍스트박스에 입력되는 값들이 ●로 나온다.
    // 로그인 버튼에는 이미지를 따로 다운받아서 삽입했다.
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtUserId.Text == "admin" && TxtPassword.Text == "12345")
                TxtResult.Text = "로그인 성공";
            else
                TxtResult.Text = "로그인 실패";


        }
    }
}
