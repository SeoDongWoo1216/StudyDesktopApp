using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace _210316_300_BookRentalShopApp
{
    public partial class FrmRental : MetroForm
    {
        #region 전역변수 영역
        private bool IsNew = false;  // 프로퍼티를 사용하면 내가 만드는 클래스가 여러사람이 쓸 수 있는 표준 클래스가 됨.
                                     // 변수로 사용해도됨.
                                     // false (수정) true (신규) 로 처리할 예정
        #endregion


        #region 이벤트 영역

        public FrmRental()
        {
            InitializeComponent();
        }


        // 초기화할때는 폼로드에 해주는게 좋음.
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            IsNew = true;  // 신규 초기화
            InitCboData(); // 콤보박스 들어가는 데이터 초기화
            RefreshData(); // 테이블 출력(SELECT문)

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";          // customFormat으로 서식 지정
            DtpRentalDate.Format = DateTimePickerFormat.Custom; // customFormat으로 지정한 값으로 데이트타임 출력
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
                AsignToControls(selData);
                IsNew = false;  // 수정
                BtnSearchBook.Enabled = false;
                BtnSearchMember.Enabled = false;
                DtpRentalDate.Enabled = false;
            }
        }

        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text =                       selData.Cells[0].Value.ToString();
            selMemberIdx =                 (int)selData.Cells[1].Value;
            Debug.WriteLine($">>>> selMemberIdx : {selMemberIdx}");
            TxtMemberName.Text =                selData.Cells[2].Value.ToString();
            selBookIdx =                   (int)selData.Cells[3].Value;
            TxtBookNames.Text =                 selData.Cells[4].Value.ToString();
            Debug.WriteLine($">>>> selBookIdx : {selBookIdx}");
            DtpRentalDate.Value =     (DateTime)selData.Cells[5].Value;
            TxtReturnDate.Text =                selData.Cells[6].Value == null ? "" : selData.Cells[6].Value.ToString();   // null값 대체가 어려워서 DateTime버리고 TextBox로 대체했음
            CboRentalState.SelectedValue =      selData.Cells[7].Value;
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
                var temp = new Dictionary<string, string>();
                temp.Add("R", "대여중");
                temp.Add("T", "반납");

                CboRentalState.DataSource = new BindingSource(temp, null);
                CboRentalState.DisplayMember = "Value";
                CboRentalState.ValueMember = "Key";
                CboRentalState.SelectedIndex = -1;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        query = @"INSERT INTO [dbo].[rentaltbl]
                                                ([memberIdx]
                                                ,[bookIdx]
                                                ,[rentalDate]
                                                ,[rentalState])
                                        VALUES
                                                (@memberIdx
                                                ,@bookIdx
                                                ,@rentalDate
                                                ,@rentalState)";
                    }

                    else               // UPDATE
                    {
                        query = @"UPDATE [dbo].[rentaltbl]
                                     SET [returnDate] = case @rentalState
                                                           WHEN 'T' then GETDATE()
                                                           WHEN 'R' then null
                                                        end
                                        ,[rentalState] = @rentalState
                                   WHERE Idx = @Idx";
                    }

                    cmd.CommandText = query;


                    if(IsNew == true) // INSERT 일때
                    {
                        SqlParameter pMemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                        pMemberIdx.Value = selMemberIdx;
                        cmd.Parameters.Add(pMemberIdx);

                        SqlParameter pBookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                        pBookIdx.Value = selBookIdx;
                        cmd.Parameters.Add(pBookIdx);

                        SqlParameter pRentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                        pRentalDate.Value = DtpRentalDate.Value;
                        cmd.Parameters.Add(pRentalDate);

                        SqlParameter pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);
                    }
                  
                    else  // UPDATE 일때
                    {
                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);

                        SqlParameter pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);
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

                    var query = @"SELECT r.Idx
	                                    ,r.memberIdx
	                                    ,m.Names as memberName
                                        ,r.bookIdx
	                                    ,b.Names as bookName
                                        ,r.rentalDate
                                        ,r.returnDate
	                                    ,r.rentalState
	                                    ,case r.rentalState 
	                                        when 'R' then '대여중'
                                            when 'T' then '반납'
                                            else '상태없음'
                                         end as StateDesc
                                    FROM rentaltbl as r
                                    inner join membertbl as m
                                    on r.memberIdx = m.Idx
                                    inner join bookstbl as b
                                    on r.bookIdx = b.Idx";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "rentaltbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "rentaltbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 데이터그리드뷰 컬럼(Division) 화면에서 안보이게
            var column = DgvData.Columns[1]; // Division 컬럼
            column.Visible = false;

            column = DgvData.Columns[3]; // Division 컬럼
            column.Visible = false;

            column = DgvData.Columns[7]; // Division 컬럼
            column.Visible = false;


        }

        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // 값이 있는지 없는지 체크
            if (string.IsNullOrEmpty(TxtMemberName.Text) || CboRentalState.SelectedIndex < 0 ||
                string.IsNullOrEmpty(TxtBookNames.Text) || DtpRentalDate.Value == null)
            {
                MetroMessageBox.Show(this, "빈 값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // 텍스트박스 Clear
        private void ClearInputs()
        {
            // 컴포넌트 초기화(빈칸으로)
            selMemberIdx = selBookIdx = 0;
            selMemberName = selBookName = "";
            TxtIdx.Text = TxtMemberName.Text = TxtBookNames.Text = "";
            DtpRentalDate.Value = DateTime.Now;  // 오늘 날짜로 초기화
            TxtReturnDate.Text = "";
            CboRentalState.SelectedIndex = -1;

            // 신규눌렀을때는 막혔던 버튼 활성화
            BtnSearchBook.Enabled = true;
            BtnSearchMember.Enabled = true;
            DtpRentalDate.Enabled = true;

            TxtIdx.ReadOnly = true;
            IsNew = true;
        }

        #endregion

        private int selMemberIdx = 0;       // 선택된 회원번호
        private string selMemberName = "";  // 선택된 회원이름

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            FrmMemberPopup frm = new FrmMemberPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                selMemberIdx = frm.SelIdx;
                TxtMemberName.Text = selMemberName = frm.SelName;
            }
        }

        private int selBookIdx = 0;
        private string selBookName = "";
        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            FrmBooksPopup frm = new FrmBooksPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                selBookIdx = frm.SelIdx;
                TxtBookNames.Text = selBookName = frm.SelName;
            }
        }
    }
}
