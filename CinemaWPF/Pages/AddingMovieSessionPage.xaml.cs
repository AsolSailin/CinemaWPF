using CinemaWPF.Core;
using CinemaWPF.Navigation;
using MongoDB.Driver.Linq;
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
    /// Логика взаимодействия для AddingMovieSessionPage.xaml
    /// </summary>
    public partial class AddingMovieSessionPage : Page
    {
        private Session session = new Session();

        public AddingMovieSessionPage()
        {
            InitializeComponent();
            dpDate.Text = DateTime.Now.ToString();
        }

        //Navigation
        private void AddingMovieBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("ДОБАВЛЕНИЕ НОВОГО КИНОФИЛЬМА", new AddingOrEditingMoviePage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.Text != "" && tbTime.Text != "" && 
                tbHallName.Text != "" && tbMovieName.Text !="")
            {
                string[] needTime = tbTime.Text.Split(':');
                DateTime expectedDateTime = Convert.ToDateTime(dpDate.SelectedDate).Add(new TimeSpan(Convert.ToInt32(needTime[0]), Convert.ToInt32(needTime[1]), 0));
                session.Movie = DataBase.MongoDataBase.FindByMovieName(tbMovieName.Text);
                session.Hall = DataBase.MongoDataBase.FindByHallName(tbHallName.Text);

                if (expectedDateTime >= DateTime.Now && session.Movie != null && session.Hall != null)
                {
                    if (DataBase.MongoDataBase.FindSessionByDate(expectedDateTime.ToString(), session.Movie, tbHallName.Text) == null)
                    {
                        DataBase.MongoDataBase.CurrentSession = new Session()
                        {
                            Movie = session.Movie,
                            Hall = session.Hall,
                            Time = expectedDateTime.AddHours(3)
                        };

                        DataBase.MongoDataBase.AddSessionToDataBase(DataBase.MongoDataBase.CurrentSession);
                        MessageBox.Show("Киносеанс был добавлен в базу данных");
                        session = new Session();
                    }
                    else
                        MessageBox.Show("Данная сессия уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Ошибка данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Для создания нового киносеанса все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
