using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _210315_170_WinChartApp
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 보고싶은 차트는 Run메서드의 주석을 해제해주면된다.
            // FrmMain : 버튼으로 랜덤 데이터값 생성
            // FrmSub : 2개의 버튼으로 그래프 합치기, 나누기
            // FrmThirdChart : sin, cos 함수 그래프

            //Application.Run(new FrmMain());
            Application.Run(new FrmSub());
            //Application.Run(new FrmThirdChart());

        }
    }
}
