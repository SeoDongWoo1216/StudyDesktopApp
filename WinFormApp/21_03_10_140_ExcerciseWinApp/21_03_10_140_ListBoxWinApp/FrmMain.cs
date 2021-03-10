using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_10_140_ListBoxWinApp
{
    // ListBox 예제
    // ListBox에 데이터를 추가하는 방법은 3가지가 있다.
    // 1. ListBox 속성창의 item항목에서 (컬렉션)을 직접 입력하는 방법
    // 2. Item.Add() 메서드를 이용해서 직접 코드를 작성하는 방법
    // 3. List<T>의 객체를 바인딩 하는 방법

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 2. Item.Add() 메서드를 이용해서 직접 코드를 작성하는 방법
            // 살기 좋은 도시 초기화, (가장 기본적인 리스트박스 추가)
            LsbGoodCity.Items.Add("오스트리아, 빈");
            LsbGoodCity.Items.Add("호주, 맬버른");
            LsbGoodCity.Items.Add("일본, 오사카");
            LsbGoodCity.Items.Add("캐나다, 캘거리");
            LsbGoodCity.Items.Add("호주, 시드니");
            LsbGoodCity.Items.Add("캐나다, 벤쿠버");
            LsbGoodCity.Items.Add("덴마크, 코펜하겐");
            LsbGoodCity.Items.Add("일본, 도쿄"); 
            LsbGoodCity.Items.Add("캐나다, 토론토");
            LsbGoodCity.Items.Add("호주, 애들레이드");

            // 3. List<T>의 객체를 바인딩 하는 방법
            // 데이터 바인딩 방식 중 하나의 방법이다.
            List<string> lstContry = new List<string>()
            {
                "미국", "러시아", "중국", "영국", "독일", "프랑스", 
                "일본", "이스라엘", "사우디아라비아", "UAE"
            };
            LsbHappyContry.DataSource = lstContry;
            LsbHappyContry.SelectedIndex = -1; // 리스트로 넣는 값에대한 리스트박스 초기화

        }

        private void LsbGDPContries_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            이벤트가 뭘 받을지모르니 일단 object로 빡싱된 상태임.(그래서 오브젝트의 메서드밖에 못씀)
            따라서 원래 형으로 언빡싱해서 사용해야할 메서드를 사용하면된다.
            형변환할때는 값은(), 참조는 as를 사용하면됨.
            */

            // 선택된 값 확인
            // MessageBox.Show(sender.ToString());
            var selItem = sender as ListBox;   // sender를 listBox로 언빡싱(참조형변환)
            // MessageBox.Show($"{selItem.SelectedIndex} / {selItem.SelectedItem}");

            TxtIndexGDP.Text = selItem.SelectedIndex.ToString();
            //TxtItemGDP.Text = selItem.SelectedItem.ToString();
            TxtItemGDP.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();


        }

        private void LsbGoodCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = sender as ListBox;
            TxtIndexGood.Text = selItem.SelectedIndex.ToString();
            //TxtItemGood.Text = selItem.SelectedItem.ToString();
            TxtItemGood.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();

        }

        private void LsbHappyContry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = sender as ListBox; 
            TxtIndexHappy.Text = selItem.SelectedIndex.ToString();
            TxtItemHappy.Text = selItem.SelectedItem == null ? string.Empty : selItem.SelectedItem.ToString();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            LsbGDPContries.SelectedIndex = LsbGoodCity.SelectedIndex = LsbHappyContry.SelectedIndex = -1;
        }
    }
}
