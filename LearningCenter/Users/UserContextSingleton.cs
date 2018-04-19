using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Users;

namespace LearningCenter.Users
{
    // stores the context to the user to be used throughout the application. this will generally be the user that has logged in
    public class UserContextSingleton
    {
        private static UserContextSingleton instance;

        private User _userContext;

        public User UserContext
        {
            get
            {
                return _userContext;
            }
            set
            {
                _userContext = value;
            }
        }

        public static UserContextSingleton GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UserContextSingleton();
                }
                return instance;
            }
        }

        private UserContextSingleton() { }
    }
}
