using CinemaWPF.Core;
using CinemaWPF.Navigation;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditingMoviePage.xaml
    /// </summary>
    public partial class EditingMoviePage : Page
    {
        public string imageName;

        public EditingMoviePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbGenre.Text != "" && tbRegisseur.Text != "" &&
                tbProducer.Text != "" && tbScript.Text != "" && tbCountry.Text != "" &&
                tbDuration.Text != "" && tbPrice2D.Text != "" && tbPrice3D.Text != "" &&
                tbPriceVIP.Text != "" && tbDescription.Text != "" && imageName != "")
            {
                _ = DataBase.MongoDataBase.MovieReplace(DataBase.MongoDataBase.CurrentMovie);
                MessageBox.Show("Фильм был изменен");
                NavClass.NextPage(new NavComponentsClass("ИНФОРМАЦИЯ О ФИЛЬМЕ", new MovieInfoPage()));
            }
            else
                MessageBox.Show("Для изменения фильма все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var dialog = new OpenFileDialog();

                if (dialog.ShowDialog() != null)
                {
                    imageName = System.IO.Path.GetFileName(dialog.FileName.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Файл не распознан! Необходимо добавить картинку!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
