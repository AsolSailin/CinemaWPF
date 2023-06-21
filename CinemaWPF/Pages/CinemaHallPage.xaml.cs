using CinemaWPF.Navigation;
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
using static MongoDB.Driver.WriteConcern;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CinemaHallPage.xaml
    /// </summary>
    public partial class CinemaHallPage : Page
    {
        private int count = 0;
        private string placeNumber;

        public CinemaHallPage()
        {
            InitializeComponent();
            GenerateHall();
        }

        private void GenerateHall()
        {
            foreach (var p in DataBase.MongoDataBase.CurrentSession.Hall.Places)
            {
                if (p.Value == "false")
                {
                    var button = new Button()
                    {
                        Content = p.Key,
                        FontSize = 10,
                        Height = 43,
                        Width = 43,
                        Margin = new Thickness(3)
                    };

                    button.Click += PlaceBtn_Click;
                    count++;

                    if (count <= 10)
                        spPlaces1.Children.Add(button);
                    else if (count <= 20)
                        spPlaces2.Children.Add(button);
                    else if (count <= 30)
                        spPlaces3.Children.Add(button);
                    else if (count <= 40)
                        spPlaces4.Children.Add(button);
                    else
                        spPlaces5.Children.Add(button);
                }
                else
                {
                    var button = new Button()
                    {
                        Content = p.Key,
                        FontSize = 10,
                        Height = 43,
                        Width = 43,
                        Margin = new Thickness(3),
                        Background = Brushes.Black 
                    };

                    button.Click += OccupiedPlaceBtn_Click;
                    count++;

                    if (count < 10)
                        spPlaces1.Children.Add(button);
                    else if (count < 20)
                        spPlaces2.Children.Add(button);
                    else if (count < 30)
                        spPlaces3.Children.Add(button);
                    else if (count < 40)
                        spPlaces4.Children.Add(button);
                    else
                        spPlaces5.Children.Add(button);
                }
            }

            if (DataBase.MongoDataBase.CurrentUser.Role == "Client")
            {
                btnBuyOrDelete.Content = "Купить билет";
                btnBuyOrDelete.Click += BuyBtn_Click;
            }
            else if (DataBase.MongoDataBase.CurrentUser.Role == "Admin")
            {
                btnBuyOrDelete.Content = "Удалить сеанс";
                btnBuyOrDelete.Click += DeleteBtn_Click;
            }
        }

        private void PlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            placeNumber = btn.Content.ToString();
        }

        private void OccupiedPlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataBase.MongoDataBase.CurrentUser.Role == "Client")
                MessageBox.Show("Вы не можете выбрать это место, так как оно уже занято!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            if(placeNumber != "")
            {
                DataBase.MongoDataBase.CurrentSession.Hall.Places[placeNumber] = "true";
                _ = DataBase.MongoDataBase.SessionReplace(DataBase.MongoDataBase.CurrentSession);
                DataBase.MongoDataBase.CurrentPlace = placeNumber;
                NavClass.NextPage(new NavComponentsClass("ДАННЫЕ БАНКОВСКОЙ КАРТЫ", new TicketBuyPage()));
            }
            else
                MessageBox.Show("Для перехода на следующую страницу необходимо выбрать место в кинозале!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            _ = DataBase.MongoDataBase.DeleteSession(DataBase.MongoDataBase.CurrentSession.Id);
            MessageBox.Show("Киносеанс был удален из базы данных");
            NavClass.NextPage(new NavComponentsClass("ИНФОРМАЦИЯ О ФИЛЬМЕ", new MovieInfoPage()));
        }
    }
}
