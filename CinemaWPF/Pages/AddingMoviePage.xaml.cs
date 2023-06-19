using CinemaWPF.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddingMoviePage.xaml
    /// </summary>
    public partial class AddingMoviePage : Page
    {
        public string imageName;

        public AddingMoviePage()
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
                if (DataBase.MongoDataBase.FindByMovieName(tbName.Text) == null)
                {
                    DataBase.MongoDataBase.CurrentMovie = new Movie()
                    {
                        Name = tbName.Text,
                        Genre = tbGenre.Text,
                        Regisseur = tbRegisseur.Text,
                        Producer = tbProducer.Text,
                        Script = tbScript.Text,
                        Country = tbCountry.Text,
                        Duration = tbDuration.Text,
                        Description = tbDescription.Text,
                        Price2D = tbPrice2D.Text,
                        Price3D = tbPrice3D.Text,
                        PriceVIP = tbPriceVIP.Text,
                        Poster = @"\Images\" + imageName
                    };

                    _ = DataBase.MongoDataBase.AddMovieToDataBase(DataBase.MongoDataBase.CurrentMovie);
                    MessageBox.Show("Фильм был добавлен в базу данных");
                }
                else
                    MessageBox.Show("Данный фильм уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Для добавления нового фильма все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
