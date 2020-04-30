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
            var med = new MedicineController("Test1",6);
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(med.CurrentMedicine, name);

            Assert.AreEqual(name, indicationController.CurrentIndicationsForUse.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var medicineController = new MedicineController("Test2", 5);
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(medicineController.CurrentMedicine, name);
            indicationController.Save();

            string name2 = Guid.NewGuid().ToString();

            var indicationController2 = new IndicationsForUseController(medicineController.CurrentMedicine, name2);

            var result = indicationController2.IndicationsForUses.FirstOrDefault(r => r.Name == name);

            Assert.AreEqual(result.ToString(), indicationController.CurrentIndicationsForUse.ToString());
        }

        [TestMethod()]
        public void GetAllIndicationsForUsesTest()
        {
            var med = new MedicineController("Test3",9);
            string name = Guid.NewGuid().ToString();

            var indicationController = new IndicationsForUseController(med.CurrentMedicine, name);

            Assert.AreEqual(med.CurrentMedicine.Id, indicationController.CurrentIndicationsForUse.MedicineId);
        }
    }
}