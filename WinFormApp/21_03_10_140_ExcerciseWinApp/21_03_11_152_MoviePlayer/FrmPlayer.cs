using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_11_152_MoviePlayer
{
    public partial class FrmPlayer : Form
    {
        public FrmPlayer()
        {
            InitializeComponent();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if(DlgSelectFile.ShowDialog() == DialogResult.OK)
            {
                MyPlayer.URL = DlgSelectFile.FileName;

            }
        }
    }
}
