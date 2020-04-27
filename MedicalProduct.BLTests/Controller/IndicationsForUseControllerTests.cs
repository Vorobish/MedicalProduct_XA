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
    public class IndicationsForUseControllerTests : DataBaseManagerTest
    {
        [TestMethod()]
        public void IndicationsForUseControllerTest()
        {
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(name);

            Assert.AreEqual(name, indicationController.CurrentIndicationsForUse.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(name);

            indicationController.Save();

            string name2 = Guid.NewGuid().ToString();

            var indicationController2 = new IndicationsForUseController(name2);

            var result = indicationController2.IndicationsForUses.SingleOrDefault(r => r.Name == name);

            Assert.AreEqual(result.ToString(), indicationController.CurrentIndicationsForUse.ToString());
        }

        [TestMethod()]
        public void GetAllIndicationsForUsesTest()
        {
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(name);

            Assert.IsTrue(indicationController.IsNewIndicationsForUse);
        }
    }
}