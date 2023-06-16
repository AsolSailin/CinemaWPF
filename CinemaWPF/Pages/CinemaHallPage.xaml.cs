using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CinemaHallPage.xaml
    /// </summary>
    public partial class CinemaHallPage : Page
    {
        const int placeCount = 50;
        private int placeNumber = 1;

        public CinemaHallPage()
        {
            InitializeComponent();
            GenerateHall();
        }

        private void GenerateHall()
        {
            for (int i = 0; i < placeCount; i++)
            {
                var button = new Button()
                {
                    Content = placeNumber,
                    FontSize = 10,
                    Height = 43,
                    Width = 43,
                    Margin = new Thickness(3)
                };

                button.Click += PlaceBtn_Click;

                if (i < 10)
                    spPlaces1.Children.Add(button);
                else if (i < 20)
                    spPlaces2.Children.Add(button);
                else if (i < 30)
                    spPlaces3.Children.Add(button);
                else if (i < 40)
                    spPlaces4.Children.Add(button);
                else
                    spPlaces5.Children.Add(button);

                placeNumber++;
            }
        }

        private void PlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
        }
    }
}
