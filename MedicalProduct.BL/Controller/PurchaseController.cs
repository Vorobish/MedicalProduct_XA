using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;

namespace MedicalProduct.BL.Controller
{
    public class PurchaseController : DataBaseManager
    {
        /// <summary>
        /// Список покупок.
        /// </summary>
        public List<Purchase> Purchases { get; set; }
        /// <summary>
        /// Текущая покупка.
        /// </summary>
        public Purchase CurrentPurchase { get; set; }
        /// <summary>
        /// Список изделий медицинского назначения.
        /// </summary>
        public List<Medicine> Medicines { get; set; }
        /// <summary>
        /// Список медицинских компонентов (входящих в состав препаратов.).
        /// </summary>
        public List<Component> Components { get; set; }
        /// <summary>
        /// Список недугов (показания к применению препаратов).
        /// </summary>
        public List<IndicationsForUse> indicationsForUses { get; set; }
        public PurchaseController() { }
        /// <summary>
        /// Создание новой покупки.
        /// </summary>
        /// <param name="userName">Текущий пользователь = покупатель.</param>
        /// <param name="moment">Дата покупки.</param>
        public PurchaseController(string userName, DateTime moment)
        {
            var dictionary = new Dictionary<Medicine, int>();
            
        }
        /// <summary>
        /// Показать список покупок.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Список покупок:");
            Show<Purchase>();
        }

        /// <summary>
        /// Отчистить таблицу покупок.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<Purchase>();
            Console.WriteLine("Все покупки удалены.");
        }
    }
}
