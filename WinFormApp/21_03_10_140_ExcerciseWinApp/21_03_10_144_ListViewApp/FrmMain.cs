using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_10_144_ListViewApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        // 144 ~ 145 리스트뷰 예제
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ListViewItem itemSwitch = new ListViewItem("Nintendo Switch", 0);
            itemSwitch.SubItems.Add("600,000");
            itemSwitch.SubItems.Add("1");
            itemSwitch.SubItems.Add("600,000");

            ListViewItem itemDs =     new ListViewItem("Nintendo DS", 1);
            itemDs.SubItems.Add("300,000");
            itemDs.SubItems.Add("10");
            itemDs.SubItems.Add("3,000,000");

            ListViewItem itemPs4 =    new ListViewItem("Play Station 4", 2);
            itemPs4.SubItems.Add("400,000");
            itemPs4.SubItems.Add("20");
            itemPs4.SubItems.Add("8,000,000");

            ListViewItem itemWii =    new ListViewItem("Nintendo Wii", 3);
            itemWii.SubItems.Add("200,000");
            itemWii.SubItems.Add("30");
            itemWii.SubItems.Add("6,000,000");

            ListViewItem itemXbox =   new ListViewItem("XBox 360", 4);
            itemXbox.SubItems.Add("600,000");
            itemXbox.SubItems.Add("2");
            itemXbox.SubItems.Add("1,200,000");


            LsvProducts.Items.AddRange(new ListViewItem[]{ itemSwitch, itemDs, itemPs4, itemWii, itemXbox });
        }

        private void RdbDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbDetails.Checked) LsvProducts.View = View.Details;
        }

        private void RdbList_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbList.Checked) LsvProducts.View = View.List;
        }

        private void RdbSmallIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbSmallIcon.Checked) LsvProducts.View = View.SmallIcon;
        }

        private void RdbLargeIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbLargeIcon.Checked) LsvProducts.View = View.LargeIcon;
        }

        private void LsvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSelected.Text = string.Empty;

            var Selected = LsvProducts.SelectedItems;

            foreach (ListViewItem item in Selected)
            {
                for (int i = 0; i < 4; i++)  // 컬럼개수가 4개니까 (0,1,2,3) 4에 등호가 들어가면 안됨.(0,1,2,3,4 => 5개)
                {
                    TxtSelected.Text += item.SubItems[i].Text + "      ";
                }
            }

        }
    }
}
