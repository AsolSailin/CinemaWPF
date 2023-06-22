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
    /// Логика взаимодействия для ChoosingHallMovieSessionPage.xaml
    /// </summary>
    public partial class ChoosingHallMovieSessionPage : Page
    {
        public List<string> dates = new List<string>();
        public string date = "";

        public ChoosingHallMovieSessionPage()
        {
            InitializeComponent();
            imgPoster.Source = new BitmapImage(new Uri(@"/CinemaWPF;component" + DataBase.MongoDataBase.CurrentMovie.Poster, UriKind.Relative));
        }

        private void HallBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            DataBase.MongoDataBase.CurrentHall = DataBase.MongoDataBase.FindByHallName(btn.Content.ToString());
            NavClass.NextPage(new NavComponentsClass("ВЫБОР ДАТЫ СЕАНСА", new ChoosingDateMovieSessionPage()));
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
