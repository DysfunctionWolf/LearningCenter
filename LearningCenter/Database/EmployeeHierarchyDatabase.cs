using LearningCenter.Users;
using MySql.Data.MySqlClient;

namespace LearningCenter.Database
{
    public class EmployeeHierarchyDatabase : Database
    {
        public EmployeeHierarchyDatabase(MySqlConnection connection)
        {
            AssignConnection(connection);
        }

        public void AssignSuperior(User employee, User superior)
        {
            AssignSuperior(employee.ID, superior.ID);
        }

        public void AssignSuperior(int employee, int superior)
        {
            using (_connection)
            {
                _connection.Open();
                string command = string.Format(@"INSERT INTO employee_hierarchey (employee_id, superior_id) VALUES ('{0}', '{1}')", employee, superior);
                new MySqlCommand(command, _connection).ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
