using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210316_300_BookRentalShopApp.Helper
{
    public static class Common
    {
        // DB 로그인할때 일일이 입력해주는게 귀찮으니까 클래스, public static으로 선언해서 문자열인 ConnString만 호출해주면됨.
        public static string ConnString = "Data Source=127.0.0.1;Initial Catalog=bookrentalshop;" +
                                          "Persist Security Info=True;User ID=sa;Password=mssql_p@ssw0rd!";

        public static string LoginUserId = string.Empty;

    }
}
