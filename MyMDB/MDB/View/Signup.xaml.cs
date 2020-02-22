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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Resources;

namespace MDB.View
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        string photoName;

        public Signup()
        {
            InitializeComponent();
        }



        // Sign up button. it checks each filled space and saves the information into the mysql database
        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            MDB.Model.UserModel user = new Model.UserModel();
            user.FirstName = txbFirstName.Text.ToString();
            user.LastName = txbLastName.Text.ToString();
            user.Email = txbEmail.Text.ToString();
            user.phone = txbPhone.Text.ToString();
        
            user.Password = txbPassword.Password.ToString();
            string RetypePassword = txbPasswordRetype.Password.ToString();


            bool em = MysqlDB.EmailChecker().Exists(x => x.Email == user.Email);

            if (user.FirstName == null || user.FirstName == "" || user.FirstName == "First Name" || user.LastName == null || user.LastName == "" || user.LastName == "Last Name")
            {
                txtMessage.Text = "Please insert your name and last name!";
                txbFirstName.Focus();

            }

            else if (em == true)
            {
                txtMessage.Text = "You already have an account with this email address!";
                txbEmail.Focus();

            }

            else if (!Regex.IsMatch(user.Email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txtMessage.Text = "Enter a valid email.";
                txbEmail.Focus();
            }

            else if (user.phone.Length < 10 || !int.TryParse(user.phone, out int num))
            {
                txtMessage.Text = "Enter valid mobile number";
                txbPhone.Focus();
            }

            else if (user.Password == "" || user.Password == null)
            {
                txtMessage.Text = "Please insert a password";
                txbPassword.Focus();
                txbPasswordRetype.Focus();
            }


            else if (user.Password != RetypePassword)
            {
                txtMessage.Text = "Inserted passwords do not match! Retype the same password!";
                txbPassword.Focus();
                txbPasswordRetype.Focus();
            }



            else
            {
                if (txbProfilePicture.Text == null || txbProfilePicture.Text == "")
                {
                    user.PhotoPath = null;
                }
                else
                {
                    try
                    {
                        //saving the selected profile picture into profilePictures directory
                        string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ProfilePic\\";
                        string imageAddress = $"{folderpath}{photoName}";
                        int count = 0;
                        string xx;
                        if (!Directory.Exists(folderpath))
                        {
                            Directory.CreateDirectory(folderpath);
                        }


                        while (File.Exists(imageAddress))
                        {

                            count++;
                            string[] x = photoName.Split('.');
                            string y = x.Last();
                            x[x.Length - 1] = $"{count}.{y}";
                            xx = string.Join("", x);
                            photoName = xx;
                           imageAddress = $"{folderpath}{photoName}";
                        }
                
                        
                        user.PhotoPath = photoName;
                            //string filePath = folderpath + System.IO.Path.GetFileName(txbProfilePicture.Text);
                            string filePath = folderpath + photoName;
                            File.Copy(txbProfilePicture.Text, filePath, true);

                       



                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                    

                MysqlDB mysql = new MysqlDB();
                mysql.AddUserToMysql(user);

                Login l = new Login();
                l.txtMessage.Foreground = Brushes.DarkSlateBlue;
                l.txtwelcome.Text = "Congratulations! You have successfully created your accout! Please Log in!";
                ((LoginWindow)System.Windows.Application.Current.MainWindow).FMain.Content = l;

            }

        }
    
        //browsing for profile picture
        private void btnSelectProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension  
            openFileDlg.DefaultExt = ".png";
            openFileDlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDlg.InitialDirectory = @"C:\Temp\";
           
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                //gets the address of the selected image
                txbProfilePicture.Text = openFileDlg.FileName;

                //gets onley the name of the selected image
                photoName = openFileDlg.SafeFileName;
           
                //Loading seleted image in image box
                imgProfilePicture.Source = new BitmapImage(new Uri (openFileDlg.FileName));

            }

           
        }


    }
}
