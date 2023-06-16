using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaWPF.Navigation;

namespace CinemaWPF.Navigation
{
    public class NavClass
    {
        public static bool isAuth = false;
        public static bool isRed = false;
        public static MainWindow main;
        public static List<NavComponentsClass> navs = new List<NavComponentsClass>();

        private static void Update(NavComponentsClass nav)
        {
            main.tbTitle.Text = nav.PageTitle;
            main.MainFrame.Navigate(nav.Page);
        }

        public static void NextPage(NavComponentsClass nav)
        {
            navs.Add(nav);
            Update(nav);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
            {
                navs.Remove(navs[navs.Count - 1]);
                Update(navs[navs.Count - 1]);
            }
        }
    }
}
