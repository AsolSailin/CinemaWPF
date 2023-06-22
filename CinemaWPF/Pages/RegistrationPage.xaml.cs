using CinemaWPF.Core;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbSurname.Text != "" && tbName.Text != "" && tbPatronymic.Text != "" &&
                tbPhoneNumber.Text != "" && tbEMail.Text != "" && tbLogin.Text != "" &&
                tbPassword.Text != "" && tbPasswordRepeat.Text != "")
            {
                if (DataBase.MongoDataBase.FindByUserLogin(tbLogin.Text) == null)
                {
                    var createUser = new User()
                    {
                        Surname = tbSurname.Text,
                        Name = tbName.Text,
                        Patronymic = tbPatronymic.Text,
                        EMail = tbEMail.Text,
                        PhoneNumber = tbPhoneNumber.Text,
                        Role = "Client",
                        Login = tbLogin.Text,
                        Password = tbPassword.Text,
                        PasswordRepeat = tbPasswordRepeat.Text
                    };

                    if (tbPassword.Text == tbPasswordRepeat.Text)
                    {
                        _ = DataBase.MongoDataBase.AddUserToDataBase(createUser);
                        MessageBox.Show("Вы были зарегистрированы");
                        NavClass.NextPage(new NavComponentsClass("АВТОРИЗАЦИЯ", new AuthorizationPage()));
                    }
                    else
                        MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Для создания аккаунта все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Navigation
        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("АВТОРИЗАЦИЯ", new AuthorizationPage()));
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
