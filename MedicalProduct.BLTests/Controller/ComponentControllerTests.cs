using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class ComponentControllerTests : DataBaseManager
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
            var medicineController = new MedicineController("Test",5);
            string name = Guid.NewGuid().ToString();

            var componentController = new ComponentController(name);
            componentController.CurrentComponent.MedicineId = medicineController.CurrentMedicine.Id;
            componentController.Save();

            string name2 = Guid.NewGuid().ToString();

            var componentController2 = new ComponentController(name2);
            componentController2.CurrentComponent.MedicineId = medicineController.CurrentMedicine.Id;
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