using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _210316_300_BookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtUserId.Focus();
            this.Activate();    // 실행했을때 포커스를 잡아주고 바로 키보드 입력가능하게 만들어줌.
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var strUserId = "";  // select 값으로 받아와서 처리할 (지역)변수

            if (string.IsNullOrEmpty(TxtUserId.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "SELECT userID FROM membertbl " +
                                " WHERE userID = @userID " +
                                "   AND passwords = @passwords " +
                                "   AND levels = 'S'; ";

                    // SqlCommand 생성
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Sql_Injection 해킹막기위해서 사용

                    // 아이디 처리
                    SqlParameter pUserID = new SqlParameter("@userId", SqlDbType.VarChar, 20); // 유저 아이디를 varchar 20으로 설정(제한)
                    pUserID.Value = TxtUserId.Text;
                    cmd.Parameters.Add(pUserID);
                    // 비번처리
                    SqlParameter pPasswords = new SqlParameter("@passwords", SqlDbType.VarChar, 20);
                    pPasswords.Value = TxtPassword.Text;
                    cmd.Parameters.Add(pPasswords);

                    // SqlDataReader 실행(1)
                    SqlDataReader reader = cmd.ExecuteReader();

                    //reader로 처리
                    reader.Read();
                    strUserId = reader["userID"] != null ? reader["userID"].ToString() : ""; // strUserId가 null이 아니면 문자열형태로 그대로 넣고 아니면 빈값을 넣음

                    if (string.IsNullOrEmpty(strUserId))
                    {
                        MetroMessageBox.Show(this, "접속실패", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "접속성공", "로그인성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // 완전 종료
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
                TxtPassword.Focus();
        }

        private void BtnPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnLogin_Click(sender, e);
        }
    }
}
