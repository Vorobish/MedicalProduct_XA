using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalProduct.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalProduct.BLTests.Controller;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class ComponentControllerTests : DataBaseManagerTest
    {
        [TestMethod()]
        public void ComponentControllerTest()
        {
            string сomponentName = Guid.NewGuid().ToString();

            var componentController = new ComponentController(сomponentName);

            Assert.AreEqual(сomponentName, componentController.CurrentComponent.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            string name = Guid.NewGuid().ToString();

            var componentController = new ComponentController(name);

            componentController.Save();

            string name2 = Guid.NewGuid().ToString();

            var componentController2 = new ComponentController(name2);

            var result = componentController2.Components.SingleOrDefault(r => r.Name == name);

            Assert.AreEqual(result.ToString(), componentController.CurrentComponent.ToString());
        }

        [TestMethod()]
        public void GetAllComponentsTest()
        {
            string сomponentName = Guid.NewGuid().ToString();

            var componentController = new ComponentController(сomponentName);

            Assert.AreEqual(true, componentController.IsNewComponent);
        }
    }
}