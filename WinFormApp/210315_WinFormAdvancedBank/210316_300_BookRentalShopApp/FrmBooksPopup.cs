using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _210316_300_BookRentalShopApp
{
    public partial class FrmBooksPopup : MetroForm
    {
        #region 전역변수 영역

        #endregion

        public int SelIdx { get; set; }
        public string SelName { get; set; }

        #region 이벤트 영역

        public FrmBooksPopup()
        {
            InitializeComponent();
        }

        // 초기화할때는 폼로드에 해주는게 좋음.
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData(); // 테이블 출력(SELECT문)

        }

        private void FrmDivCode_Resize(object sender, EventArgs e)
        {

        }

        // 그리드에 셀 클릭했을때 텍스트박스에 출력하는 이벤트
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];

            }
        }

        #endregion


        #region 커스텀 메서드 영역(내가만든거)
        // 버튼이벤트 끝났을때 데이터그리드뷰를 다시 출력(바로 업데이트해주는거임)
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT  b.Idx 
                                        , b.Author 
                                        , b.Division
	                                    , d.Names as DivName
                                        , b.Names 
                                        , b.ReleaseDate 
                                        , b.Descriptions 
                                    FROM  bookrentalshop . dbo . bookstbl  as b
                                  inner join dbo.divtbl as d
                                      on b.Division = d.Division";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        #endregion

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelIdx = (int)DgvData.SelectedRows[0].Cells[0].Value;
            SelName = DgvData.SelectedRows[0].Cells[4].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
