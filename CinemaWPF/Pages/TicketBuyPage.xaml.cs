using CinemaWPF.Core;
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
using System.Xml.Linq;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketBuyPage.xaml
    /// </summary>
    public partial class TicketBuyPage : Page
    {
        public TicketBuyPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tbNumber.Text != "" && tbName.Text != "" && 
                tbValidityPeriod.Text != "" && tbCVC.Text != "")
            {
                DataBase.MongoDataBase.CurrentTicket = new Ticket()
                {
                    MovieName = DataBase.MongoDataBase.CurrentMovie.Name,
                    Poster = DataBase.MongoDataBase.CurrentMovie.Poster,
                    HallName = DataBase.MongoDataBase.CurrentHall.Name,
                    PlaceNumber = DataBase.MongoDataBase.CurrentPlace,
                    Date = DataBase.MongoDataBase.CurrentSession.Time.ToString("d"),
                    Time = DataBase.MongoDataBase.CurrentSession.Time.ToString("t"),
                    User = DataBase.MongoDataBase.CurrentUser,
                    DateTimeCreate = DataBase.MongoDataBase.CurrentSession.Time
                };

                _ = DataBase.MongoDataBase.AddTicketToDataBase(DataBase.MongoDataBase.CurrentTicket);
                MessageBox.Show("Билет добавлен в список Ваших билетов");
                NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
            }
            else
                MessageBox.Show("Для завершения покупки билета все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
