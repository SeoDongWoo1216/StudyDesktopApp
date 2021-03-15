
namespace _210315_181_AddressInfoApp
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
            this.DgvAddress = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtIdx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAddr = new System.Windows.Forms.TextBox();
            this.TxtFullName = new System.Windows.Forms.TextBox();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.TxtMobile = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddress)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAddress
            // 
            this.DgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAddress.Location = new System.Drawing.Point(12, 12);
            this.DgvAddress.Name = "DgvAddress";
            this.DgvAddress.RowTemplate.Height = 23;
            this.DgvAddress.Size = new System.Drawing.Size(610, 163);
            this.DgvAddress.TabIndex = 1;
            this.DgvAddress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAddress_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtMobile);
            this.groupBox1.Controls.Add(this.BtnDelete);
            this.groupBox1.Controls.Add(this.BtnUpdate);
            this.groupBox1.Controls.Add(this.BtnInsert);
            this.groupBox1.Controls.Add(this.TxtFullName);
            this.groupBox1.Controls.Add(this.TxtAddr);
            this.groupBox1.Controls.Add(this.BtnClear);
            this.groupBox1.Controls.Add(this.TxtIdx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "입력창";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(380, 24);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(96, 44);
            this.BtnClear.TabIndex = 11;
            this.BtnClear.Text = "초기화";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TxtIdx
            // 
            this.TxtIdx.Location = new System.Drawing.Point(65, 22);
            this.TxtIdx.Name = "TxtIdx";
            this.TxtIdx.ReadOnly = true;
            this.TxtIdx.Size = new System.Drawing.Size(42, 21);
            this.TxtIdx.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "주소";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "휴대폰";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Idx";
            // 
            // TxtAddr
            // 
            this.TxtAddr.Location = new System.Drawing.Point(65, 102);
            this.TxtAddr.MaxLength = 200;
            this.TxtAddr.Name = "TxtAddr";
            this.TxtAddr.Size = new System.Drawing.Size(244, 21);
            this.TxtAddr.TabIndex = 10;
            // 
            // TxtFullName
            // 
            this.TxtFullName.Location = new System.Drawing.Point(158, 24);
            this.TxtFullName.MaxLength = 12;
            this.TxtFullName.Name = "TxtFullName";
            this.TxtFullName.Size = new System.Drawing.Size(81, 21);
            this.TxtFullName.TabIndex = 8;
            this.TxtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFullName_KeyPress);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(380, 79);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(96, 44);
            this.BtnInsert.TabIndex = 13;
            this.BtnInsert.Text = "추가";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(491, 24);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(96, 44);
            this.BtnUpdate.TabIndex = 12;
            this.BtnUpdate.Text = "수정";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(491, 79);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(96, 44);
            this.BtnDelete.TabIndex = 14;
            this.BtnDelete.Text = "삭제";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(65, 64);
            this.TxtMobile.Mask = "000-9000-0000";
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.Size = new System.Drawing.Size(94, 21);
            this.TxtMobile.TabIndex = 9;
            this.TxtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMobile_KeyPress);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "주소 관리 프로그램";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddress)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TxtIdx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFullName;
        private System.Windows.Forms.TextBox TxtAddr;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.MaskedTextBox TxtMobile;
    }
}

