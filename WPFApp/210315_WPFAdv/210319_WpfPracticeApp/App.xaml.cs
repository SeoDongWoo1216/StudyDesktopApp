using MahApps.Metro.Controls;
using System.Windows;

namespace _210319_WpfPracticeApp
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        // 네비게이션(뒤로, 앞으로가기 버튼있는거) 이쁘게 추가
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var navWin = new MetroNavigationWindow();
            navWin.Title = $"WPF Bikeshop";
            navWin.Show();
            navWin.Navigate(new MainMenu());
        }
    }
}
