using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.MobileClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            PlatformAdjust();
        }

        private void Register_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Настраиваем вид для разных платформ
        /// </summary>
        public void PlatformAdjust()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                placeHolder.PlaceholderColor = Color.SlateGray;
                loginButton.TextColor = Color.AliceBlue;
                loginButton.Margin = new Thickness(0, 5);
            }
        }
    }
}