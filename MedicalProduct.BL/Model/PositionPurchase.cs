using System;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Позиция в покупке(строка)
    /// </summary>
    public class PositionPurchase
    {
        public int Id { get; set; }
        /// <summary>
        /// Покупка, которой принадлежит позиция.
        /// </summary>
        public Purchase Purchase { get; set; }
        /// <summary>
        /// Покупаемый препарат.
        /// </summary>
        public Medicine Medicine { get; set; }
        /// <summary>
        /// Количество единиц в упаковке.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Цена за 1 упаковку.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Количество упаковок.
        /// </summary>
        public int Quantity { get; set; }
        public PositionPurchase() { }
        /// <summary>
        /// Создание позиции в покупке.
        /// </summary>
        /// <param name="purchase">Покупка.</param>
        /// <param name="medicine">Лекарство.</param>
        /// <param name="number">количество единиц в упаковке.</param>
        /// <param name="price">Цена за упаковку.</param>
        /// <param name="quantity">Количество упаковок.</param>
        public PositionPurchase(Purchase purchase, Medicine medicine, int number, decimal price, int quantity)
        {
            Purchase = purchase ?? throw new ArgumentException("Покупка не найдена.", nameof(purchase));
            Medicine = medicine ?? throw new ArgumentException("Изделие медицинского назначения не идентифицировано.", nameof(medicine));
            if(number <= 0 || number > 300)
            {
                throw new ArgumentException("Количество единиц в упаковке не может быть отрицательным, либо равным нулю и не должно превышать 300.", nameof(number));
            }
            if(price < 0M || price > 1000000M)
            {
                throw new ArgumentException("Цена за упаковку не может быть отрицательной и не должна превышать 1 000 000-00 рублей.", nameof(price));
            }
            if (quantity <= 0 || quantity > 30)
            {
                throw new ArgumentException("Количество упаковок не может быть отрицательным, либо равным нулю и не должно превышать 30.", nameof(quantity));
            }
            Number = number;
            Price = price;
            Quantity = quantity;
        }
    }
}
