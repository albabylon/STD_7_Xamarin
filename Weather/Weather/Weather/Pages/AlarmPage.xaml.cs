using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            DisplayAlert("Будильник сработает:", $"{datePicker.Date} {timePicker.Time}", "OK");
        }

        private void SliderVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            headerVolume.Text = String.Format("Громкость: {0:F1}", e.NewValue);
        }
    }
}