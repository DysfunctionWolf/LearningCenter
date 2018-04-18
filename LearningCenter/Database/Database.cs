using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Users;
using MySql.Data.MySqlClient;

namespace LearningCenter.Database
{
    public abstract class Database
    {
        protected MySqlConnection _connection;

        public virtual MySqlConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        public virtual string ConnectionString
        {
            get
            {
                return _connection.ConnectionString;
            }
        }

        protected virtual void AssignConnection(MySqlConnection connection)
        {
            _connection = connection;
        }
    }
}
