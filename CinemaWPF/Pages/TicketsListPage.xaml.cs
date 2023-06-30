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
    /// Логика взаимодействия для TicketsListPage.xaml
    /// </summary>
    public partial class TicketsListPage : Page
    {
        public TicketsListPage()
        {
            InitializeComponent();
            DataBase.MongoDataBase.CurrentUser = DataBase.MongoDataBase.FindUserByLogin("user1");
            lvTickets.ItemsSource = DataBase.MongoDataBase.GetTicketList(DataBase.MongoDataBase.CurrentUser);
        }

        //Navigation
        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            NavClass.NextPage(new NavComponentsClass("КАТАЛОГ", new InitialPage()));
        }

        private void RefundTicketBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
