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
using MySql.Data.MySqlClient;

namespace MDB.View
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        DiscoverMovieModel SearchResultMovies = new DiscoverMovieModel();
        public string ActiveUserId;

        public Profile()
        {

            InitializeComponent();
            //GetUserInfo();
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
            //getting the active user information and movies
            try
            {
                int AcId = int.Parse(txtUserID.Text.ToString());
                List<Model.UserModel> ActiveUser = new List<UserModel>();
                ActiveUser = MysqlDB.GetActiveUserInfo(AcId);

                if (ActiveUser.Count == 1)
                {
                    txtName.Text = ActiveUser[0].FirstName;
                    txtLastName.Text = ActiveUser[0].LastName;
                    txtEmail.Text = ActiveUser[0].Email;
                    txtPhone.Text = ActiveUser[0].phone.ToString();
                    //setting the right profile picture if the profile picture path is not null or empty 
                    string photoPath = ActiveUser[0].PhotoPath;
                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ProfilePic\\";
                        var uriSource = new Uri($"{folderpath}{photoPath}", UriKind.RelativeOrAbsolute);
                        BitmapImage image = new BitmapImage(uriSource);

                        imgProfilePic.Source = image;
                    }
                }


                dgMovies.UnselectAll();
                int ActiveUId = int.Parse(ActiveUserId);
                //getting the movies of current user from mysql and them TMDB
                SearchResultMovies.Results = MovieViewModel.GetMovieByIDFromTMDB(ActiveUId);

                dgMovies.ItemsSource = SearchResultMovies.Results;
                dgMovies.Columns[0].Visibility = Visibility.Hidden;
                dgMovies.Columns[5].Visibility = Visibility.Hidden;
                dgMovies.Columns[6].Visibility = Visibility.Hidden;

            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }



        }

       
    }
}
