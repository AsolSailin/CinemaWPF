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
    /// Логика взаимодействия для ClientAccountPage.xaml
    /// </summary>
    public partial class ClientAccountPage : Page
    {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
