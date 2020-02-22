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
using MDB.Model;
using MDB.ViewModel;

namespace MDB.View
{
    /// <summary>
    /// Interaction logic for PopularMovies.xaml
    /// </summary>
    /// 


  

    public partial class PopularMovies : Page
    {
        
   
        MovieViewModel mvm = new MovieViewModel();
        DiscoverMovieModel dss = new DiscoverMovieModel();
        int pagenum=1;
        int i = 0;



        public PopularMovies()
        {
            InitializeComponent();

         
            //getting the discover menu data for data grid
            //dss =((LoginWindow)System.Windows.Application.Current.MainWindow).ds;
            mvm.GetDiscoverMovies(dss, pagenum);
            txtPageNumMax.Text = $" ... {dss.Total_page.ToString()}";


        }

   
        

        

        // trinding movies data grid fill
        private void dgMovies_Loaded(object sender, RoutedEventArgs e)
        {
            //mvm.GetDiscoverMovies(dss, pagenum);

            dgMovies.ItemsSource = dss.Results;
            dgMovies.Columns[0].Visibility = Visibility.Hidden;
            dgMovies.Columns[5].Visibility = Visibility.Hidden;
            dgMovies.Columns[6].Visibility = Visibility.Hidden;

        }



        //Loading the selected movie descritpion in the right side menue
        private void dgMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                //loading selected movie title and description


                i = dgMovies.SelectedIndex;

                if (i >= 0)
                {
                    txtDescription.Text = "Description: " + dss.Results[i].Overview.ToString();
                    txtNameM.Text = "Title: " + dss.Results[i].Title.ToString();

                    //loading selected movie poster

                    string posterPath = dss.Results[i].Poster.ToString();
                    string url = $"https://image.tmdb.org/t/p/w500/{posterPath}";
                    var uriSource = new Uri(url, UriKind.Absolute);

                    imgPoster.Source = new BitmapImage(uriSource);
                }
                else
                {
                    i = 0;
                }
          
              


            }
            catch (Exception)
            {
                throw;
            }

        }

        //Next page button for data grid sources
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           
            pagenum += 1;
            mvm.GetDiscoverMovies(dss, pagenum);
            dgMovies_Loaded(sender,e);

           string page= dss.Page.ToString();
            int totalpage = dss.Total_page;

            txtPageNumLast.Text = $"{pagenum - 1}";
            txtPageNumCur.Text = $"{pagenum}";
            txtPageNumNext.Text = $"{pagenum + 1}";
            txtPageNumMax.Text = $" ... {totalpage}";

            if (pagenum==totalpage || pagenum > totalpage)
            {
                btnNext.IsEnabled = false;
            }

            else if(pagenum-1 >= 1)
            {
                btnPrevious.IsEnabled = true;
                txtPageNumLast.Visibility = Visibility.Visible;

            }
            else
            {
                btnNext.IsEnabled = true;
            }
         
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            pagenum -= 1;
            mvm.GetDiscoverMovies(dss, pagenum);
            dgMovies_Loaded(sender, e);

            string page = dss.Page.ToString();
            int totalpage = dss.Total_page;

            txtPageNumLast.Text = $"{pagenum - 1}";
            txtPageNumCur.Text = $"{pagenum}";
            txtPageNumNext.Text = $"{pagenum + 1}";
            txtPageNumMax.Text = $" ... {totalpage}";

            if (pagenum <= 1 )
            {
                btnPrevious.IsEnabled = false;
                txtPageNumLast.Visibility = Visibility.Hidden;
            }

            else if (pagenum < totalpage)
            {
                btnNext.IsEnabled = true;
            }

        }
    }



   
}
