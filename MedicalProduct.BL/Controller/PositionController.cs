using MedicalProduct.BL.Model;
using System;

namespace MedicalProduct.BL.Controller
{
    public class PositionController
    {
        public PositionPurchase CurrentPosition { get; set; }
        public PositionController() { }
        public PositionController(Purchase purchase, Medicine medicine, decimal price, int quantity)
        {
            if (price < 0M || price > 500000M)
            {
                throw new ArgumentException("Цена не может быть отрицательной и не должна превышать 500 000-00 рублей.", nameof(price));
            }
            if (quantity <= 0 || quantity > 100)
            {
                throw new ArgumentException("Количество упаковок не может быть отрицательным, и не должно превышать 100 штук.", nameof(quantity));
            }
            CurrentPosition = new PositionPurchase(purchase, medicine, price, quantity);

            CurrentPosition.TotalPosition = price * quantity;
            CurrentPosition.PurchaseId = purchase.Id;
        }
    }
}
