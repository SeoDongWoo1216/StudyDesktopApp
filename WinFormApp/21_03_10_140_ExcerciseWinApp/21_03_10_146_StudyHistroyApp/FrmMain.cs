using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_10_146_StudyHistroyApp
{
    // 트리뷰와 픽쳐박스를 이용한 역사 공부 프로그램
    // ScrollBars : Vertical
    // Multiline : True
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode("영국 왕실");

            TreeNode stuart = new TreeNode("스튜어트 가");
            stuart.Nodes.Add("ANN1", "앤(1707 ~ 1714)");   // 텍스트가 바뀔수도있어서(띄어쓰기, 오타 등) 변수화해서 조건문에 넣는게 편함.

            TreeNode hanover = new TreeNode("하노버 가");
            hanover.Nodes.Add("GRG1", "조지 1세(1714 ~ 1727)");  
            hanover.Nodes.Add("GRG2", "조지 2세(1727 ~ 1760)");
            hanover.Nodes.Add("GRG3", "조지 3세(1760 ~ 1820)");
            hanover.Nodes.Add("GRG4", "조지 4세(1820 ~ 1830)");
            hanover.Nodes.Add("WRM4", "윌리엄 4세(1830 ~ 1837)");
            hanover.Nodes.Add("BTR1", "빅토리아(1837 ~ 1901)");

            root.Nodes.Add(stuart);
            root.Nodes.Add(hanover);

            TrVList.Nodes.Add(root);
            TrVList.ExpandAll();  // 모든 노드가 확장된 상태로 나옴
        }

        private void TrVList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PcbPhoto.Image = null;  // 픽쳐박스 초기화
            TxtDescription.Text = string.Empty;
            //MessageBox.Show(e.Node.ToString());
            if (e.Node.Name == "ANN1") 
            {
                PcbPhoto.Image = Bitmap.FromFile("./Image/Anne.jpg");   // 이미지클릭해서 속성의 출력 디렉터리 복사를 항상 허용으로 바꿔줘야함.
                TxtDescription.Text = "메리 2세는 1694년 이미 사망했고, " +
                    "1702년에 단독 통치를 계속하고 있던 윌리엄 3세가 죽으면서 앤이 잉글랜드, " +
                    "스코틀랜드, 아일랜드 여왕으로 즉위했다. 즉위식 때 \"나의 모든 정성을 오로지" +
                    "영국을 위해 바치겠노라\"고 하여 국민의 갈채를 받았다. " +
                    "부군이었던 덴마크의 조지는 여왕의 배우자로서의 지위가 주어져서 통치자로서의 " +
                    "군림은 실시하지 않았다. ";
            }

            else if (e.Node.Name == "GRG1")
            {
                PcbPhoto.Image = Bitmap.FromFile("./Image/King_George_I.jpg");
                TxtDescription.Text = "1701년 제정된 영국 왕위계승법으로 제임스 1세의 손자인 " +
                    "어머니에 이어 영국 왕위 계승 3순위가 됐다. 그보다 앤 여왕에 더 가까운 친척들도 " +
                    "50인 이상 있었으나 영국 왕위계승법은 카톨릭 신자의 왕위 계승을 원천 금지하고 있어," +
                    " 조지 1세와 그 어머니가 앤 여왕의 가장 가까운 신교도 혈육으로서 왕위 계승자에 " +
                    "이름을 올렸다.";
            }

            else
            {
                TxtDescription.Text = string.Empty;
            }
        }

    }
}
