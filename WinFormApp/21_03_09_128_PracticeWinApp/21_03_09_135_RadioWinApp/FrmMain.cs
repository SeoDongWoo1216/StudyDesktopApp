using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_135_RadioWinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            // 라디오 박스 예제
            // 라디오 박스를 추가할때 그룹박스로 묶어줄 수 있다(체크를 따로 할 수 있음)
            string result = string.Empty;

            //if (RdbKorea.Checked == false && RdbChina.Checked == false &&
            //    RdbJapan.Checked == false && RdbOthers.Checked == false)
            //{
            //    MessageBox.Show("국가를 선택하세요");
            //    return;
            //}

            //if (RdbMale.Checked == false && RdbFemale.Checked == false)
            //{
            //    MessageBox.Show("성별을 선택하세요");
            //    return;
            //}


            if (RdbKorea.Checked)
                result += "국적: 대한민국\n";
            else if (RdbChina.Checked)
                result += "국적: 중국\n";
            else if (RdbJapan.Checked)
                result += "국적: 일본\n";
            else if (RdbOthers.Checked)
                result += "국적: 그 외의 국가\n";
            else
            {
                MessageBox.Show("국가를 선택하세요");
                return;
            }


            if (RdbMale.Checked)
                result += "성별: 남성";
            else if (RdbFemale.Checked)
                result += "성별: 여성";
            else
            {
                MessageBox.Show("성별을 선택하세요");
                return;
            }

            MessageBox.Show(result, "결과");
        }
    }
}
