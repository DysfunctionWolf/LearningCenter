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
using LearningCenter.Database;
using LearningCenter.Users;

namespace LearningCenter.FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserDatabase _userDB = DatabaseFactory.GetUserDatabase(System.Environment.GetEnvironmentVariable("CONNECTIONSTRING", EnvironmentVariableTarget.Machine));
        User _authenticatedUser;

        public LoginWindow()
        {
            InitializeComponent();
        }

        protected void ResetTextBoxes()
        {
            textBox1.Text = "";
            passwordBox1.Password = "";
        }

        protected void Login(int id, string password)
        {
            if (_userDB.VerifyUser(id, password))
            {
                _authenticatedUser = _userDB.GetUserByID(id);
                TrainingWindow window = new TrainingWindow(_authenticatedUser);
                window.Show();
            }
            else
            {
                ResetTextBoxes();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(textBox1.Text);
            string password = passwordBox1.Password;
            Login(userId, password);
            this.Close();
        }
    }
}
