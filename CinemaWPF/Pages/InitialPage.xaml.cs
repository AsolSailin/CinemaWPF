using CinemaWPF.Core;
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
using System.IO;
using CinemaWPF.Navigation;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для InitialPage.xaml
    /// </summary>

    public partial class InitialPage : Page
    {
        public InitialPage()
        {
            InitializeComponent();
            lvMovies.ItemsSource = DataBase.MongoDataBase.GetMovieList();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                NavClass.NextPage(new NavComponentsClass("ИНФОРМАЦИЯ О ФИЛЬМЕ", new MovieInfoPage()));
            }
        }
    }
}
