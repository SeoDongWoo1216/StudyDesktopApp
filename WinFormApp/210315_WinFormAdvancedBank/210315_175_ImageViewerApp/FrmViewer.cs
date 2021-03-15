using System;
using System.Drawing;
using System.Windows.Forms;

namespace _210315_175_ImageViewerApp
{
    public partial class FrmViewer : Form
    {
        public FrmViewer()
        {
            InitializeComponent();
        }


        // jpg나 png 이미지 파일을 직접 선택해서 띄우기
        private void MnuSelectImage_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Filter = "jgh 파일(*.jpg)|*.jpg|png 파일(*.png)|*.png|모든 파일(*.*)|*.*";
            DlgOpenImage.Title = "이미지 열기";
            if(DlgOpenImage.ShowDialog() == DialogResult.OK)
            {
                PicMain.Image = new Bitmap(DlgOpenImage.FileName);
            }
            PicMain.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /*
        Normal​: 이미지를 그대로 보여준다.컨트롤이 이미지보다 작으면 이미지가 잘려서 보인다.
        StretchImage: 이미지를 확대 또는 축소해서 컨트롤에 꽉 채운다.이미지의 가로 세로 비율이 찌그러질 수 있다.
        Zoom: 이미지를 확대 또는 축소해서 컨트롤에 꽉 채운다.이미지의 가로 세로 비율을 유지한다.
        AutoSize: 컨트롤의 크기가 이미지 크기로 자동으로 조정된다.
        CenterImage: 이미지의 중앙을 기준으로 출력한다. 컨트롤이 이미지보다 작으면 이미지의 중앙 부분만 보인다.
        */
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            PicMain.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PicMain.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicMain.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicMain.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicMain.SizeMode = PictureBoxSizeMode.Zoom;

        }
    }
}
