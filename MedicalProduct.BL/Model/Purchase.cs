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
        public ICollection<PositionPurchase> PositionPurchases { get; set; }
        public Purchase() { }
        /// <summary>
        /// Создание покупки.
        /// </summary>
        /// <param name="user">Пользователь регистрирующий покупку.</param>
        /// <param name="moment">Дата покупки.</param>
        public Purchase(User user, DateTime moment)
        {
            if (moment < DateTime.Parse("01.01.2020") || moment > DateTime.Now)
            {
                throw new ArgumentException("Недопустимая дата покупки.", nameof(moment));
            }
            Moment = moment;
            UserId = user.Id;
        }

        public override string ToString()
        {
            return $"Покупка №: {Id} ({User.Name}), дата покупки: {Moment}, сумма чека: {Total}\n";
        }
    }

}
