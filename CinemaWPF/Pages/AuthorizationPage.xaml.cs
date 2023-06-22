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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && pbPassword.Password != "")
            {
                DataBase.MongoDataBase.CurrentUser = DataBase.MongoDataBase.FindUserByLogin(tbLogin.Text);

                if (DataBase.MongoDataBase.CurrentUser != null && DataBase.MongoDataBase.CurrentUser.Password == pbPassword.Password)
                {
                    if (DataBase.MongoDataBase.CurrentUser.Role == "Client")
                        NavClass.NextPage(new NavComponentsClass("ЛИЧНЫЙ КАБИНЕТ", new ClientAccountPage()));
                    else if (DataBase.MongoDataBase.CurrentUser.Role == "Admin")
                        NavClass.NextPage(new NavComponentsClass("ЛИЧНЫЙ КАБИНЕТ", new AdminAccountPage()));
                }
                else
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Для входа введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("РЕГИСТРАЦИЯ", new RegistrationPage()));
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }
    }
}
