using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроллер ввода позиций чека.
    /// </summary>
    public class PositionController : DataBaseManager
    {
        /// <summary>
        /// Конкретная позиция.
        /// </summary>
        public PositionPurchase CurrentPosition { get; set; }
        /// <summary>
        /// Общий список позиций.
        /// </summary>
        public List<PositionPurchase> Positions { get; set; }
        public PositionController() { }
        /// <summary>
        /// Контроль создания позиции покупки.
        /// </summary>
        /// <param name="purchase">Покупка, которой принадлежит позация.</param>
        /// <param name="medicine">Препарат позиции.</param>
        /// <param name="price">Цена препарата.</param>
        /// <param name="quantity">Количество купленных упаковок.</param>
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
            Positions = GetAllPosition();
            Positions.Add(CurrentPosition);
        }
        /// <summary>
        /// Сохранение позиции в БД.
        /// </summary>
        public void Save()
        {
            Save(CurrentPosition);
        }
        /// <summary>
        /// Получение списка всех позиций всех покупок.
        /// </summary>
        /// <returns>Список позиций.</returns>
        private List<PositionPurchase> GetAllPosition()
        {
            return Load<PositionPurchase>();
        }
        /// <summary>
        /// Показать общий список позиций.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Общий список позиций:");
            Show<PositionPurchase>();
        }
        /// <summary>
        /// Удалить список позиций.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<PositionPurchase>();
            Console.WriteLine("Все позиции удалены.");
        }
    }
}
