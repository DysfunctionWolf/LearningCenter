using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LearningCenter.Users;
using LearningCenter.Database;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LearningCenter.FrontEnd
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class EmployeeListWindow : Window
    {
        public List<User> _users = new List<User>();
        string _connectionString = System.Environment.GetEnvironmentVariable("CONNECTIONSTRING", EnvironmentVariableTarget.Machine);
        UserDatabase _userDB;

        public EmployeeListWindow()
        {
            InitializeComponent();
            DataContext = this;
            _userDB = new UserDatabase(_connectionString);
            Console.WriteLine(_connectionString);
        }

        public void Invalidate()
        {
            listView.ItemsSource = null;
            _users.Clear();
            PopulateListview();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateListview();
        }

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(_userDB, this);
            employeeWindow.Show();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveSelectedEmployees();
        }

        private void RemoveSelectedEmployees()
        {
            if (System.Windows.MessageBox.Show("Remove selected employees?", "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                List<User> usersToRemove = new List<User>();
                usersToRemove.AddRange(listView.SelectedItems.Cast<User>());
                _userDB.RemoveUsers(usersToRemove);
                Invalidate();
            }
        }

        private void PopulateListview()
        {
            _users.AddRange(_userDB.GetAllUsers());
            listView.ItemsSource = _users;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(_userDB, this);
            employeeWindow.ConfigureToEdit(listView.SelectedItem as User);
            employeeWindow.Show();
        }
    }
}
