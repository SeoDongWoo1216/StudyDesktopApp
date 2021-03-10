using System;
using System.Windows.Forms;

namespace _21_03_10_141_RestaurantSelApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // AddRange로 배열을 만들어서 추가
            CboRestaurant.Items.AddRange(new string[] { 
             "히노아지", "스시야마", "퍼지네이블", "새마을 식당", "홍콩반점", "롤링파스타"
            });
        }

        private void CboRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = sender as ComboBox;  // 오브젝트형인 sender를 콤보박스로 언빡싱
            LblResult.Text = $"이번주 모임 장소 : {selItem.SelectedItem}";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CboRestaurant.Items.Add(CboRestaurant.Text);
            LblResult.Text = $"{CboRestaurant.Text} 아이템 추가";
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if(CboRestaurant.SelectedIndex > -1)  // 식당이 있을경우(인덱스는 첫번째값이 0이므로)
            {
                LblResult.Text = $"{CboRestaurant.SelectedItem} 아이템 삭제";
                CboRestaurant.Items.Remove(CboRestaurant.SelectedItem);
            }
            else if (CboRestaurant.SelectedIndex == -1)
            {
                LblResult.Text = $"삭제할 식당이 없습니다.";
            }
        }
    }
}
