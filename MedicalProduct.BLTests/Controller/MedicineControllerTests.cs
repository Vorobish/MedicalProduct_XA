using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class MedicineControllerTests : DataBaseManager
    {
        [TestMethod()]
        public void MedicineControllerTest()
        {
            string medicineName = Guid.NewGuid().ToString();
            var number = 5;
            var medController = new MedicineController(medicineName, number);
            medController.Save();

            Assert.AreEqual(number, medController.CurrentMedicine.Number);
        }

        [TestMethod()]
        public void SaveTest()
        {
            string medicineName = Guid.NewGuid().ToString();
            var number = 9;
            var medController = new MedicineController(medicineName, number);

            var number2 = 6;
            var medController2 = new MedicineController(medicineName, number2);

            Assert.IsFalse(medController2.IsNewMedicine);
        }
    }
}