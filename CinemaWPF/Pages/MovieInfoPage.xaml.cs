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
    }
}
