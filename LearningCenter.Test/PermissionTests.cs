using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningCenter.Users;
using LearningCenter.Permission;

namespace LearningCenter.Test
{
    [TestClass]
    public class PermissionTests
    {
        [TestMethod]
        public void TestContainsType()
        {
            User testUser = new User(-1, "Test", "Test");
            testUser.Permissions.AddPermission(new ViewSubordinates());
            Assert.IsTrue(testUser.Permissions.ContainsType(typeof(ViewSubordinates)));
            Assert.IsFalse(testUser.Permissions.ContainsType(typeof(TestPermission)));
            
        }
    }

    class TestPermission : Permission.Permission
    {

    }
}
