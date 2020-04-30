using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроль создания показаний к применению.
    /// </summary>
    public class IndicationsForUseController : DataBaseManager
    {

        /// <summary>
        /// Список недугов.
        /// </summary>
        public List<IndicationsForUse> IndicationsForUses { get; set; }
        /// <summary>
        /// Текущий недуг.
        /// </summary>
        public IndicationsForUse CurrentIndicationsForUse { get; set; }
        public IndicationsForUseController() { }

        /// <summary>
        /// Контроль добавления показаний к применению.
        /// </summary>
        public IndicationsForUseController(Medicine medicine, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование показания к применению не может быть пустым.", nameof(name));
            }
            IndicationsForUses = GetAllIndicationsForUses();
            CurrentIndicationsForUse = new IndicationsForUse(medicine, name);
            IndicationsForUses.Add(CurrentIndicationsForUse);
            Save();
        }
        /// <summary>
        /// Сохранение нового показания к применению.
        /// </summary>
        public void Save()
        {
            Save(CurrentIndicationsForUse);
        }
        /// <summary>
        /// Получение общего списка недугов.
        /// </summary>
        /// <returns></returns>
        public List<IndicationsForUse> GetAllIndicationsForUses()
        {
            return Load<IndicationsForUse>();
        }
        /// <summary>
        /// Вывести список показаний.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Общий список показаний к применению:");
            Show<IndicationsForUse>();
        }

        /// <summary>
        /// Отчистить таблицу недугов.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<IndicationsForUse>();
            Console.WriteLine("Все недуги удалены.");
        }
    }
}
