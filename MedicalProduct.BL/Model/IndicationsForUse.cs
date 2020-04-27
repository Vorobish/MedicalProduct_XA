using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Показание к применению.
    /// </summary>
    public class IndicationsForUse
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование недуга.
        /// </summary>
        public string Name { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public IndicationsForUse() { }
        /// <summary>
        /// Создание недуга.
        /// </summary>
        /// <param name="name">Наименование недуга.</param>
        public IndicationsForUse(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование недуга не может быть пустым.",nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"Наименование показания к применению: {Name}, Id недуга: {Id}, Id препарата: {MedicineId}\n";
        }

    }
}
