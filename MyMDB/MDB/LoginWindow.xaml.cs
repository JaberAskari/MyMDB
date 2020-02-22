                                                                                                                                                                                                                                                       using MDB.Model;
using MDB.ViewModel;
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
using System.Windows.Shapes;

namespace MDB
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
       
        
        int pagenum;
        public LoginWindow()
        {
            InitializeComponent();

            //Discovering moives from TMDB using API based on popularity
            //mvm.GetDiscoverMovies(ds,pagenum);

            //when application runs the first menu form left menu bar is selected (popular movie)
            lstSidemenu.SelectedItem = lstSidemenu.Items[0];
        }


        // Close button 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close MyMDB?", "shut down", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        //Minimize button
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Side menu selection indicator change
        private void lstSidemenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdSelected.Visibility = Visibility.Visible;
            int index = lstSidemenu.SelectedIndex;
            MoveGrdSelected(index);
        }

        //selected menu indicator
        private void MoveGrdSelected(int index)
        {
            grdSelected.Margin = new Thickness(0, (322 + (80 * index)), 0, 0);
        }

        //top drag bar
        private void bluebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }

        //Loading the popular movie page after clicking on the search button from the left side menu
        private void lstTrendingM_Selected(object sender, RoutedEventArgs e)
        {

            FMain.Content = new View.PopularMovies();

        }

        //Loading the search page after clicking on the search button from the left side menu
        private void lstSearchM_Selected(object sender, RoutedEventArgs e)
        {

            FMain.Content = new View.SearchMovies();
        }

        //login page after clicking on login button
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lstSidemenu.UnselectAll();
            View.Login l = new View.Login();
            FMain.Content =l;
            grdSelected.Visibility = Visibility.Hidden;

        }

        //oppening the about page
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            lstSidemenu.UnselectAll();
            FMain.Content = new View.About();
            grdSelected.Visibility = Visibility.Hidden;
           
        }
    }
}

    

