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
    /// Логика взаимодействия для ChoosingTimeMovieSessionPage.xaml
    /// </summary>
    public partial class ChoosingTimeMovieSessionPage : Page
    {
        public List<string> times = new List<string>();
        public string time = "";

        public ChoosingTimeMovieSessionPage()
        {
            InitializeComponent();
            imgPoster.Source = new BitmapImage(new Uri(@"/CinemaWPF;component" + DataBase.MongoDataBase.CurrentMovie.Poster, UriKind.Relative));
            tbDate.Text = DataBase.MongoDataBase.CurrentDate;
            times = DataBase.MongoDataBase.GetSessionTimeList(DataBase.MongoDataBase.CurrentDate, DataBase.MongoDataBase.CurrentHall.Name, DataBase.MongoDataBase.CurrentMovie);

            foreach (var t in times.Distinct().ToList())
            {
                var datesClass = new DatesClass
                {
                    Time = t
                };
                lvTimes.Items.Add(datesClass);
            }
        }

        private void TimeBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            time = btn.Content.ToString();
            string dateTime = DataBase.MongoDataBase.CurrentDate + " " + time;
            DataBase.MongoDataBase.CurrentSession = DataBase.MongoDataBase.FindSessionByDate(dateTime, DataBase.MongoDataBase.CurrentMovie, DataBase.MongoDataBase.CurrentHall.Name);
            NavClass.NextPage(new NavComponentsClass("ВЫБОР МЕСТА В ЗАЛЕ", new CinemaHallPage()));
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
