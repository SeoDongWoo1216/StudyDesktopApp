using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_138_MaskedTextApp
{
    // MaskedTextBox 예제

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            result = $"입사일 : {TxtHiredDate.Text}\n";
            result += $"우편 번호 : {TxtZipCode.Text}\n";
            result += $"주소 : {TxtAddress.Text.Trim()}\n";   // Trim() 으로 앞뒤 공백 제거
            result += $"휴대폰 번호 : {TxtMobile.Text}\n";
            result += $"주민등록번호 : {TxtRegisterNumber.Text}\n";
            result += $"이메일 : {TxtEmail.Text.Trim()}\n";

            MessageBox.Show(result, "개인 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
