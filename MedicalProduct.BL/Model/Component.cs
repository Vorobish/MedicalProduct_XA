using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Компонент (состав).
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование компонента.
        /// </summary>
        public string Name { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public Component() { }
        /// <summary>
        /// Создание нового компонента.
        /// </summary>
        /// <param name="name">Наименование компонента.</param>
        public Component(Medicine medicine, string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length > 100)
            {
                throw new ArgumentNullException("Наименование компонента не может быть пустым и не должно превышать 100 знаков.", nameof(name));
            }
            Name = name;
            MedicineId = medicine.Id;
        }
        public override string ToString()
        {
            return $"{Name}\n";
        }
    }
}
