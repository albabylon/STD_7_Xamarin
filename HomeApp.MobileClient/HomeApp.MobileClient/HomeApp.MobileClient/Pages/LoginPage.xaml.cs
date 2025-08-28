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

        // Создаем объект, возвращающий свойства устройства
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

        public LoginPage()
        {
            InitializeComponent();

            // Кастомизация под разные платформы
            // Изменяем внешний вид кнопки для Windows-версии
            if (Device.RuntimePlatform == Device.UWP)
                loginButton.CornerRadius = 0;

            // Изменяем внешний вид кнопки для Desktop-версии
            if (Device.Idiom == TargetIdiom.Desktop)
                loginButton.CornerRadius = 0;

            // Передаем информацию о платформе на экран
            //runningDevice.Text = detector.GetDevice();

            // Устанавливаем динамический ресурс с помощью специально метода
            infoMessage.SetDynamicResource(Label.TextColorProperty, "errorColor");
        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private async void Login_ClickAsync(object sender, EventArgs e)
        {
            //if (loginCounter == 0)
            //{
            //    loginButton.Text = $"Выполняется вход..";
            //}
            //else if (loginCounter > 5)
            //{
            //    loginButton.IsEnabled = false;

            //    // Обновляем динамический ресурс по необходимости
            //    Resources["errorColor"] = Color.FromHex("#e70d4f");

            //    var infoMessage = (Label)stackLayout.Children.Last();
            //    infoMessage.Text = "Слишком много попыток! Попробуйте позже";

            //    // Используем добавленный глобальный ресурс
            //    //infoMessage.TextColor = (Color)Application.Current.Resources["errorColor"];
            //}
            //else
            //{
            //    // Обновляем динамический ресурс по необходимости
            //    Resources["errorColor"] = Color.FromHex("#ff8e00");

            //    loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
            //    await Task.Delay(150);

            //    // Переход на следующую страницу - страницу списка устройств
            //    await Navigation.PushAsync(new DeviceListPage());

            //    // Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
            //    loginButton.Text = BUTTON_TEXT;
            //}

            //loginCounter += 1;

            loginButton.Text = $"Выполняется вход..";
            // Имитация задержки (приложение загружает данные с сервера)
            await Task.Delay(150);

            // Переход на следующую страницу - страницу списка устройств
            await Navigation.PushAsync(new DeviceListPage());
            // Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
            loginButton.Text = BUTTON_TEXT;
        }
    }
}