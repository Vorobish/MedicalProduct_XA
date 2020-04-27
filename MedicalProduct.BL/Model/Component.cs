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
        public Component(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование компонента не может быть пустым.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"Наименование компонента: {Name}, Id компонента: {Id}, Id препарата: {MedicineId}\n";
        }
    }
}
