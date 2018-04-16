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
    public partial class MainWindow : Window
    {
        UserDatabase _ud = new UserDatabase(System.Environment.GetEnvironmentVariable("CONNECTIONSTRING", EnvironmentVariableTarget.Machine));

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            if(_ud.VerifyUser(Convert.ToInt32(textBox1.Text), passwordBox1.Password))
            {
                window.Show();
            }
            else
            {
                textBox1.Text = "";
                passwordBox1.Password = "";
            }

            this.Close();
        }
    }
}
