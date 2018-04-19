using System.Windows;
using LearningCenter.Users;


namespace LearningCenter.FrontEnd
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        public TrainingWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow employeeWindow = new EmployeeListWindow();
            employeeWindow.Show();
        }
    }
}
