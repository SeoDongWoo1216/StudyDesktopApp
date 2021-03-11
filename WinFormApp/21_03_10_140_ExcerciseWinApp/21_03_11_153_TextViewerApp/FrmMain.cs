using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_03_11_153_TextViewerApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DlgSelectText.FileName = "Select a Text File";
            DlgSelectText.Filter = "Text files (*.txt)| *.txt";
            DlgSelectText.Title = "Open text file";
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            if(DlgSelectText.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = DlgSelectText.FileName;

                    using (FileStream fs = File.Open(filePath, FileMode.Open))
                    {
                        Process.Start("notepad.exe", filePath);  // C/windows/notepad.exe 를 호출
                        // Process.Start(@"C:\Program Files\Notepad++\notepad++.exe", filePath);  // notepad++ 호출
                        // 파일을 호출할때 파일명이 스페이스바(공백)이 있으면 호출되지 않는다.
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
        }
    }
}
