using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SearchMovies.xaml
    /// </summary>
    /// 
  
    public partial class SearchMovies : Page
    {

        DiscoverMovieModel SearchResultMovies = new DiscoverMovieModel();
        //List<MoviesModel> SearchResultMovies = new List<MoviesModel>();
        MovieViewModel mvm = new MovieViewModel();
        List<GenreModel> genreList;
        int pagenum = 1;
        string page;
        int totalpage;
        int i=0;


        public SearchMovies()
        {
            InitializeComponent();

        }




        //Loading the selected movie descritpion in the right side menue
        private void dgMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                //loading selected movie title and description

                int rowCount = SearchResultMovies.Results.Count();
                i = dgMovies.SelectedIndex;
                if (i == -1)
                {
                    i = 0;
                }
                if (i <= rowCount || i >= 0 || rowCount != 0)

                {
                    //loading selected movie title and description
                    txtDescription.Text = "Description: " + SearchResultMovies.Results[i].Overview.ToString();
                    txtNameM.Text = "Title: " + SearchResultMovies.Results[i].Title.ToString();
                    //loading selected movie poster

                    string posterPath = SearchResultMovies.Results[i].Poster.ToString();
                    string url = $"https://image.tmdb.org/t/p/w500/{posterPath}";
                    var uriSource = new Uri(url, UriKind.Absolute);

                    imgPoster.Source = new BitmapImage(uriSource);
                }
                else { }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //search button click 
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgMovies.UnselectAll();
          
          

            //getting the right ID of each genre type in combo box
            string genre="All";
            int selectedGenreIndex = cbxGenre.SelectedIndex;
            int selectedGenreID = genreList[selectedGenreIndex].ID;
            genre = selectedGenreID.ToString();
            

            //getting selected item from year combo box
            int year;
            int.TryParse(cbxYear.SelectedValue.ToString(), out year);

            //getting key word value
            string keyword = txbKeyword.Text.ToString();


            if ((keyword == "") && (genre == "0") && year == 0)
            {
                txtMessage.Text = "Please Chose or write a key word to search!3";

            }

            else if (keyword != "" && year == 0 && genre == "0")
            {
                SearchResultMovies = MovieViewModel.SearchResultMovies(keyword, pagenum);
              
            }


            else 
            {
                if(keyword == "")
                {
                    SearchResultMovies= MovieViewModel.GetMoviesBasedOnGenre(pagenum, genre, year);
                
                }
              
                else
                {
                    DiscoverMovieModel dmv = MovieViewModel.GetMoviesBasedOnGenre(pagenum, genre, year);
                    SearchResultMovies.Total_page = dmv.Total_page;
                    SearchResultMovies.Page = dmv.Page;
                    SearchResultMovies.Results = new List<RootDiscoverMovieModel>(dmv.Results.Where(x => x.Title.StartsWith(keyword)));

                }
            }
            page = SearchResultMovies.Page.ToString();
            

            totalpage = SearchResultMovies.Total_page;
            txtPageNumMax.Text = $" ... {totalpage}";

            dgMovies.ItemsSource = SearchResultMovies.Results;
            dgMovies.Columns[0].Visibility = Visibility.Hidden;
            dgMovies.Columns[5].Visibility = Visibility.Hidden;
            dgMovies.Columns[6].Visibility = Visibility.Hidden;
        }



        //combo box Genre values
        private void cbxGenre_Loaded(object sender, RoutedEventArgs e)
        {
             genreList = MovieViewModel.GetGenresList();
            genreList.Insert(0,new GenreModel { Name = "All", ID=0 });

            var genre = genreList.Select(x => x.Name).Distinct();
            cbxGenre.ItemsSource = genre;
            cbxGenre.SelectedItem = "All";
        }

        //Combo box year  values
        private void cbxYear_Loaded(object sender, RoutedEventArgs e)
        {
            int y = DateTime.Now.Year;

            List<int> year = new List<int>();
            //int x = 1980;
            for (int x =y;x>=1980; x--)
            {
                year.Add(x);
            }
            year.Insert(0, 0);
            cbxYear.ItemsSource=year;
            cbxYear.SelectedItem = 0;

        }

        //Next page button for data grid sources
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
          
            pagenum += 1;
            
            

            //string page = SearchResultMovies.Page.ToString();
            //int totalpage = SearchResultMovies.Total_page;

            txtPageNumLast.Text = $"{pagenum - 1}";
            txtPageNumCur.Text = $"{pagenum}";
            txtPageNumNext.Text = $"{pagenum + 1}";
    

            if (pagenum == totalpage || pagenum > totalpage)
            {
                btnNext.IsEnabled = false;
            }

            if (pagenum - 1 >= 1)
            {
                btnPrevious.IsEnabled = true;
                txtPageNumLast.Visibility = Visibility.Visible;

            }
            else
            {
                btnNext.IsEnabled = true;
            }
            btnSearch_Click(sender, e);
        }

        //Previous page button for data grid sources
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            pagenum -= 1;
            //mvm.GetDiscoverMovies(dss, pagenum);
      

            //string page = SearchResultMovies.Page.ToString();
            //int totalpage = SearchResultMovies.Total_page;

            txtPageNumLast.Text = $"{pagenum - 1}";
            txtPageNumCur.Text = $"{pagenum}";
            txtPageNumNext.Text = $"{pagenum + 1}";
            //txtPageNumMax.Text = $" ... {totalpage}";

            if (pagenum <= 1)
            {
                btnPrevious.IsEnabled = false;
                txtPageNumLast.Visibility = Visibility.Hidden;
            }

           if (pagenum < totalpage)
            {
                btnNext.IsEnabled = true;
            }
            btnSearch_Click(sender, e);
        }

        private void txbKeyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            pagenum = 1;
            btnPrevious.IsEnabled = false;
        }

        private void cbxYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pagenum = 1;
            btnPrevious.IsEnabled = false;
        }

        private void cbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pagenum = 1;
            btnPrevious.IsEnabled = false;
    
        }
    }
}

