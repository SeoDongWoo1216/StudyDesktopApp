using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_09_139_ColorChangeApp
{
    // 트랙바를 이용해 RGB 컬러를 조정해보자.
    // 각 스크롤의 이벤트를 만들어주지만, 하나의 메서드로 통일해서 지정해줄 수 있다.
    // 트랙바 속성의 이벤트를 트랙바 스크롤 메서드로 지정해주기.

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            TxtRed.Text = TrbRed.Value.ToString();
            TxtGreen.Text = TrbGreen.Value.ToString();
            TxtBlue.Text = TrbBlue.Value.ToString();

            PnlResult.BackColor = Color.FromArgb(TrbRed.Value, TrbGreen.Value, TrbBlue.Value);
        }



        // 전에는 클래스를 생성해서 new로 객체를 만들어서 사용했었는데,
        // openfiledialog 컴포넌트를 통해 그 과정을 생략하고 바로 호출할 수도 있다.
        // 이것은 saveFileDialog, colorDialog 에도 적용할 수 있다.
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
