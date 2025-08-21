using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Weather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Будильник сработает:", $"{datePicker.Date} {timePicker.Time}", "OK");

            if (datePicker.Date + timePicker.Time <= DateTime.Now)
                return;

            datePicker.IsEnabled = false;
            timePicker.IsEnabled = false;
            sliderVolume.IsEnabled = false;
            repeateSwitch.IsEnabled = false;

            string minutesString = timePicker.Time.Minutes.ToString();
            string minutes = minutesString.Length == 1 ? "0" + minutesString : minutesString;
            resultMessage.Text = $"Будильник установлен на {datePicker.Date.Day}.{datePicker.Date.Month}, {timePicker.Time.Hours}:{minutes}";
        }

        private void SliderVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            headerVolume.Text = string.Format("Громкость: {0:F1}", e.NewValue);
        }

        private void TimePickerChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(timePicker, datePicker.Date + timePicker.Time >= DateTime.Now ? "Valid" : "Invalid");
        }

        private void DatePickerChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(datePicker, datePicker.Date >= DateTime.Today ? "Valid" : "Invalid");
        }
    }
}