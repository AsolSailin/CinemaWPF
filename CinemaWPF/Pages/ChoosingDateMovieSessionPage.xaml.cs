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

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosingDateMovieSessionPage.xaml
    /// </summary>
    public partial class ChoosingDateMovieSessionPage : Page
    {
        public List<string> dates = new List<string>();
        public List<Session> sessions = new List<Session>();

        public ChoosingDateMovieSessionPage()
        {
            InitializeComponent();
            imgPoster.Source = new BitmapImage(new Uri(@"/CinemaWPF;component" + DataBase.MongoDataBase.CurrentMovie.Poster, UriKind.Relative));

            switch (DataBase.MongoDataBase.CurrentHall.Name)
            {
                case "2D":
                    tbPrice.Text = DataBase.MongoDataBase.CurrentMovie.Price2D;
                    break;
                case "3D":
                    tbPrice.Text = DataBase.MongoDataBase.CurrentMovie.Price3D;
                    break;
                case "VIP":
                    tbPrice.Text = DataBase.MongoDataBase.CurrentMovie.PriceVIP;
                    break;
            }

            sessions = DataBase.MongoDataBase.GetSessionList(DataBase.MongoDataBase.CurrentMovie, DataBase.MongoDataBase.CurrentHall.Name);

            foreach (var s in sessions)
            {
                dates.Add(s.Time.ToString("d"));
            }

            foreach (var d in dates.Distinct().ToList())
            {
                var datesClass = new DatesClass
                {
                    Date = d
                };
                lvDates.Items.Add(datesClass);
            }
        }

        private void DateBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            DataBase.MongoDataBase.CurrentDate = btn.Content.ToString();
            NavClass.NextPage(new NavComponentsClass("ВЫБОР ВРЕМЕНИ СЕАНСА", new ChoosingTimeMovieSessionPage()));
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
