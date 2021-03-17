using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace _210316_300_BookRentalShopApp
{
    public partial class FrmMain : MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
       
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var EndYes = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (EndYes == DialogResult.Yes)
            {
                e.Cancel = false;  // Yes 누르면 프로그램 종료
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true; // 프로그램 종료 안함.
            }
        }
        private void MnuDiv_Click(object sender, EventArgs e)
        {
            FrmDivCode frm = new FrmDivCode();
            frm.Dock = DockStyle.Fill;
            frm.MdiParent = this;  // this는 FrmMain이고 frm구분코드의 부모로 설정.
            frm.Show();
            frm.Width = this.ClientSize.Width - 10;
            frm.Height = this.Height - menuStrip1.Height;
            frm.WindowState = FormWindowState.Maximized;
        }

        private void MnuMember_Click(object sender, EventArgs e)
        {
            FrmMember frm = new FrmMember();
            frm.Dock = DockStyle.Fill;
            frm.MdiParent = this;  // this는 FrmMain이고 frm구분코드의 부모로 설정.
            frm.Show();
            frm.Width = this.ClientSize.Width - 10;
            frm.Height = this.Height - menuStrip1.Height;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
