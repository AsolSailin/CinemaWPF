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
using CinemaWPF.Core;
using System.IO;

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

        /*private void Image_Click(object sender, RoutedEventArgs e)
        {
            var path = @"C:\Users\Руслана\source\repos\CinemaWPF\CinemaWPF";

            foreach (var item in App.Connection.Service.ToArray().Where(i => !string.IsNullOrWhiteSpace(i.MainImagePath)))
            {
                var fullPath = path + item.MainImagePath;
                var byteImage = File.ReadAllBytes(fullPath);
                item.MainImageByte = byteImage;
            }

            App.Connection.SaveChanges();
        }*/
    }
}
