using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalProduct.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalProduct.BLTests.Controller;
using MedicalProduct.BL.Model;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests : DataBaseManagerTest
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