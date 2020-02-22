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
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Page
    {
        DiscoverMovieModel SearchResultMovies = new DiscoverMovieModel();

        int pagenum = 1;
        string page;
        int totalpage;
        int SelectedMovieID;
        string SelectedMovieTitle;
        public int ActiveUserId;

        public AddMovie()
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
                int i = dgMovies.SelectedIndex;
                if (i == -1)
                {
                    i = 0;
                }
                if (i <= rowCount || i >= 0 || rowCount != 0)
                {
                    //loading selected movie title and description
                    txtDescription.Text = "Description: " + SearchResultMovies.Results[i].Overview.ToString();
                    txtNameM.Text = "Title: " + SearchResultMovies.Results[i].Title.ToString();

                    //selected movie ID and title
                    SelectedMovieID = int.Parse(SearchResultMovies.Results[i].ID);
                    SelectedMovieTitle= SearchResultMovies.Results[i].Title.ToString();
                    txtSelectedMovie.Foreground = Brushes.DarkBlue;
                    txtSelectedMovie.Text="ID: "+ SearchResultMovies.Results[i].ID.ToString()+"  Title: "+SearchResultMovies.Results[i].Title.ToString();
                   
                    //loading selected movie poster
                    string posterPath = SearchResultMovies.Results[i].Poster.ToString();
                    string url = $"https://image.tmdb.org/t/p/w500/{posterPath}";
                    var uriSource = new Uri(url, UriKind.Absolute);

                    imgPoster.Source = new BitmapImage(uriSource);
                }
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

            //getting key word value
            string keyword = txbKeyword.Text.ToString();

            if (keyword == "")
            {
                txtMessage.Text = "Please Chose or write a key word to search!3";
            }

            else if (keyword != "")
            {
                SearchResultMovies = MovieViewModel.SearchResultMovies(keyword, pagenum);
            }

            page = SearchResultMovies.Page.ToString();

            totalpage = SearchResultMovies.Total_page;
            txtPageNumMax.Text = $" ... {totalpage}";

            dgMovies.ItemsSource = SearchResultMovies.Results;
            dgMovies.Columns[0].Visibility = Visibility.Hidden;
            dgMovies.Columns[5].Visibility = Visibility.Hidden;
            dgMovies.Columns[6].Visibility = Visibility.Hidden;
        }

        //Next page button for data grid sources
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pagenum += 1;
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
            txtPageNumLast.Text = $"{pagenum - 1}";
            txtPageNumCur.Text = $"{pagenum}";
            txtPageNumNext.Text = $"{pagenum + 1}";

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

        //Adding the selected movie to mysql data base
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        
            int uID = ActiveUserId;
            int MovieID = SelectedMovieID;
            MysqlDB mysql = new MysqlDB();
            
            try
            {
                //checking if the selected movie is already in the database or not
                List<MoviesModel> Ml = mysql.MovieChecker(uID, MovieID);

                if(Ml.Count==0)
                {
                    //adding the selecetd movie to mysql using movie id and active user id.
                    mysql.AddMovieToMysql(uID, MovieID);
                    MessageBox.Show($"{SelectedMovieTitle} Successfully added to your database.");
                }
                else
                {
                    MessageBox.Show($"{SelectedMovieTitle} Already exist in your database. Please select another Movie!");
                }

            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }

        }
    }


}

