using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроллер создания покупки.
    /// </summary>
    public class PurchaseController : DataBaseManager
    {
        /// <summary>
        /// Текущая покупка.
        /// </summary>
        public Purchase CurrentPurchase { get; set; }
        public List<Purchase> Purchases { get; set; }
        public PurchaseController() { }
        /// <summary>
        /// Создание новой покупки.
        /// </summary>
        /// <param name="userName">Текущий пользователь = покупатель.</param>
        /// <param name="moment">Дата покупки.</param>
        public PurchaseController(User user, DateTime moment)
        {
            CurrentPurchase = new Purchase(user, moment);
            Purchases = GetAllPurchases();
            Purchases.Add(CurrentPurchase);
            Save();            
        }
        /// <summary>
        /// Получение списка покупок.
        /// </summary>
        /// <returns>Общий список покупок.</returns>
        private List<Purchase> GetAllPurchases()
        {
            return Load<Purchase>();
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
        /// <summary>
        /// Сохранить текущую покупку.
        /// </summary>
        public void Save()
        {
            Save(CurrentPurchase);
        }

        /// <summary>
        /// Подсчет суммы покупки.
        /// </summary>
        /// <param name="id">Id покупки.</param>
        public void Total(int id)
        {
            using (var db = new MedicalProductContext())
            {
                Purchase pur = db.Purchases.SingleOrDefault(m => m.Id == id);
                if (pur == null)
                {
                    throw new ArgumentException($"Покупка с Id: {id} не найдена.", nameof(id));
                }
                List<PositionPurchase> posit = db.PositionPurchases.Where(c => c.PurchaseId == id).ToList();
                decimal sum = posit.Sum(x => x.TotalPosition);
                pur.Total = sum;
                db.SaveChanges();
            };
        }
        /// <summary>
        /// Показать расширенно конкретную покупку.
        /// </summary>
        /// <param name="id">Id покупки.</param>
        public void ShowOne(int id)
        {
            using (var db = new MedicalProductContext())
            {
                Purchase pur = db.Purchases.SingleOrDefault(m => m.Id == id);
                if (pur == null)
                {
                    throw new ArgumentException($"Покупка с Id: {id} не найдена.", nameof(id));
                }
                Console.Write(pur.ToString());
                Console.WriteLine("Позиции:");
                List<PositionPurchase> poss = db.PositionPurchases.Where(c => c.PurchaseId == id).ToList();
                foreach (var item in poss)
                {
                    Console.Write(item.ToString());
                }
            };
        }
    }
}
