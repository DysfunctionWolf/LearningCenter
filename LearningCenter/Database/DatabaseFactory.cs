using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace LearningCenter.Database
{
    public class DatabaseFactory
    {
        public static UserDatabase GetUserDatabase(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return new UserDatabase(connection);
        }

        public static EmployeeHierarchyDatabase GetEmployeeHierarchyDatabase(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return new EmployeeHierarchyDatabase(connection);
        }
    }
}
