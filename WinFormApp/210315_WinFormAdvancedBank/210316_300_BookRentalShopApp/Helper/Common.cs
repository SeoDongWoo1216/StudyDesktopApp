using System.Net;

namespace _210316_300_BookRentalShopApp.Helper
{
    public static class Common
    {
        // DB 로그인할때 일일이 입력해주는게 귀찮으니까 클래스, public static으로 선언해서 문자열인 ConnString만 호출해주면됨.
        public static string ConnString = "Data Source=127.0.0.1;Initial Catalog=bookrentalshop;" +
                                          "Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!";

        public static string LoginUserId = string.Empty;



        // IP주소 받아오는 메서드(로그인할때 호출)
        internal static string GetLocalIp()
        {
            string localIp = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                    break;
                }
            }

            return localIp;
        }

        internal static string ReplaceCmdText(string strSource)
        {
            // Sql Injection 방지
            var result = strSource.Replace("'", "＇");  // 키보드 소따옴표를 특수 문자 소따옴표로 변경
            result = result.Replace("--", "");          // SQL의 주석 못달게 막기
            result = result.Replace(";", "");           // 세미콜론(;) 무력화
            return result;
        }
    }
}
