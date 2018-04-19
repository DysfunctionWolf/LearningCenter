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
using System.Windows.Shapes;
using LearningCenter.Database;
using LearningCenter.Users;

namespace LearningCenter.FrontEnd
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        UserDatabase _userDB;
        UserContextSingleton _userContext = UserContextSingleton.GetInstance;
        EmployeeListWindow _employees;
        EmployeeWindowAction _action = EmployeeWindowAction.Add;
        User _editedUser;

        public EmployeeWindow(UserDatabase userDB, EmployeeListWindow employees)
        {
            _userDB = userDB;
            _employees = employees;
            InitializeComponent();
        }

        public void ConfigureToEdit(User user)
        {
            _action = EmployeeWindowAction.Edit;
            _editedUser = user;
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_action == EmployeeWindowAction.Add)
            {
                AddUserToDB(GetUserFromTextBoxes());
            }
            else
            {
                if (_editedUser != null)
                {
                    EditUserOnDB(_editedUser);
                }
            }
            Close();
        }

        private User GetUserFromTextBoxes()
        {
            return new User(-1, FirstNameTextBox.Text, LastNameTextBox.Text);
        }

        private void AddUserToDB(User user)
        {
            int newUserId = _userDB.AddUser(user);
            AssignSuperior(newUserId);
            _employees.Invalidate();
        }

        private void AssignSuperior(int subordinateID)
        {
            EmployeeHierarchyDatabase database = new EmployeeHierarchyDatabase(_userDB.Connection);
            database.AssignSuperior(subordinateID, _userContext.UserContext.ID);
        }

        private void EditUserOnDB(User user)
        {
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            _userDB.EditUser(user);
            _employees.Invalidate();
        }
    }

    public enum EmployeeWindowAction
    {
        Add,
        Edit
    }
}
