using System;
using System.Windows;
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
        UserContextSingleton _userContext = UserContextSingleton.GetInstance;

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
                _userContext.UserContext = _userDB.GetUserByID(id);
                TrainingWindow window = new TrainingWindow();
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
