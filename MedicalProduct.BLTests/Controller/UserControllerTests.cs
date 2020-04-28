using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests : DataBaseManager
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            string userName = Guid.NewGuid().ToString();

            var userController = new UserController(userName);

            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            string userName = Guid.NewGuid().ToString();

            var userController = new UserController(userName);

            userController.Save();

            string userName2 = Guid.NewGuid().ToString();

            var userController2 = new UserController(userName2);

            var result = userController2.Users.SingleOrDefault(r => r.Name == userName);

            Assert.AreEqual(result.ToString(), userController.CurrentUser.ToString());
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            string userName = Guid.NewGuid().ToString();

            var userController = new UserController(userName);

            userController.Save();

            var userController2 = new UserController(userName);

            Assert.AreEqual(false, userController2.IsNewUser);
        }
    }
}