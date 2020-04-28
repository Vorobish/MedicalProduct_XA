using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class IndicationsForUseControllerTests : DataBaseManager
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
            var medicineController = new MedicineController("Test", 5);
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(name);
            indicationController.CurrentIndicationsForUse.MedicineId = medicineController.CurrentMedicine.Id;
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