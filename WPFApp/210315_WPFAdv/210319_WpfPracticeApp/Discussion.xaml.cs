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
    /// Discussion.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Discussion : Page
    {
        public Discussion()
        {
            InitializeComponent();
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            // 데이터바인딩을위해 동적으로 바인딩
            Talk talk = new Talk();
            this.DataContext = talk;
        }
    }
}
