﻿
namespace _21_03_09_135_RadioWinApp
{
    partial class FrmMain
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
            this.BtnResult = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdbOthers = new System.Windows.Forms.RadioButton();
            this.RdbJapan = new System.Windows.Forms.RadioButton();
            this.RdbChina = new System.Windows.Forms.RadioButton();
            this.RdbKorea = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdbFemale = new System.Windows.Forms.RadioButton();
            this.RdbMale = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnResult
            // 
            this.BtnResult.Location = new System.Drawing.Point(222, 135);
            this.BtnResult.Name = "BtnResult";
            this.BtnResult.Size = new System.Drawing.Size(89, 42);
            this.BtnResult.TabIndex = 6;
            this.BtnResult.Text = "결과";
            this.BtnResult.UseVisualStyleBackColor = true;
            this.BtnResult.Click += new System.EventHandler(this.BtnResult_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdbOthers);
            this.groupBox1.Controls.Add(this.RdbJapan);
            this.groupBox1.Controls.Add(this.RdbChina);
            this.groupBox1.Controls.Add(this.RdbKorea);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 159);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "국가";
            // 
            // RdbOthers
            // 
            this.RdbOthers.AutoSize = true;
            this.RdbOthers.Location = new System.Drawing.Point(15, 131);
            this.RdbOthers.Name = "RdbOthers";
            this.RdbOthers.Size = new System.Drawing.Size(79, 16);
            this.RdbOthers.TabIndex = 7;
            this.RdbOthers.TabStop = true;
            this.RdbOthers.Text = "그 외 국가";
            this.RdbOthers.UseVisualStyleBackColor = true;
            // 
            // RdbJapan
            // 
            this.RdbJapan.AutoSize = true;
            this.RdbJapan.Location = new System.Drawing.Point(15, 96);
            this.RdbJapan.Name = "RdbJapan";
            this.RdbJapan.Size = new System.Drawing.Size(47, 16);
            this.RdbJapan.TabIndex = 6;
            this.RdbJapan.TabStop = true;
            this.RdbJapan.Text = "일본";
            this.RdbJapan.UseVisualStyleBackColor = true;
            // 
            // RdbChina
            // 
            this.RdbChina.AutoSize = true;
            this.RdbChina.Location = new System.Drawing.Point(15, 61);
            this.RdbChina.Name = "RdbChina";
            this.RdbChina.Size = new System.Drawing.Size(47, 16);
            this.RdbChina.TabIndex = 5;
            this.RdbChina.TabStop = true;
            this.RdbChina.Text = "중국";
            this.RdbChina.UseVisualStyleBackColor = true;
            // 
            // RdbKorea
            // 
            this.RdbKorea.AutoSize = true;
            this.RdbKorea.Location = new System.Drawing.Point(15, 26);
            this.RdbKorea.Name = "RdbKorea";
            this.RdbKorea.Size = new System.Drawing.Size(71, 16);
            this.RdbKorea.TabIndex = 4;
            this.RdbKorea.TabStop = true;
            this.RdbKorea.Text = "대한민국";
            this.RdbKorea.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdbFemale);
            this.groupBox2.Controls.Add(this.RdbMale);
            this.groupBox2.Location = new System.Drawing.Point(193, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 60);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "성별";
            // 
            // RdbFemale
            // 
            this.RdbFemale.AutoSize = true;
            this.RdbFemale.Location = new System.Drawing.Point(63, 24);
            this.RdbFemale.Name = "RdbFemale";
            this.RdbFemale.Size = new System.Drawing.Size(35, 16);
            this.RdbFemale.TabIndex = 7;
            this.RdbFemale.TabStop = true;
            this.RdbFemale.Text = "여";
            this.RdbFemale.UseVisualStyleBackColor = true;
            // 
            // RdbMale
            // 
            this.RdbMale.AutoSize = true;
            this.RdbMale.Location = new System.Drawing.Point(13, 24);
            this.RdbMale.Name = "RdbMale";
            this.RdbMale.Size = new System.Drawing.Size(35, 16);
            this.RdbMale.TabIndex = 6;
            this.RdbMale.TabStop = true;
            this.RdbMale.Text = "남";
            this.RdbMale.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 199);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnResult);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RadioButton And GroupBox";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdbOthers;
        private System.Windows.Forms.RadioButton RdbJapan;
        private System.Windows.Forms.RadioButton RdbChina;
        private System.Windows.Forms.RadioButton RdbKorea;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdbFemale;
        private System.Windows.Forms.RadioButton RdbMale;
    }
}

