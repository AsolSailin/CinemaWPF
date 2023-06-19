using CinemaWPF.Core;
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
    /// Логика взаимодействия для AddingHallPage.xaml
    /// </summary>
    public partial class AddingHallPage : Page
    {
        public AddingHallPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbHallName.Text != "")
            {
                DataBase.MongoDataBase.CurrentHall = new Hall()
                {
                    Name = tbHallName.Text,
                };

                _ = DataBase.MongoDataBase.AddHallToDataBase(DataBase.MongoDataBase.CurrentHall);
                MessageBox.Show("Кинозал был добавлен в базу данных");
            }
            else
                MessageBox.Show("Для создания нового кинозала все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
