using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроль создания изделия медицинского назначения.
    /// </summary>
    public class MedicineController : DataBaseManager
    {
        /// <summary>
        /// Список изделий медицинского назначения.
        /// </summary>
        public List<Medicine> Medicines { get; set; }
        /// <summary>
        /// Текущий препарат.
        /// </summary>
        public Medicine CurrentMedicine { get; set; }
        public bool IsNewMedicine { get; set; } = false;
        public MedicineController() { }
        public MedicineController(string medicineName, int number)
        {
            if (string.IsNullOrWhiteSpace(medicineName))
            {
                throw new ArgumentNullException("Наименование препарата не может быть пустым.", nameof(medicineName));
            }

            if (number <= 0 || number > 300)
            {
                throw new ArgumentException("Количество не может быть отрицательным, и не должно быть больше 300 единиц.", nameof(number));
            }

            Medicines = GetAllMedicines();

            CurrentMedicine = Medicines.SingleOrDefault(c => c.Name == medicineName);
            if (CurrentMedicine == null)
            {
                CurrentMedicine = new Medicine(medicineName, number);
                Medicines.Add(CurrentMedicine);
                IsNewMedicine = true;
                Save();
            }
            else
            {
                var numCurr = GetNumber();
                var N = numCurr + number;
                ChangeNumber(CurrentMedicine.Id, N);
            }
        }
        /// <summary>
        /// Показать список препаратов.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Общий список изделий медицинского назначения:");
            Show<Medicine>();
        }
        /// <summary>
        /// Сохранение нового лекарства.
        /// </summary>
        public void Save()
        {
            Save(CurrentMedicine);
        }
        /// <summary>
        /// Получение общего списка изделий медицинского назначения.
        /// </summary>
        /// <returns>Список лекарств.</returns>
        private List<Medicine> GetAllMedicines()
        {
            return Load<Medicine>();
        }
        /// <summary>
        /// Получить количество единиц препарата в аптечке.
        /// </summary>
        /// <param name="num">Количество прибавляемых единиц.</param>
        /// <returns>Итоговое количество единиц препарата в аптечке.</returns>
        private int GetNumber()
        {
            using (var db = new MedicalProductContext())
            {
                int num = db.Entry(CurrentMedicine).Property(n=> n.Number).CurrentValue;
                return num;
            };
        }
        /// <summary>
        /// Показать конкретный препарат полностью (состав, показания к прменению).
        /// </summary>
        /// <param name="id">Id конкретного препарата.</param>
        public void ShowOne(int id)
        {
            using (var db = new MedicalProductContext())
            {
                Medicine med = db.Medicines.SingleOrDefault(m => m.Id == id);
                if(med == null)
                {
                    throw new ArgumentException($"Изделие медицинского назначения с Id: {id} не найдено.", nameof(id)) ;
                }
                Console.Write(med.ToString());
                Console.WriteLine("Состав:");
                List<Component> comps = db.Components.Where(c => c.MedicineId == id).ToList();
                foreach(var item in comps)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine("Показания к применению:");
                List<IndicationsForUse> inds = db.IndicationsForUses.Where(c => c.MedicineId == id).ToList();
                foreach (var item in inds)
                {
                    Console.Write(item.ToString());
                }
            };
        }

        public void ChangeNumber(int id, int num)
        {
            if (num < 0 || num > 600)
            {
                throw new ArgumentException("Количество не может быть отрицательным, и не должно быть больше 600 единиц.", nameof(num));
            }
            using (var db = new MedicalProductContext())
            {
                Medicine med = db.Medicines.SingleOrDefault(m => m.Id == id);
                if (med == null)
                {
                    throw new ArgumentException($"Изделие медицинского назначения с Id: {id} не найдено.", nameof(id));
                }
                db.Entry(med).Property(u => u.Number).CurrentValue = num;
                db.SaveChanges();
                Console.Write(med.ToString());
            };
        }

        /// <summary>
        /// Отчистить таблицу лекарств.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<Medicine>();
            Console.WriteLine("Все лекарства удалены.");
        }
    }
}
