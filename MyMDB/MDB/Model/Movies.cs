using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MDB.Model
{
    public class MoviesModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int OwnerId { get; set; }
        public string Release_date { get; set; }
        public bool Adult { get; set; }
        public double Rating { get; set; }
        public string Overview { get; set; }
        public string Poster { get; set; }
        public  List <int> Genre { get; set; }
    }

    public class DiscoverMovieModel
    {
        public DiscoverMovieModel()
        {
        }
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty ("total_results")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int Total_page { get; set; }

        [JsonProperty("results")]
        public List<RootDiscoverMovieModel> Results;

       
    }


    public class RootDiscoverMovieModel
    {
        public RootDiscoverMovieModel() { }
        [JsonProperty ("id")]
        public string ID { get; set; }

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("release_date")]
        public string Release_date { get; set; }

         [JsonProperty ("adult")]
        public bool Adult { get; set; }

        [JsonProperty ("vote_average")]
        public double Rating { get; set; }

        [JsonProperty ("overview")]
        public string Overview { get; set; }

        [JsonProperty ("poster_path")]
        public string Poster { get; set; }

        [JsonProperty("jenre_ids")]
        public List<int> Genre { get; set; }
      
    }

    public class GenreModel
    {
        [JsonProperty("id")]
       public int ID { get; set; }

        [JsonProperty("name")]
       public string Name { get; set; }
    }

    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoPath {get;set;}
        public string phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class FavoriteListModel: DiscoverMovieModel
    {

        public int FlistID { get; set; }
        public string FListName { get; set; }
    }
}
