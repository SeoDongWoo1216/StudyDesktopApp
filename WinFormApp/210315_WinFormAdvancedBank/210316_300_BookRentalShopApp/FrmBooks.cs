using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _210316_300_BookRentalShopApp
{
    public partial class FrmBooks : MetroForm
    {
        #region 전역변수 영역
        private bool IsNew = false;  // 프로퍼티를 사용하면 내가 만드는 클래스가 여러사람이 쓸 수 있는 표준 클래스가 됨.
                                     // 변수로 사용해도됨.
                                     // false (수정) true (신규) 로 처리할 예정
        #endregion


        #region 이벤트 영역

        public FrmBooks()
        {
            InitializeComponent();
        }


        // 초기화할때는 폼로드에 해주는게 좋음.
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            IsNew = true;  // 신규 초기화
            InitCboData(); // 콤보박스 들어가는 데이터 초기화
            RefreshData(); // 테이블 출력(SELECT문)

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";          // customFormat으로 서식 지정
            DtpReleaseDate.Format = DateTimePickerFormat.Custom; // customFormat으로 지정한 값으로 데이트타임 출력
        }

       

        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }

        // 그리드에 셀 클릭했을때 텍스트박스에 출력하는 이벤트
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];
                AsignToControls(selData);  // 
              

                IsNew = false;  // 수정
            }
        }

        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value.ToString();  // B001 = B001
            // selData.Cells[3] X
            DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            TxtNames.Text = selData.Cells[4].Value.ToString();
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescriptions.Text = selData.Cells[8].Value.ToString();
            TxtIdx.ReadOnly = true;
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

        // 콤보박스 들어가는 데이터 초기화
        private void InitCboData()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = @"SELECT Division, Names FROM dbo.divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())  // Read 메서드를 통해 reader 레코드를 계속읽음(데이터 없을때까지 읽는데 이때 없으면 false 반환)
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString());   // (key)B001, (Value)공포/스릴러
                    }
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;   // 인덱스의 항목을 없앰(항목없을때 -1을 반환하는 메서드)
                }
            }
            catch (Exception ex)
            {

            }
        }

        // INSERT, UPDATE 프로세스
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
                        query = @"INSERT INTO [dbo].[bookstbl]
                                            ([Author]
                                            ,[Division]
                                            ,[Names]
                                            ,[ReleaseDate]
                                            ,[ISBN]
                                            ,[Price]
                                            ,[Descriptions])
                                        VALUES
                                            (@Author
                                            ,@Division
                                            ,@Names
                                            ,@ReleaseDate
                                            ,@ISBN
                                            ,@Price
                                            ,@Descriptions)";
                    }

                    else               // UPDATE
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                     SET [Author]       = @Author
                                        ,[Division]     = @Division
                                        ,[Names]        = @Names
                                        ,[ReleaseDate]  = @ReleaseDate
                                        ,[ISBN]         = @ISBN
                                        ,[Price]        = @Price
                                        ,[Descriptions] = @Descriptions
                                  WHERE Idx = @Idx;";
                    }

                    cmd.CommandText = query;

                    SqlParameter pAuthor = new SqlParameter("@Author", SqlDbType.Char, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.NVarChar, 50);
                    pDivision.Value = CboDivision.SelectedValue;
                    cmd.Parameters.Add(pDivision);

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    SqlParameter pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    SqlParameter pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    SqlParameter pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = TxtPrice.Text;
                    cmd.Parameters.Add(pPrice);

                    SqlParameter pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    pDescriptions.Value = Helper.Common.ReplaceCmdText(TxtDescriptions.Text);    // 210319 설명텍스트박스에 SQL인젝션 방지를 위해 문자열 메서드 호출
                    cmd.Parameters.Add(pDescriptions);


                    // INSERT에는 파라미터가 7개, UPDATE에는 파라미터가 8개(Idx)이기 때문에
                    // 파라미터 개수에 오류가 생길 수 있기때문에 Idx에 Flag 처리를 해주어야한다.

                    if(IsNew == false)  // UPDATE 일때만 idx 처리
                    {
                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }
                   

                    var result = cmd.ExecuteNonQuery();  // 잘 실행되면 1반환, 안되면 0반환
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

            RefreshData();
            ClearInputs();
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
                    query = "DELETE FROM [dbo].[bookstbl] " +
                            " WHERE [Idx] = @Idx";

                    cmd.CommandText = query;

                    var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

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

                    var query = @"SELECT  b.Idx 
                                        , b.Author 
                                        , b.Division
	                                    , d.Names as DivName
                                        , b.Names 
                                        , b.ReleaseDate 
                                        , b.ISBN 
                                        , b.Price 
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

            // 데이터그리드뷰 컬럼(Division) 화면에서 안보이게
            var column = DgvData.Columns[2]; // Division 컬럼
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";

            column = DgvData.Columns[0]; // Idx
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // 값이 있는지 없는지 체크
            if (string.IsNullOrEmpty(TxtAuthor.Text) || CboDivision.SelectedIndex == -1 ||
                string.IsNullOrEmpty(TxtNames.Text) || DtpReleaseDate.Value == null)
            {
                MetroMessageBox.Show(this, "빈 값은 삭제할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // 텍스트박스 Clear
        private void ClearInputs()
        {
            TxtIdx.Text = TxtAuthor.Text = "";
            TxtNames.Text = TxtISBN.Text = "";
            TxtPrice.Text = "";
            TxtDescriptions.Text = "";
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;

            TxtIdx.ReadOnly = true;
            IsNew = true;
        }

        #endregion
    }
}
