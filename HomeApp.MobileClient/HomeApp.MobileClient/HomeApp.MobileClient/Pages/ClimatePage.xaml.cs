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
	public partial class ClimatePage : ContentPage
	{
		public ClimatePage ()
		{
			InitializeComponent ();
            ScanOutside();
            ScanInside();
            GetPressure();
            //GetPressureRelative();
        }


        /// <summary>
        /// Внешние датчики
        /// </summary>
        public void ScanOutside()
        {
            absLayout.Children.Add(
                // Создаем прямоугольник заданного цвета
                new BoxView { Color = Color.LightBlue },
                // Задаем его местоположение и размеры
                new Rectangle(
                    20, // X - координата начальной точки
                    10, // Y - координата начальной точки
                    100, // ширина прямоугольника
                    70 // высота
                )
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = $"Outside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13
                },
                new Rectangle(20, 17, 100, 70)
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = "- 15 °C",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                },
                new Rectangle(20, 15, 100, 70)
            );
        }


        /// <summary>
        /// Внутренние датчики
        /// </summary>
        public void ScanInside()
        {
            absLayout.Children.Add(
                new BoxView { Color = Color.LightSalmon },
                new Rectangle(130, 10, 100, 70)
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = $"Inside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13
                },
                new Rectangle(130, 17, 100, 70)
            );

            absLayout.Children.Add(
                new Label
                {
                    Text = "+ 24 °C",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                },
                new Rectangle(130, 15, 100, 70)
            );
        }

        public void GetPressure()
        {
            // Создаем новый элемент
            var pressureBox = new BoxView { Color = Color.BurlyWood };
            // Указываем позицию
            var position = new Rectangle(240, 10, 173, 70);
            // Сохраняем настройки лейаута
            AbsoluteLayout.SetLayoutBounds(pressureBox, position);
            // Устанавливаем конфигурацию (все величины абсолютные)
            AbsoluteLayout.SetLayoutFlags(pressureBox, AbsoluteLayoutFlags.None);

            // Добавляем элемент
            absLayout.Children.Add(pressureBox);
        }

        //для относительных
        public void GetPressureRelative()
        {
            var pressureBox = new BoxView { Color = Color.BurlyWood };
            var position = new Rectangle(0.5, 0.5, 0.25, 0.5);
            AbsoluteLayout.SetLayoutBounds(pressureBox, position);
            AbsoluteLayout.SetLayoutFlags(pressureBox, AbsoluteLayoutFlags.All);
            absLayout.Children.Add(pressureBox);
        }
    }
}