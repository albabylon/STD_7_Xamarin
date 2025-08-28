using HomeApp.MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.MobileClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        /// <summary>
        /// Модель пользовательских данных
        /// </summary>
        public UserInfo UserInfo { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вызывается до того, как элемент становится видимым
        /// </summary>
        protected async override void OnAppearing()
        {
            //Хранение через Properties
            // App.Current.Properties - хранит информацию в приложении (сохр. при перезапуске)

            // Проверяем доступность сетевого соединения
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                // При наличии - запрашиваем данные с сервера
                await GetHouseInfo();
            }

            // Проверяем, есть ли в словаре значение
            if (App.Current.Properties.TryGetValue("CurrentUser", out object user))
            {
                UserInfo = user as UserInfo;
                loginEntry.Text = UserInfo.Name;
                emailEntry.Text = UserInfo.Email;
            }
            else
            {
                // Добавляем, если нет
                UserInfo = new UserInfo();
                App.Current.Properties.Add("CurrentUser", UserInfo);
            }

            // Получим значения ползунков из Preferences.
            // Если значений нет - установим значения по умолчанию (false)
            gasSwitch.On = Preferences.Get("gasState", false);
            climateSwitch.On = Preferences.Get("climateState", false);
            electroSwitch.On = Preferences.Get("electroState", false);

            base.OnAppearing();
        }

        private void NotifyUser(object sender, ToggledEventArgs e)
        {
            if (gasSwitch.On && climateSwitch.On && electroSwitch.On)
                DisplayAlert("Внимание!", "Пользователь получит полный доступ ко всем системам", "OK");
        }

        /// <summary>
        ///  Сохраним информацию о пользователе
        /// </summary>
        private async void saveButton_Clicked(object sender, System.EventArgs e)
        {
            UserInfo.Name = loginEntry.Text;
            UserInfo.Email = emailEntry.Text;

            //Хранение через Xamarin.Essentials.Preferences (сохр. при перезапуске)
            // Сохраним значения ползунков в настройки.
            Preferences.Set("gasState", gasSwitch.On);
            Preferences.Set("climateState", climateSwitch.On);
            Preferences.Set("electroState", electroSwitch.On);

            // Возврат на предыдущую страницу
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Загружает информацию о строении
        /// </summary>
        private async Task GetHouseInfo()
        {
            // Получим информацию с помощью клиента
            var inforResponse = await App.ApiClient.GetInfo();
            // Маппинг внешней модели данных во внутреннюю   
            var houseInfo = App.Mapper.Map<HouseInfo>(inforResponse);

            // Проставляем нужные значения, полученные с сервера
            addressEntry.Text = $" {houseInfo.AddressInfo.Street} {houseInfo.AddressInfo.House}/{houseInfo.AddressInfo.Building}";
            telephoneEntry.Text = $" {houseInfo.Telephone}";
            areaEntry.Text = $" {houseInfo.Area} кв. м.";
            voltageEntry.Text = $" {houseInfo.CurrentVolts} в";
            heatingEntry.Text = $" {houseInfo.Heating}";
        }
    }
}