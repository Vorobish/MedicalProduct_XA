using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalProduct.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalProduct.BL.Model;

namespace MedicalProduct.BL.Controller.Tests
{
    [TestClass()]
    public class PositionControllerTests
    {
        [TestMethod()]
        public void PositionControllerTest()
        {
            var purchase = new Purchase();
            var medicine = new Medicine();
            var price = 35M;
            var quantity = 2;

            var position = new PositionController(purchase, medicine, price, quantity);

            Assert.AreEqual(70M,position.CurrentPosition.TotalPosition);
        }

    }
}