using System;
using System.Collections.Generic;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Покупка.
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        /// <summary>
        /// Дата покупки.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Список товаров данной покупки.
        /// </summary>
        public Dictionary<Medicine, int> Medicines { get; set; }
        /// <summary>
        /// Итоговая сумма затрат.
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// ID Пользователя, совершившего покупку.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь, совершивший покупку.
        /// </summary>
        public virtual User User { get; set; }
        public Purchase() { }
        /// <summary>
        /// Создание покупки.
        /// </summary>
        /// <param name="user">Пользователь регистрирующий покупку.</param>
        /// <param name="moment">Дата покупки.</param>
        public Purchase(User user, DateTime moment)
        {
            User = user ?? throw new ArgumentException("Не удалось идентифицировать пользователя.",nameof(user));
            if(moment < DateTime.Parse("01.01.2020") || moment > DateTime.Now)
            {
                throw new ArgumentException("Недопустимая дата покупки.", nameof(moment));
            }
            Moment = moment;
        }

        public Purchase(User user, DateTime moment, Dictionary<Medicine, int> medicines, decimal total)
        {
            User = user ?? throw new ArgumentException("Не удалось идентифицировать пользователя.", nameof(user));
            if (moment < DateTime.Parse("01.01.2020") || moment > DateTime.Now)
            {
                throw new ArgumentException("Недопустимая дата покупки.", nameof(moment));
            }
            Moment = moment;
            Medicines = medicines;
            Total = total;
        }

        public override string ToString()
        {
            return $"Покупка №: {Id}, дата покупки: {Moment}, сумма чека: {Total}\n";
        }
    }

}
