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
    /// Логика взаимодействия для CinemaInfoPage.xaml
    /// </summary>
    public partial class CinemaInfoPage : Page
    {
        public CinemaInfoPage()
        {
            InitializeComponent();
        }

        //Navigation
        private void AddingMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.MongoDataBase.RedMovie = false;
            NavClass.NextPage(new NavComponentsClass("ДОБАВЛЕНИЕ НОВОГО КИНОФИЛЬМА", new AddingOrEditingMoviePage()));
        }

        private void AddingSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("ДОБАВЛЕНИЕ НОВОГО КИНОСЕАНСА", new AddingMovieSessionPage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
