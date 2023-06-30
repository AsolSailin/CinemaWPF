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
    /// Логика взаимодействия для ClientAccountPage.xaml
    /// </summary>
    public partial class ClientAccountPage : Page
    {
        private bool isDisable = true;
        private int count = 0;

        public ClientAccountPage()
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

                tbSurname.IsEnabled = true;
                tbName.IsEnabled = true;
                tbPatronymic.IsEnabled = true;
                tbPhoneNumber.IsEnabled = true;
                tbEMail.IsEnabled = true;
                tbLogin.IsEnabled = true;
                tbPassword.IsEnabled = true;

                tbSurname.Foreground = Brushes.White;
                tbName.Foreground = Brushes.White;
                tbPatronymic.Foreground = Brushes.White;
                tbPhoneNumber.Foreground = Brushes.White;
                tbEMail.Foreground = Brushes.White;
                tbLogin.Foreground = Brushes.White;
                tbPassword.Foreground = Brushes.White;
            }
            else
            {
                isDisable = true;

                tbSurname.IsEnabled = false;
                tbName.IsEnabled = false;
                tbPatronymic.IsEnabled = false;
                tbPhoneNumber.IsEnabled = false;
                tbEMail.IsEnabled = false;
                tbLogin.IsEnabled = false;
                tbPassword.IsEnabled = false;

                tbSurname.Foreground = Brushes.Black;
                tbName.Foreground = Brushes.Black;
                tbPatronymic.Foreground = Brushes.Black;
                tbPhoneNumber.Foreground = Brushes.Black;
                tbEMail.Foreground = Brushes.Black;
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить свой аккаунт?", "",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = DataBase.MongoDataBase.DeleteUser(DataBase.MongoDataBase.CurrentUser.Id);
                MessageBox.Show("Аккаунт был удален");
                NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.MongoDataBase.CurrentUser = null;
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }

        //Navigation
        private void MyTicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("СПИСОК МОИХ БИЛЕТОВ", new TicketsListPage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
