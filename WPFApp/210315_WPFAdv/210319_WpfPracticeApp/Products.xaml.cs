using _210319_WpfPracticeApp.BusinessLogic;
using System;
using System.Collections.Generic;
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

namespace _210319_WpfPracticeApp
{
    /// <summary>
    /// Products.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            var cars = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                byte red = (byte)(i % 3 == 0 ? 255 :(i * 50) % 255);  // 레드/그린/블루를 임의로 계속 바꿔줌
                byte green = 0;
                byte blue = (byte)(i % 3 == 0 ? 255 : (i * 90) % 255);
                cars.Add(new Car() {
                    Speed = i * 10,
                    MainColor = Color.FromRgb(red, green, blue)
                });
            }

            this.DataContext = cars;  // Products 클래스의 데이터 바인딩에 참여할 때 요소에 대한 데이터 컨테스트를 가져오거나 설정
        }
    }
}
