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
using static MongoDB.Driver.WriteConcern;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminAccountPage.xaml
    /// </summary>
    public partial class AdminAccountPage : Page
    {
        private bool isDisable = true;
        private int count = 0;

        public AdminAccountPage()
        {
            InitializeComponent();
            GetTextBoxValue();
        }

        public void GetTextBoxValue()
        {
            tbSurname.Text = DataBase.MongoDataBase.CurrentUser.Surname;
            tbName.Text = DataBase.MongoDataBase.CurrentUser.Name;
            tbPatronymic.Text = DataBase.MongoDataBase.CurrentUser.Patronymic;
            tbPhoneNumber.Text = DataBase.MongoDataBase.CurrentUser.PhoneNumber;
            tbEMail.Text = DataBase.MongoDataBase.CurrentUser.EMail;
            tbLogin.Text = DataBase.MongoDataBase.CurrentUser.Login;
            tbPassword.Text = DataBase.MongoDataBase.CurrentUser.Password;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isDisable)
            {
                isDisable = false;

                tbLogin.IsEnabled = true;
                tbPassword.IsEnabled = true;

                tbLogin.Foreground = Brushes.White;
                tbPassword.Foreground = Brushes.White;
            }
            else
            {
                isDisable = true;

                tbLogin.IsEnabled = false;
                tbPassword.IsEnabled = false;

                tbLogin.Foreground = Brushes.Black;
                tbPassword.Foreground = Brushes.Black;
            }

            count++;

            if (count == 2)
            {
                count = 0;
                _ = DataBase.MongoDataBase.UserReplace(DataBase.MongoDataBase.CurrentUser);
                MessageBox.Show("Пользователь был изменен");
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.MongoDataBase.CurrentUser = null;
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }

        //Navigation
        private void CinemaInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("ИНВОРМАЦИЯ О КИНОТЕАТРЕ", new CinemaInfoPage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
