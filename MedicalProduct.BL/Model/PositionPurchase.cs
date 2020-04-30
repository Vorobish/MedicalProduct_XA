using System;
using System.Collections.Generic;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Позиция в покупке(строка)
    /// </summary>
    public class PositionPurchase
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        /// <summary>
        /// Цена за 1 упаковку.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Количество упаковок.
        /// </summary>
        public int Quantity { get; set; }
        public decimal TotalPosition { get; set; }
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public PositionPurchase() { }
        /// <summary>
        /// Создание позиции в покупке.
        /// </summary>
        /// <param name="purchase">Покупка.</param>
        /// <param name="medicine">Лекарство.</param>
        /// <param name="number">количество единиц в упаковке.</param>
        /// <param name="price">Цена за упаковку.</param>
        /// <param name="quantity">Количество упаковок.</param>
        public PositionPurchase(Purchase purchase, Medicine medicine, decimal price, int quantity)
        {
            if(price < 0M || price > 1000000M)
            {
                throw new ArgumentException("Цена за упаковку не может быть отрицательной и не должна превышать 1 000 000-00 рублей.", nameof(price));
            }
            if (quantity <= 0 || quantity > 30)
            {
                throw new ArgumentException("Количество упаковок не может быть отрицательным, либо равным нулю и не должно превышать 30.", nameof(quantity));
            }
            PurchaseId = purchase.Id;
            Price = price;
            Quantity = quantity;
            TotalPosition = Price * Quantity;
            MedicineName = medicine.Name;
        }
        public override string ToString()
        {
            return $" Покупка {PurchaseId}. {MedicineName} : {Price} руб. * {Quantity} уп. = {TotalPosition} руб.\n";
        }
    }
}
