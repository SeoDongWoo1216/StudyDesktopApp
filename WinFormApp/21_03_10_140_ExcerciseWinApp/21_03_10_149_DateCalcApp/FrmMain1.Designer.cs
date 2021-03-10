
namespace _21_03_10_149_DateCalcApp
{
    partial class FrmMain1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DTPBirthDay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.TxtYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "생일을 선택하세요";
            // 
            // DTPBirthDay
            // 
            this.DTPBirthDay.Location = new System.Drawing.Point(16, 68);
            this.DTPBirthDay.Name = "DTPBirthDay";
            this.DTPBirthDay.Size = new System.Drawing.Size(200, 21);
            this.DTPBirthDay.TabIndex = 1;
            this.DTPBirthDay.ValueChanged += new System.EventHandler(this.DTPBirthDay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "생일로부터 오늘까지...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "일이 지났습니다.";
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(149, 115);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(132, 21);
            this.TxtResult.TabIndex = 4;
            // 
            // TxtYear
            // 
            this.TxtYear.Location = new System.Drawing.Point(149, 144);
            this.TxtYear.Name = "TxtYear";
            this.TxtYear.Size = new System.Drawing.Size(132, 21);
            this.TxtYear.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "세 입니다.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "당신의 연령은 만";
            // 
            // FrmMain1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 177);
            this.Controls.Add(this.TxtYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTPBirthDay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "날짜계산기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPBirthDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.TextBox TxtYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

