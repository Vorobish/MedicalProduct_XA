﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class MedicineControllerTests : DataBaseManagerTest
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