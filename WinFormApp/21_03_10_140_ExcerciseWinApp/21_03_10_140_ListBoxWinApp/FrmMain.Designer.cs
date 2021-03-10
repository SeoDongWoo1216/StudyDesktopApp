
namespace _21_03_10_140_ListBoxWinApp
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
            this.LsbGDPContries = new System.Windows.Forms.ListBox();
            this.LsbGoodCity = new System.Windows.Forms.ListBox();
            this.LsbHappyContry = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtIndexGDP = new System.Windows.Forms.TextBox();
            this.TxtItemGDP = new System.Windows.Forms.TextBox();
            this.TxtItemGood = new System.Windows.Forms.TextBox();
            this.TxtIndexGood = new System.Windows.Forms.TextBox();
            this.TxtItemHappy = new System.Windows.Forms.TextBox();
            this.TxtIndexHappy = new System.Windows.Forms.TextBox();
            this.BtnInit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LsbGDPContries
            // 
            this.LsbGDPContries.FormattingEnabled = true;
            this.LsbGDPContries.ItemHeight = 12;
            this.LsbGDPContries.Items.AddRange(new object[] {
            "미국",
            "러시아",
            "중국",
            "영국",
            "독일",
            "프랑스",
            "일본",
            "이스라엘",
            "사우디아라비아",
            "UAE",
            "한국"});
            this.LsbGDPContries.Location = new System.Drawing.Point(118, 41);
            this.LsbGDPContries.Name = "LsbGDPContries";
            this.LsbGDPContries.Size = new System.Drawing.Size(138, 184);
            this.LsbGDPContries.TabIndex = 0;
            this.LsbGDPContries.SelectedIndexChanged += new System.EventHandler(this.LsbGDPContries_SelectedIndexChanged);
            // 
            // LsbGoodCity
            // 
            this.LsbGoodCity.FormattingEnabled = true;
            this.LsbGoodCity.ItemHeight = 12;
            this.LsbGoodCity.Location = new System.Drawing.Point(290, 41);
            this.LsbGoodCity.Name = "LsbGoodCity";
            this.LsbGoodCity.Size = new System.Drawing.Size(138, 184);
            this.LsbGoodCity.TabIndex = 1;
            this.LsbGoodCity.SelectedIndexChanged += new System.EventHandler(this.LsbGoodCity_SelectedIndexChanged);
            // 
            // LsbHappyContry
            // 
            this.LsbHappyContry.FormattingEnabled = true;
            this.LsbHappyContry.ItemHeight = 12;
            this.LsbHappyContry.Location = new System.Drawing.Point(462, 41);
            this.LsbHappyContry.Name = "LsbHappyContry";
            this.LsbHappyContry.Size = new System.Drawing.Size(138, 184);
            this.LsbHappyContry.TabIndex = 2;
            this.LsbHappyContry.SelectedIndexChanged += new System.EventHandler(this.LsbHappyContry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "GDP 국가 순위";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "행복한 나라";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "살기좋은 도시";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "SelectedIndex : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "SelectedItem : ";
            // 
            // TxtIndexGDP
            // 
            this.TxtIndexGDP.Location = new System.Drawing.Point(118, 241);
            this.TxtIndexGDP.Name = "TxtIndexGDP";
            this.TxtIndexGDP.Size = new System.Drawing.Size(138, 21);
            this.TxtIndexGDP.TabIndex = 3;
            // 
            // TxtItemGDP
            // 
            this.TxtItemGDP.Location = new System.Drawing.Point(118, 278);
            this.TxtItemGDP.Name = "TxtItemGDP";
            this.TxtItemGDP.Size = new System.Drawing.Size(138, 21);
            this.TxtItemGDP.TabIndex = 4;
            // 
            // TxtItemGood
            // 
            this.TxtItemGood.Location = new System.Drawing.Point(290, 278);
            this.TxtItemGood.Name = "TxtItemGood";
            this.TxtItemGood.Size = new System.Drawing.Size(138, 21);
            this.TxtItemGood.TabIndex = 6;
            // 
            // TxtIndexGood
            // 
            this.TxtIndexGood.Location = new System.Drawing.Point(290, 241);
            this.TxtIndexGood.Name = "TxtIndexGood";
            this.TxtIndexGood.Size = new System.Drawing.Size(138, 21);
            this.TxtIndexGood.TabIndex = 5;
            // 
            // TxtItemHappy
            // 
            this.TxtItemHappy.Location = new System.Drawing.Point(462, 278);
            this.TxtItemHappy.Name = "TxtItemHappy";
            this.TxtItemHappy.Size = new System.Drawing.Size(138, 21);
            this.TxtItemHappy.TabIndex = 8;
            // 
            // TxtIndexHappy
            // 
            this.TxtIndexHappy.Location = new System.Drawing.Point(462, 241);
            this.TxtIndexHappy.Name = "TxtIndexHappy";
            this.TxtIndexHappy.Size = new System.Drawing.Size(138, 21);
            this.TxtIndexHappy.TabIndex = 7;
            // 
            // BtnInit
            // 
            this.BtnInit.Location = new System.Drawing.Point(12, 165);
            this.BtnInit.Name = "BtnInit";
            this.BtnInit.Size = new System.Drawing.Size(100, 42);
            this.BtnInit.TabIndex = 9;
            this.BtnInit.Text = "초기화";
            this.BtnInit.UseVisualStyleBackColor = true;
            this.BtnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 362);
            this.Controls.Add(this.BtnInit);
            this.Controls.Add(this.TxtItemHappy);
            this.Controls.Add(this.TxtIndexHappy);
            this.Controls.Add(this.TxtItemGood);
            this.Controls.Add(this.TxtIndexGood);
            this.Controls.Add(this.TxtItemGDP);
            this.Controls.Add(this.TxtIndexGDP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LsbHappyContry);
            this.Controls.Add(this.LsbGoodCity);
            this.Controls.Add(this.LsbGDPContries);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LsbGDPContries;
        private System.Windows.Forms.ListBox LsbGoodCity;
        private System.Windows.Forms.ListBox LsbHappyContry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtIndexGDP;
        private System.Windows.Forms.TextBox TxtItemGDP;
        private System.Windows.Forms.TextBox TxtItemGood;
        private System.Windows.Forms.TextBox TxtIndexGood;
        private System.Windows.Forms.TextBox TxtItemHappy;
        private System.Windows.Forms.TextBox TxtIndexHappy;
        private System.Windows.Forms.Button BtnInit;
    }
}

