using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;
using System.IO;

namespace MDB.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        
       public List<Model.UserModel> ActiveUser;

        public Login()
        {
            InitializeComponent();
            txbEmail.Text = "jaber@gmail.com";
            txbPassword.Password = "jaber";
        }


        //Sign up button click. it will redirect the page to sign up page
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            //LoginWindow l = new LoginWindow();
            ((LoginWindow)System.Windows.Application.Current.MainWindow).FMain.Content = new View.Signup();
            //l.FMain.Content = new View.Signup();
        }



        //sign in button click it will check the user name and password
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            string pass = txbPassword.Password;
         
            //inviting the method to check the inserted email and password in the mysql database
            ActiveUser = ViewModel.MysqlDB.LoginCheck(email, pass);
          

            if (ActiveUser.Count==1)
            {
                MainWindow m = new MainWindow();
                
                //setting the full name of user
                string FullName = ActiveUser[0].FirstName.ToString() + " " + ActiveUser[0].LastName.ToString();
                m.txtUserName.Text = FullName;
                //setting the active user id in main page
                m.txtUserID.Text = ActiveUser[0].ID.ToString();

                //setting the right profile picture if the profile picture path is not null or empty 
                string photoPath = ActiveUser[0].PhotoPath;
                if (!string.IsNullOrEmpty(photoPath))
                {
                    string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ProfilePic\\"+photoPath;
                    if (File.Exists(folderpath))
                    {
                        var uriSource = new Uri($"{folderpath}", UriKind.RelativeOrAbsolute);
                        BitmapImage image = new BitmapImage(uriSource);
                        m.imgUser.Source = image;
                    }

                    else
                    {

                        BitmapImage image = new BitmapImage(new Uri("../photos/user2.png",UriKind.Relative));
                        m.imgUser.Source = image;


                    }
                 

                  
                }

                m.Show();

                ((LoginWindow)System.Windows.Application.Current.MainWindow).Close();
                //LoginWindow main = Application.Current.MainWindow as LoginWindow;
                //if (main != null)
                //{

                //    main.Close();
                //}



            }

            else
            {
                txtwelcome.Foreground = Brushes.Red;
                txtwelcome.Text = "Incorrect Email or Password!";
            }
            
        }
    }
}
