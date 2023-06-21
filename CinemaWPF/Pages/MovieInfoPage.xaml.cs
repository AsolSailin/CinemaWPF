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
    /// Логика взаимодействия для MovieInfoPage.xaml
    /// </summary>
    public partial class MovieInfoPage : Page
    {
        public MovieInfoPage()
        {
            InitializeComponent();
            GetTextBoxValue();

            if (DataBase.MongoDataBase.CurrentUser.Role == "Admin")
            {
                btnSessions.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;

                btnSessions.Click += SessionsBtn_Click;
                btnEdit.Click += EditBtn_Click;
                btnDelete.Click += DeleteBtn_Click;
            }
            else
            {
                btnBuy.Visibility = Visibility.Visible;
                btnBuy.Click += SessionsBtn_Click;
            }
        }

        public void GetTextBoxValue()
        {
            imgPoster.Source = new BitmapImage(new Uri(@"/CinemaWPF;component" + DataBase.MongoDataBase.CurrentMovie.Poster, UriKind.Relative));
            tbName.Text = DataBase.MongoDataBase.CurrentMovie.Name;
            tbGenre.Text = DataBase.MongoDataBase.CurrentMovie.Genre;
            tbRegisseur.Text = DataBase.MongoDataBase.CurrentMovie.Regisseur;
            tbProducer.Text = DataBase.MongoDataBase.CurrentMovie.Producer;
            tbScript.Text = DataBase.MongoDataBase.CurrentMovie.Script;
            tbCountry.Text = DataBase.MongoDataBase.CurrentMovie.Country;
            tbDuration.Text = DataBase.MongoDataBase.CurrentMovie.Duration;
            tbDescription.Text = DataBase.MongoDataBase.CurrentMovie.Description;
        }

        private void SessionsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("СЕАНСЫ", new SessionTimePage()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.MongoDataBase.RedMovie = true;
            NavClass.NextPage(new NavComponentsClass("ИЗМЕНЕНИЕ ИНФОРМАЦИИ О ФИЛЬМЕ", new AddingOrEditingMoviePage()));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранный фильм?", "",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = DataBase.MongoDataBase.DeleteMovie(DataBase.MongoDataBase.CurrentMovie.Id);
                MessageBox.Show("Фильм был удален");
                NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
            }
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
