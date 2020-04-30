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
            var med = new MedicineController("Test1", 7);
            string сomponentName = Guid.NewGuid().ToString();

            var componentController = new ComponentController(med.CurrentMedicine, сomponentName);

            Assert.AreEqual(сomponentName, componentController.CurrentComponent.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var medicineController = new MedicineController("Test2",5);
            string name = Guid.NewGuid().ToString();

            var componentController = new ComponentController(medicineController.CurrentMedicine, name);
            componentController.Save();

            string name2 = Guid.NewGuid().ToString();

            var componentController2 = new ComponentController(medicineController.CurrentMedicine, name2);

            var result = componentController2.Components.FirstOrDefault(r => r.Name == name);

            Assert.AreEqual(result.ToString(), componentController.CurrentComponent.ToString());
        }

        [TestMethod()]
        public void GetAllComponentsTest()
        {
            var med = new MedicineController("Test3", 9);
            string сomponentName = Guid.NewGuid().ToString();

            var componentController = new ComponentController(med.CurrentMedicine, сomponentName);

            Assert.AreEqual(med.CurrentMedicine.Id, componentController.CurrentComponent.MedicineId);
        }
    }
}