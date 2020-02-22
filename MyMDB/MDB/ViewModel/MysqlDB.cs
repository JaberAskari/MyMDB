using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MDB.ViewModel
{
    class MysqlDB
    {

        //Mysql connection link and password
        private static string GetMysqlConnectionString()
        {
            //yhteys Mysql palveluun
            //string ss = "M38SboekhtjbppUeNMreT6AFbkafjnXk";
            //return $"Data source =mysql.labranet.jamk.fi;Initial Catalog=M2947_2;user=M2947;password={ss}";

            return "Server=mysql.labranet.jamk.fi;Database=M2947_2;UID=M2947;Password=M38SboekhtjbppUeNMreT6AFbkafjnXk;SslMode=none";

        }


        //getting the list of all the email already having an account in the service
        public static List<Model.UserModel> EmailChecker()
        {
            try
            {
                string connstr = GetMysqlConnectionString();
                string sql = $"SELECT Email FROM user";

                List<Model.UserModel> EmailList = new List<Model.UserModel>();

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.UserModel u = new Model.UserModel();
                                u.Email = reader.GetString(0);

                                EmailList.Add(u);
                            }

                            return EmailList;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        //inserts a new user into the mysql database
        public void AddUserToMysql(Model.UserModel u)
        {
            string firstname = u.FirstName;
            string lastname = u.LastName;
            string email = u.Email;
            string phone = u.phone;
            string pass = u.Password;
            string path = u.PhotoPath;
            try
            {
                string connstr = GetMysqlConnectionString();
                string sql = $"INSERT INTO user (Name,LastName,Email,Phone,Password,PhotoPath) VALUES ('{firstname}', '{lastname}', '{email}', '{phone}',MD5('{pass}'), '{path}')";


                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }
        //Movie checker. it checks before inserting the movie into user's database if it already exist or not
        public List<Model.MoviesModel> MovieChecker(int ActiveUser_ID, int MovieId)
        {
            string connstring = GetMysqlConnectionString();
            string mysql = $"SELECT user_ID,tmdbID FROM Movie where user_ID={ActiveUser_ID} AND tmdbID={MovieId}";
            List<Model.MoviesModel> ml = new List<Model.MoviesModel>();
            Model.MoviesModel m = new Model.MoviesModel();

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(mysql, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            m.OwnerId = int.Parse(reader.GetString(0));
                            m.ID = int.Parse(reader.GetString(1));
                            ml.Add(m);
                        }
                        return ml;
                    }
                }
            }

        }


        //Inserts new movie into the movie table of mysql database
        public void AddMovieToMysql(int ActiveUser_ID, int MovieId)
        {

            try
            {

                string connstr = GetMysqlConnectionString();
                string sql = $"INSERT INTO Movie (user_ID,tmdbID) VALUES ({ActiveUser_ID}, {MovieId})";
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch
            {
                throw;
            }
        }


        //It gets a table consist of the given email and passowd from the user tabel
        public static List<Model.UserModel> LoginCheck(string email, string password)
        {
            try
            {
                string connstr = GetMysqlConnectionString();
                //string sql = $"SELECT ID,Email,Password FROM user WHERE Email='" + email + "' AND Password=MD5('" + password + "')";
                string sql = $"SELECT ID,Email,Password,Name,LastName,Phone,PhotoPath FROM user WHERE Email='{email}' AND Password=MD5('{password}')";
                List<Model.UserModel> ActiveUser = new List<Model.UserModel>();

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Model.UserModel u = new Model.UserModel();
                                u.ID = reader.GetInt32(0);
                                u.Email = reader.GetString(1);
                                u.Password = reader.GetString(2);
                                u.FirstName = reader.GetString(3);
                                u.LastName = reader.GetString(4);
                                u.phone = reader.GetString(5);
                                u.PhotoPath = reader.GetString(6);

                                ActiveUser.Add(u);
                            }
                            return ActiveUser;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //Deleting selected movie form mysql database
        public static void DeleteMovieFromMysql(int MovieID)
        {
            try
            {

                string connstr = GetMysqlConnectionString();
                string sql = $"Delete From Movie WHERE tmdbID={MovieID}";
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch
            {
                throw;
            }
        }


        //getting a list of all movies of a user saved in  mysql database 
        public static List<Model.MoviesModel> GetAllMyMovies(int ActiveUser_ID)
        {
            try
            {
                string connstring = GetMysqlConnectionString();
                string mysql = $"SELECT tmdbID FROM Movie WHERE user_ID={ActiveUser_ID}";

                List<Model.MoviesModel> ml = new List<Model.MoviesModel>();


                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(mysql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Model.MoviesModel m = new Model.MoviesModel();
                                m.ID = int.Parse(reader.GetString(0));
                                ml.Add(m);
                            }
                            return ml;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        //Getting active user information
        public static List<Model.UserModel> GetActiveUserInfo(int ActiveUserId)
        {
            try
            {
                int id = ActiveUserId;
                string connstr = "Server=mysql.labranet.jamk.fi;Database=M2947_2;UID=M2947;Password=M38SboekhtjbppUeNMreT6AFbkafjnXk;SslMode=none";

                string sql = $"SELECT ID,Email,Password,Name,LastName,Phone,PhotoPath FROM user WHERE ID={id}";
                List<Model.UserModel> ActiveUser = new List<Model.UserModel>();

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Model.UserModel u = new Model.UserModel();
                                u.ID = reader.GetInt32(0);
                                u.Email = reader.GetString(1);
                                u.Password = reader.GetString(2);
                                u.FirstName = reader.GetString(3);
                                u.LastName = reader.GetString(4);
                                u.phone = reader.GetString(5);
                                u.PhotoPath = reader.GetString(6);

                                ActiveUser.Add(u);
                            }
                            return ActiveUser;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
