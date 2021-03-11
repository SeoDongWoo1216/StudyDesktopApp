using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_11_155_SimpleGraphicEditor
{
    enum DrawMode
    {
        LINE,
        RECTANGLE,
        CIRCLE,
        CURVED_LINE
    }
    public partial class FrmMain : Form
    {
        private DrawMode mode;
        private Graphics g;
        private Pen pen;
        private Pen eraser; // 지울때도 Pen 객체를 사용
        
        Point StartP;  // 시작점
        Point endP;    // 끝점
        Point currP;   // 현재 위치
        Point prevP;    // 이전 위치

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StsCurrent.Text = "";

            g = CreateGraphics();
            pen = new Pen(Color.Black, 2);
            StsCurrent.Text = "Line Mode";
            mode = DrawMode.LINE;
            this.BackColor = Color.White;
            this.eraser = new Pen(Color.White, 2);
        }

        private void TlmLine_Click(object sender, EventArgs e)
        {
            this.mode = DrawMode.LINE;
            StsCurrent.Text = "Line Mode";
        }

        private void TlmRectangle_Click(object sender, EventArgs e)
        {
            this.mode = DrawMode.RECTANGLE;
            StsCurrent.Text = "RECTANGLE Mode";
        }

        private void TlmCircle_Click(object sender, EventArgs e)
        {
            this.mode = DrawMode.CIRCLE;
            StsCurrent.Text = "CIRCLE Mode";
        }

        private void TlmCuvedLine_Click(object sender, EventArgs e)
        {
            this.mode = DrawMode.CURVED_LINE;
            StsCurrent.Text = "CURVED_Line Mode";
        }

        private void TlmColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                this.pen.Color = dialog.Color;
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.StartP = new Point(e.X, e.Y);
            this.currP = this.prevP = this.StartP;
        }

        // 마우스 옮길때마다 발생하는 이벤트
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;    // 마우스버튼이 왼쪽클릭이아니면 리턴

            this.prevP = this.currP;
            this.currP = new Point(e.X, e.Y);

            switch (this.mode)
            {
                case DrawMode.LINE:
                    g.DrawLine(this.eraser, this.StartP, this.prevP);
                    g.DrawLine(this.pen, this.StartP, this.currP);
                    break;
                case DrawMode.RECTANGLE:
                    g.DrawRectangle(this.eraser, 
                        new Rectangle(StartP, new Size(prevP.X - StartP.X, prevP.Y - StartP.Y)));
                    g.DrawRectangle(this.pen,
                       new Rectangle(StartP, new Size(currP.X - StartP.X, currP.Y - StartP.Y)));
                    break;
                case DrawMode.CIRCLE:
                    g.DrawEllipse(this.eraser, 
                        new Rectangle(StartP, new Size(prevP.X - StartP.X, prevP.Y - StartP.Y)));
                    g.DrawEllipse(this.pen,
                        new Rectangle(StartP, new Size(currP.X - StartP.X, currP.Y - StartP.Y)));
                    break;
                case DrawMode.CURVED_LINE:
                    g.DrawLine(pen, prevP, currP);
                    break;
                default:
                    break;
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            this.endP = new Point(e.X, e.Y);
            switch (this.mode)
            {
                case DrawMode.LINE:
                    g.DrawLine(this.pen, this.StartP, this.endP);
                    break;
                case DrawMode.RECTANGLE:
                    g.DrawRectangle(this.pen,
                    new Rectangle(StartP, new Size(endP.X - StartP.X, endP.Y - StartP.Y)));
                    break;
                case DrawMode.CIRCLE:
                    g.DrawEllipse(this.pen,
                       new Rectangle(StartP, new Size(endP.X - StartP.X, endP.Y - StartP.Y)));
                    break;
                case DrawMode.CURVED_LINE:
                    break;
                default:
                    break;
            }
        }
    }
}
