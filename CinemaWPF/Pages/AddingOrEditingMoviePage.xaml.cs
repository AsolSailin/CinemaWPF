﻿using CinemaWPF.Core;
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
    /// Логика взаимодействия для AddingOrEditingMoviePage.xaml
    /// </summary>
    public partial class AddingOrEditingMoviePage : Page
    {
        public string imageName;

        public AddingOrEditingMoviePage()
        {
            InitializeComponent();

            if (DataBase.MongoDataBase.RedMovie)
            {
                btnSaveOrEdit.Content = "Редактировать";
                btnSaveOrEdit.Click += EditBtn_Click;
                GetTextBoxValue();
            }
            else
            {
                btnSaveOrEdit.Content = "Сохранить";
                btnSaveOrEdit.Click += SaveBtn_Click;
            }
        }

        public void GetTextBoxValue()
        {
            tbName.Text = DataBase.MongoDataBase.CurrentMovie.Name;
            tbGenre.Text = DataBase.MongoDataBase.CurrentMovie.Genre;
            tbRegisseur.Text = DataBase.MongoDataBase.CurrentMovie.Regisseur;
            tbProducer.Text = DataBase.MongoDataBase.CurrentMovie.Producer;
            tbScript.Text = DataBase.MongoDataBase.CurrentMovie.Script;
            tbCountry.Text = DataBase.MongoDataBase.CurrentMovie.Country;
            tbDuration.Text = DataBase.MongoDataBase.CurrentMovie.Duration;
            tbDescription.Text = DataBase.MongoDataBase.CurrentMovie.Description;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbGenre.Text != "" && tbRegisseur.Text != "" &&
                tbProducer.Text != "" && tbScript.Text != "" && tbCountry.Text != "" &&
                tbDuration.Text != "" && tbPrice2D.Text != "" && tbPrice3D.Text != "" &&
                tbPriceVIP.Text != "" && tbDescription.Text != "" && imageName != "")
            {
                if (DataBase.MongoDataBase.FindMovieByName(tbName.Text) == null)
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
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

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
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

        //Navigation
        private void SessionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("ДОБАВЛЕНИЕ НОВОГО СЕАНСА", new AddingMovieSessionPage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
