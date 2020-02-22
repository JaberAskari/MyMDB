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
    /// Interaction logic for DeleteMovie.xaml
    /// </summary>
    public partial class DeleteMovie : Page
    {
        DiscoverMovieModel SearchResultMovies = new DiscoverMovieModel();
      
        int SelectedMovieID;
        string SelectedMovieTitle;
        public int ActiveUserId;

        public DeleteMovie()
        {
            InitializeComponent();
        }

        //Deleting the selected movie for mysql database
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Are you sure that you want to delete *{SelectedMovieTitle}* from your database?", $"Delete {SelectedMovieTitle}", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MysqlDB.DeleteMovieFromMysql(SelectedMovieID);
                    dgMovies_Loaded(sender, e);
                    MessageBox.Show($"Movie Successfully deleted from your database!");
                }
              
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        //Loading the selected movie descritpion in the right side menue
        private void dgMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btnDelete.IsEnabled = true;
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
                    SelectedMovieTitle = SearchResultMovies.Results[i].Title.ToString();
                    txtSelectedMovie.Foreground = Brushes.DarkBlue;
                    txtSelectedMovie.Text = "ID: " + SearchResultMovies.Results[i].ID.ToString() + "  Title: " + SearchResultMovies.Results[i].Title.ToString();

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


        private void dgMovies_Loaded(object sender, RoutedEventArgs e)
        {
            dgMovies.UnselectAll();

            SearchResultMovies.Results= MovieViewModel.GetMovieByIDFromTMDB(ActiveUserId);

          

            dgMovies.ItemsSource = SearchResultMovies.Results;
            dgMovies.Columns[0].Visibility = Visibility.Hidden;
            dgMovies.Columns[5].Visibility = Visibility.Hidden;
            dgMovies.Columns[6].Visibility = Visibility.Hidden;
        }

        

    }


}

