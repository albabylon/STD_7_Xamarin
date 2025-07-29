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
    public partial class LoginPage : ContentPage
    {
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти";
        // Переменная счетчика
        public static int loginCounter = 0;

        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void Login_Click(object sender, EventArgs e)
        {
            if (loginCounter == 0)
            {
                loginButton.Text = $"Выполняется вход..";
            }
            else if (loginCounter > 5)
            {
                loginButton.IsEnabled = false;

                // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
                var infoMessage = (Label)stackLayout.Children.Last();
                // Задаем текст элемента
                infoMessage.Text = "Слишком много попыток! Попробуйте позже";

            }
            else
            {
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
            }

            loginCounter += 1;
        }
    }
}