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

            CurrentMedicine = Medicines.FirstOrDefault(c => c.Name == medicineName);
            if (CurrentMedicine == null)
            {
                CurrentMedicine = new Medicine(medicineName, number);
                Medicines.Add(CurrentMedicine);
                IsNewMedicine = true;
                Save();
            }
            else
            {
                CurrentMedicine.Number = СhangeNumber(number);
                Saver();
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
        /// Изменение количества единиц препарата в аптечке.
        /// </summary>
        /// <param name="num">Количество прибавляемых единиц.</param>
        /// <returns>Итоговое количество единиц препарата в аптечке.</returns>
        private int СhangeNumber(int num)
        {
            using (var db = new MedicalProductContext())
            {
                int number = db.Entry(CurrentMedicine).Property(n=> n.Number).CurrentValue;
                int N = num + number;
                return db.Entry(CurrentMedicine).Property(u => u.Number).CurrentValue = N;
            };
        }
        public void IdMed3()
        {
            using (var db = new MedicalProductContext())

            {
                var Med2 = db.Medicines.Where(t => true).ToList();
                Med2.Clear();
                db.SaveChanges();
            }
        }
    }
}
