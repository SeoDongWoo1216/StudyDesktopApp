using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _210315_179_WPFLoginApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        // DB 연결 문자열
        string connString = "Data Source=127.0.0.1;Initial Catalog=PMS;Persist Security Info=True;" +
            "User ID=sa;Password=mssql_p@ssw0rd!";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            TxtUserId.Focus();
        }

        private void TxtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TxtPassword.Focus();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnLogin_Click(sender, e);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // 연결이 닫힌경우
                
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                try
                {
                    // 쿼리후에 띄어쓰기를 해주어야함.  count(*) " 에서 )와 " 사이의 스페이스바 한칸이 매우 중요하다.(실제 쿼리문을 생각하면됨)
                    string query = $"SELECT count(*) " +
                                   $"  FROM Member " +
                                   $" WHERE UserId = '{TxtUserId.Text}' " +
                                   $"   AND Password = '{TxtPassword.Password}'; ";

                    // Sql커맨드를 통해 SELECT, INSERT 등을 넣을 수 있다.
                    SqlCommand cmd = new SqlCommand(query, conn);


                    // ExecuteNonQuery 메서드는 INSERT, UPDATE, DELETE 등의 DML 문장을 실행할 때 사용
                    // 데이타를 서버에서 가져오기 위해서는 ExecuteReader()를 사용
                    // 경우에 따라 리턴되는 데이타가 단 하나 Single Value인 경우 ExecuteScalar(); 사용(값없으면 0, 값있으면 숫자반환)

                    var result = Convert.ToInt32(cmd.ExecuteScalar()); // 파라미터가 Object이므로 convert를통해 정수로 형변환

                    if (result == 1)
                        MessageBox.Show("로그인 성공");
                    else
                        MessageBox.Show("로그인 실패");
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                    return;
                }
               
            }
        }
    }
}
