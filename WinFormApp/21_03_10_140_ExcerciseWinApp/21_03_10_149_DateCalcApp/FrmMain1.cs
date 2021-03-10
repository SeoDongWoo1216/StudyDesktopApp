using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_10_149_DateCalcApp
{
    public partial class FrmMain1 : Form
    {
        public FrmMain1()
        {
            InitializeComponent();
        }

        private void DTPBirthDay_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime birthday = DTPBirthDay.Value;

            TxtResult.Text = $"{today.Subtract(birthday).TotalDays: #,###}";   // Subtract로 지정된 날짜와 시간을 뺌.
            TxtYear.Text = (today.Subtract(birthday).TotalDays / 365).ToString("0");
        }
    }
}
