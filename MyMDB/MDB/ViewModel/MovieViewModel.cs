using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDB.Model;
using TMDbLib.Client;
using TMDbLib.Objects.Collections;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Discover;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using MySql.Data.MySqlClient;

namespace MDB.ViewModel
{
    public class MovieViewModel
    {


        public static DiscoverMovieModel SearchResultMovies(string input, int pagenum)
        {
            DiscoverMovieModel d1 = new DiscoverMovieModel();
            if (input!=null || input != "")
            {

                string url = $"https://api.themoviedb.org/3/search/movie?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US&query={input}&page={pagenum}&include_adult=false";
                WebClient wc = new WebClient();
                string json = wc.DownloadString(url);
                var result1 = JsonConvert.DeserializeObject<dynamic>(json);
                d1.Page = result1.page;
                d1.Total_page = result1.total_pages;
                d1.Results = result1.results.ToObject<List<RootDiscoverMovieModel>>();
                
            }
            return d1;

        }





        // getting movies from tmdb on for the popular movie 
        public void GetDiscoverMovies(DiscoverMovieModel d1, int pagenum)
        {
            if (pagenum < 1)
            {
                pagenum = 1;
            } 
            string json ;
            string url ;
            //for (pagenum = 1; pagenum < maxpage; pagenum++)

                url = $"https://api.themoviedb.org/3/discover/movie?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page={pagenum}";
                WebClient wc = new WebClient();
                json = wc.DownloadString(url);
                var result1 = JsonConvert.DeserializeObject<dynamic>(json);
                d1.Page = result1.page;
                d1.Total_page = result1.total_pages;
                d1.Results = result1.results.ToObject<List<RootDiscoverMovieModel>>();
        }

        //getting genre list from tmdb api
        public static List<GenreModel> GetGenresList()
        {
            List<GenreModel> genre = new List<GenreModel>();
            string json;
            string url;
            url = "https://api.themoviedb.org/3/genre/movie/list?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US";
            WebClient wbc = new WebClient();
            json = wbc.DownloadString(url);
            var res = JsonConvert.DeserializeObject<dynamic>(json);
            genre = res.genres.ToObject<List<GenreModel>>();

            return genre;
        }


        //getting movies based on genre and year from tmodb api
        public static DiscoverMovieModel GetMoviesBasedOnGenre( int pagenum, string genre, int year)
        {
            DiscoverMovieModel d1 = new DiscoverMovieModel();
          
           
           
            string urlGenre= $"https://api.themoviedb.org/3/discover/movie?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page={pagenum}&with_genres={genre}";
            string urlYear = $"https://api.themoviedb.org/3/discover/movie?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page={pagenum}&primary_release_year={year}";
            string urlGenreYear= $"https://api.themoviedb.org/3/discover/movie?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page={pagenum}&with_genres={genre}&primary_release_year={year}";
            string url="";


            if ( genre != "0" && year == 0 )
            {
                url = urlGenre;
            }

            else if (year != 0 && genre == "0")
            {
                url = urlYear;
            }


            else if ( genre != "0" && year != 0 )
            {
                url = urlGenreYear;
            }

            WebClient wc = new WebClient();
            string json = wc.DownloadString(url);
            var result1 = JsonConvert.DeserializeObject<dynamic>(json);
            d1.Page = result1.page;
            d1.Total_page = result1.total_pages;
            d1.Results = result1.results.ToObject<List<RootDiscoverMovieModel>>();
            return d1;
        }


        //Getting the movies information from TMDB base on movie ID
        public static List <RootDiscoverMovieModel> GetMovieByIDFromTMDB( int ActiveUserID)
        {
          
            List<MoviesModel> MM = new List<MoviesModel>();
            MM=MysqlDB.GetAllMyMovies(ActiveUserID);
            
            string json;
            string url;

            List<RootDiscoverMovieModel> ML = new List<RootDiscoverMovieModel>();

            foreach(MoviesModel x in MM)
            {
                url = $"https://api.themoviedb.org/3/movie/{x.ID}?api_key=be89c231e0f9482fe3789d24bc90833d&language=en-US";
                WebClient wc = new WebClient();
                json = wc.DownloadString(url);

                var result = JsonConvert.DeserializeObject<dynamic>(json);

                RootDiscoverMovieModel d = new RootDiscoverMovieModel();

                d.ID = result.id;
                d.Title = result.title;
                d.Release_date = result.release_date;
                d.Adult = result.adult;
                d.Rating = result.vote_average;
                d.Overview = result.overview;
                d.Poster = result.poster_path;
                ML.Add(d);

            }
            return ML;
        }




    }
}
