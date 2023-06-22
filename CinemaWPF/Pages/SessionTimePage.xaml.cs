using CinemaWPF.Core;
using CinemaWPF.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для SessionTimePage.xaml
    /// </summary>
    public partial class SessionTimePage : Page
    {
        public List<string> dates = new List<string>();
        public List<Session> sessions = new List<Session>();
        public string date = "";

        public SessionTimePage()
        {
            InitializeComponent();
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase.MongoDataBase.CurrentMovie = DataBase.MongoDataBase.FindByMovieName("Чебурашка");

            dates = new List<string>();
            var btn = (Button)sender;

            switch (btn.Content.ToString())
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

            DataBase.MongoDataBase.CurrentHall = DataBase.MongoDataBase.FindByHallName(btn.Content.ToString());
            sessions = DataBase.MongoDataBase.GetSessionList(DataBase.MongoDataBase.CurrentMovie, btn.Content.ToString());

            foreach (var s in sessions)
            {
                dates.Add(s.Time.ToString("d"));
            }

            foreach (var d in dates.Distinct().ToList())
            {
                var datesClass = new DatesClass();
                datesClass.Date = d;
                foreach (var t in DataBase.MongoDataBase.GetSessionTimeList(d, btn.Content.ToString(), DataBase.MongoDataBase.CurrentMovie))
                {
                    datesClass.Time = t;
                }
                lvDates.Items.Add(datesClass);  
            }
        }
        /*@foreach(var d in dates.Distinct().ToList())
        {
                                < label > @d </ label > < br />
                                < MudButtonGroup Style = "background:#9F4FF9;" Size = "Size.Small" Variant = "Variant.Outlined" >
                                    @foreach(var t in dataBase.GetSessionTimeList(d, currentHallName, dataBase.CurrentMovie))
                                    {
                                        < MudButton @onclick = "() => GetHall(t, d, currentHallName)" > @t </ MudButton >
                                    }
                                </ MudButtonGroup >
                                < br />< br />
        }*/
    }
}
