using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_10_142_TravelWishApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LsbWishCountry.Items.AddRange(new string[] {
                "오스트리아, 빈", 
                "호주, 멜버른", 
                "일본, 오사카", 
                "캐나다, 캘거리",
                "호주, 시드니", 
                "캐나다, 벤쿠버", 
                "일본, 도쿄", 
                "캐나다, 토론토",
                "덴마크, 코펜하겐",
                "호주, 애들레이드", 
                "대한민국, 부산"
            });

            LsbResult.SelectionMode = SelectionMode.MultiExtended; // 여러개를 선택할 수 있는 리스트박스로 만들어줌.

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in LsbWishCountry.CheckedItems)
            {
                LsbResult.Items.Add(item);
            }
        }

        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            LsbResult.Items.Clear();

            foreach (var item in LsbWishCountry.Items)
            {
                LsbResult.Items.Add(item);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            List<string> lstRemove = new List<string>();

            foreach (string item in LsbResult.SelectedItems)  // 지울 애들을 저장
            {
                lstRemove.Add(item);
            }

            foreach (string city in lstRemove)
            {
                LsbResult.Items.Remove(city);
            }
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            LsbResult.Items.Clear();

        }
    }
}
