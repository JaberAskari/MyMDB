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
using MDB.ViewModel;
using MDB.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace MDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ActiveUserID;
      

        public MainWindow()
        {
            InitializeComponent();

            //when application runs the first menu form left menu bar is selected (tringding movie)
            lstSidemenu.SelectedItem = lstSidemenu.Items[0];

           txtUserID.Text= ActiveUserID;
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
        private void MoveGrdSelected ( int index)
        {
            grdSelected.Margin = new Thickness(0, (322+(80*index)), 0, 0);
        }

        //top drag bar
        private void bluebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
           
        }


        //popular movie page after clicking on the search button from the left side menu
        private void lstTrendingM_Selected(object sender, RoutedEventArgs e)
        {

            FMain.Content = new View.PopularMovies();

        }


        //Loading the search page after clicking on the search button from the left side menu
        private void lstSearchM_Selected(object sender, RoutedEventArgs e)
        {
            FMain.Content = new View.SearchMovies();
        }

        //Log out button event handler
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //((LoginWindow)System.Windows.Application.Current.MainWindow).Show();
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Close();
        }

        //oppening the about page
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            lstSidemenu.UnselectAll();
            FMain.Content = new View.About();
            grdSelected.Visibility = Visibility.Hidden;
        }


        //Loading the Add movie page 
        private void lstAdd_Selected(object sender, RoutedEventArgs e)
        {
            View.AddMovie addm = new View.AddMovie();
            addm.ActiveUserId = int.Parse(txtUserID.Text);

            FMain.Content = addm;

        }

        //Loading the Delete movie page 
        private void lstDel_Selected(object sender, RoutedEventArgs e)
        {
            View.DeleteMovie Dm = new View.DeleteMovie();
            Dm.ActiveUserId = int.Parse(txtUserID.Text);

            FMain.Content = Dm;

        }

        //Loading the profile page
        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            View.Profile p = new View.Profile();
            p.ActiveUserId = txtUserID.Text.ToString();
            p.txtUserID.Text = this.txtUserID.Text;
            FMain.Content = p;

        }
    }
}
