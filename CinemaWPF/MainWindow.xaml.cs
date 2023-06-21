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
using CinemaWPF.Pages;

namespace CinemaWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavClass.main = this;
            NavClass.NextPage(new NavComponentsClass("СТРАНИЦА", new AuthorizationPage()));
        }

        //Navigation
        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataBase.MongoDataBase.CurrentUser.Role == "Client")
                NavClass.NextPage(new NavComponentsClass("ЛИЧНЫЙ КАБИНЕТ", new ClientAccountPage()));
            else
                NavClass.NextPage(new NavComponentsClass("ЛИЧНЫЙ КАБИНЕТ", new AdminAccountPage()));
        }
    }
}
