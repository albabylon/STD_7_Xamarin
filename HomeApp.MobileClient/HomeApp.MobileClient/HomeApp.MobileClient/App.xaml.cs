using HomeApp.MobileClient.Pages;
using Xamarin.Forms;

namespace HomeApp.MobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
