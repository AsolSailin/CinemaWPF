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
using System.IO;
using CinemaWPF.Navigation;
using System.Collections;

namespace CinemaWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для InitialPage.xaml
    /// </summary>

    public partial class InitialPage : Page
    {
        public InitialPage()
        {
            InitializeComponent();
            lvMovies.ItemsSource = DataBase.MongoDataBase.GetMovieList();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item && item.IsSelected)
            {
                object o = lvMovies.SelectedItem;
                ListViewItem lvi = (ListViewItem)lvMovies.ItemContainerGenerator.ContainerFromItem(o);
                TextBlock tb = FindByName("tbName", lvi) as TextBlock;

                tb?.Dispatcher.BeginInvoke(new Func<bool>(tb.Focus));

                DataBase.MongoDataBase.CurrentMovie = DataBase.MongoDataBase.FindByMovieName(tb.Text);
                NavClass.NextPage(new NavComponentsClass("ИНФОРМАЦИЯ О ФИЛЬМЕ", new MovieInfoPage()));
            }
        }

        private FrameworkElement FindByName(string name, FrameworkElement root)
        {
            Stack<FrameworkElement> tree = new Stack<FrameworkElement>();
            tree.Push(root);

            while (tree.Count > 0)
            {
                FrameworkElement current = tree.Pop();
                if (current.Name == name)
                    return current;

                int count = VisualTreeHelper.GetChildrenCount(current);
                for (int i = 0; i < count; ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(current, i);
                    if (child is FrameworkElement element)
                        tree.Push(element);
                }
            }

            return null;
        }
    }
}
