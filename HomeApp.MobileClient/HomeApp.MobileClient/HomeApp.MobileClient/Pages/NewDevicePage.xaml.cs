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
	public partial class NewDevicePage : ContentPage
	{
		public NewDevicePage ()
		{
			InitializeComponent ();
            OpenEditor();
        }

        public void OpenEditor()
        {
            // Создание однострочного текстового поля для названия
            var newDeviceName = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название"
            };
            stackLayout.Children.Add(newDeviceName);

            // Создание многострочного поля для описания
            var newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание"
            };
            stackLayout.Children.Add(newDeviceDescription);

            // Создаем заголовок для переключателя
            var switchHeader = new Label { Text = "Не использует газ", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };
            stackLayout.Children.Add(switchHeader);

            // Создаем переключатель
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            stackLayout.Children.Add(switchControl);

            // Регистрируем обработчик события переключения
            switchControl.Toggled += (sender, e) => SwitchHandler(sender, e, switchHeader);

            var addButton = new Button
            {
                Text = "Добавить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver,
            };
            stackLayout.Children.Add(addButton);
        }

        /// <summary>
        /// Обработка переключателя
        /// </summary>
        public void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                header.Text = "Не использует газ";
                return;
            }

            header.Text = "Использует газ";
        }
    }
}