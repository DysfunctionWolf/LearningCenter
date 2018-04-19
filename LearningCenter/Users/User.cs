using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LearningCenter.Permission;


namespace LearningCenter.Users
{
    public class User
    {
        protected int _id;
        protected string _firstName;
        protected string _lastName;
        protected PermissionContainer _permissions = new PermissionContainer();

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public PermissionContainer Permissions
        {
            get
            {
                return _permissions;
            }
        }

        public User(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }

        public User(string id, string firstName, string lastName)
        {
            // if the id only contains numbers. Note: Even space will count as a non number
            if (Regex.IsMatch(id, @"^[0-9]+$"))
            {
                int convertedID = Convert.ToInt32(id);
                _id = convertedID;
                _firstName = firstName;
                _lastName = lastName;
            }
            else
            {
                throw new InvalidOperationException("id must only contain numbers. Cannot even contain spaces.");
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("User Id: ");
            stringBuilder.Append(_id);
            stringBuilder.Append("FirstName: ");
            stringBuilder.Append(_firstName);
            stringBuilder.Append(" LastName: ");
            stringBuilder.Append(_lastName);
            return stringBuilder.ToString();
        }

    }
}
