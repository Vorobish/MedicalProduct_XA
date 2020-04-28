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

            var number2 = 6;
            var medController2 = new MedicineController(medicineName, number2);

            var sum = number + number2;

            Assert.AreEqual(medicineName, medController.CurrentMedicine.Name);
            Assert.AreEqual(sum, medController2.CurrentMedicine.Number);
        }

        [TestMethod()]
        public void SaveTest()
        {
            string medicineName = Guid.NewGuid().ToString();
            var number = 5;
            var medController = new MedicineController(medicineName, number);
            medController.Save();

            var number2 = 6;
            var medController2 = new MedicineController(medicineName, number2);

            Assert.IsFalse(medController2.IsNewMedicine);
        }
    }
}