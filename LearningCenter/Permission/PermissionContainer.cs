using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Permission
{
    public class PermissionContainer
    {
        protected List<Permission> _permissions = new List<Permission>();

        public PermissionContainer(List<Permission> permissions)
        {
            _permissions = permissions;
        }

        public PermissionContainer()
        {
        }

        public bool ContainsType(Type type)
        {
            foreach(Permission permission in _permissions)
            {
                if(permission.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddPermission(Permission permission)
        {
            _permissions.Add(permission);
        }
    }
}
