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
    public partial class FrmDivCode : MetroForm
    {
        #region 전역변수 영역
        private bool IsNew = false;  // 프로퍼티를 사용하면 내가 만드는 클래스가 여러사람이 쓸 수 있는 표준 클래스가 됨.
                                     // 변수로 사용해도됨.
                                     // false (수정) true (신규) 로 처리할 예정
        #endregion


        #region 이벤트 영역

        public FrmDivCode()
        {
            InitializeComponent();
        }

        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            IsNew = true;  // 신규 초기화
            RefreshData();
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;

                IsNew = false;  // 수정
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // validation
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation(값 유효성) 체크
            if (CheckValidation() == false) return;
            SaveData();
            RefreshData();
            ClearInputs();
        }

        #endregion



        #region 커스텀 메서드 영역(내가만든거)

        // 세이브, 수정 프로세스
        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (IsNew == true)  // INSERT
                    {
                        query = "INSERT INTO dbo.divtbl" +
                                " VALUES" +
                                " (@Division, @Names)";
                    }

                    else               // UPDATE
                    {
                        query = "UPDATE [dbo].[divtbl] " +
                                "   SET [Names] = @Names " +
                                " WHERE [Division] = @Division";
                    }

                    cmd.CommandText = query;

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.NVarChar, 8);
                    pDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(pDivision);

                    var result = cmd.ExecuteNonQuery();  // 잘 실행되면 1반환, 안되면 0 반환
                    if (result == 1)
                    {
                        // 저장성공
                        MetroMessageBox.Show(this, "저장성공", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 저장실패
                        MetroMessageBox.Show(this, "저장실패", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 삭제 처리 프로세스
        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";
                    query = "DELETE FROM [dbo].[divtbl] " +
                            " WHERE [Division] = @Division";

                    cmd.CommandText = query;

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.NVarChar, 8);
                    pDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(pDivision);

                    var result = cmd.ExecuteNonQuery();  // 잘 실행되면 1반환, 안되면 0 반환
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제성공", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제실패", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 버튼이벤트 끝났을때 데이터그리드뷰를 다시 출력(바로 업데이트해주는거임)
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "SELECT Division, Names " +
                                "  from divtbl;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "divtbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 삭제할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // 텍스트박스 Clear
        private void ClearInputs()
        {
            TxtDivision.Text = TxtNames.Text = "";
            TxtDivision.ReadOnly = false;
            IsNew = true;
        }

        #endregion








    }
}
