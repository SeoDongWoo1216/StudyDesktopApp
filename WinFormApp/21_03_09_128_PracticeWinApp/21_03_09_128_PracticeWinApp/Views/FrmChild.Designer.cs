﻿
namespace _21_03_09_128_PracticeWinApp.Views
{
    partial class FrmChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnQuestion
            // 
            this.BtnQuestion.Location = new System.Drawing.Point(115, 47);
            this.BtnQuestion.Name = "BtnQuestion";
            this.BtnQuestion.Size = new System.Drawing.Size(121, 39);
            this.BtnQuestion.TabIndex = 0;
            this.BtnQuestion.Text = "질문";
            this.BtnQuestion.UseVisualStyleBackColor = true;
            this.BtnQuestion.Click += new System.EventHandler(this.BtnQuestion_Click);
            // 
            // FrmChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 184);
            this.Controls.Add(this.BtnQuestion);
            this.Name = "FrmChild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "자식폼";
            this.Load += new System.EventHandler(this.FrmChild_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnQuestion;
    }
}