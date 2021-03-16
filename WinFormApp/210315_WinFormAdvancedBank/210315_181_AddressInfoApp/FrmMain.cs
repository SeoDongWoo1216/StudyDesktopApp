using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _210315_181_AddressInfoApp
{
    public partial class FrmMain : Form
    {
        string connString = "Data Source=127.0.0.1;Initial Catalog=PMS;Persist Security Info=True;" +
                            "User ID=sa;Password=mssql_p@ssw0rd!";
        public FrmMain()
        {
            InitializeComponent();
        }

        // 초기화(텍스트박스 값 클리어)
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }


        // 입력
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtIdx.Text, out int result);
            if (result > 0)
            {
                MessageBox.Show("초기화를 클릭해주세요.");
                return;
            }

            if(string.IsNullOrEmpty(TxtFullName.Text) || string.IsNullOrEmpty(TxtMobile.Text))
            {
                MessageBox.Show("값을 입력하세요.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = $"INSERT INTO dbo.Address " +
                    $" (FullName, " +
                    $" Mobile, " +
                    $" Addr, " +
                    $" RegId, " +
                    $" RegDate) " +
                    $" VALUES " +
                    $" ('{TxtFullName.Text}'," +
                    $" '{TxtMobile.Text.Replace("-","")}'," +
                    $" '{TxtAddr.Text}'," +
                    $" 'admin', " +
                    $" GETDATE() );";
                // TxtMobile은 000-0000-0000 그대로 들어가기때문에 Replace를 통해 '-'를 빼주고 값을 들어가게 해주어야함.

                SqlCommand cmd = new SqlCommand(query, conn);
                if(cmd.ExecuteNonQuery() == 1)    // 쿼리를 실행할때는 ExecuteNonQuery를 사용 
                {
                    MessageBox.Show("입력 성공!");
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("입력 실패!");
                    ClearInput();
                }
                ReFreshData();
            }
        }

        // 수정
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtIdx.Text, out int result);
            if (result == 0)
            {
                MessageBox.Show("데이터를 선택하십시오.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = $"UPDATE Address " +
                               $" SET " +
                               $" FullName = '{TxtFullName.Text}', " +
                               $" Mobile = '{TxtMobile.Text.Replace("-", "")}', " +
                               $" Addr = '{TxtAddr.Text}', " +
                               $" ModId = 'admin', " +
                               $" ModDate = GETDATE() " +
                               $" WHERE idx = {result};";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("수정 성공!");
                }
                else
                {
                    MessageBox.Show("수정 실패!");
                }
            }
            ClearInput();
            ReFreshData();
        }


        // 삭제
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtIdx.Text, out int result);
            if(result == 0)
            {
                MessageBox.Show("데이터를 선택하십시오.");
                return;
            }

            if(MessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = $"DELETE FROM Address WHERE idx = {result}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("삭제 성공!");
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패!");
                    }
                }

                ClearInput();
                ReFreshData();
            }
        }

        private void TxtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)  // 13은 엔터, 엔터치면 밑 텍스트박스에 포커싱
            {
                TxtMobile.Focus();
            }
        }

        private void TxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                TxtAddr.Focus();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ReFreshData();
            ClearInput();
        }


        // SELECT문을통한 출력을 메서드화(삽입, 수정, 삭제했을때 이 메서드를 호출하면 다시 출력 할 수 있음)
        private void ReFreshData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // SSMS 테이블 스크립팅 메뉴 활용
                string query = "SELECT Idx " +
                               "     , FullName" +
                               "     , Mobile" +
                               "     , Addr" +
                               "  FROM dbo.Address ";
                SqlCommand cmd = new SqlCommand(query, conn);

                // DB 데이터 바인딩 방법
                // SqlCommand, SqlDataReader or Object 사용 : 일일이 값을 LinkedList를 사용해서 반복문으로 출력해야함
                // SqlDataAdapter, Dataset 사용 : 한번에 할 수 있나봄

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DgvAddress.DataSource = ds.Tables[0];
            }
        }

        // 버튼 이벤트 발생 후에 텍스트박스 값 초기화(없애줌)
        private void ClearInput()
        {
            TxtIdx.Text = TxtFullName.Text = TxtMobile.Text = TxtAddr.Text = "";
        }

        // 데이터그리드뷰에서 셀을 클릭했을때 이벤트(셀 클릭했을때 텍스트박스에 값 출력)
        private void DgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selData = DgvAddress.Rows[e.RowIndex].Cells;   // 데이터 그리드 뷰의 셀의 데이터를 selData 저장

            TxtIdx.Text      = selData[0].Value.ToString();    // 셀의 데이터를 텍스트박스에 출력
            TxtFullName.Text = selData[1].Value.ToString();
            TxtMobile.Text   = selData[2].Value.ToString();
            TxtAddr.Text     = selData[3].Value.ToString();
        }
    }
}
