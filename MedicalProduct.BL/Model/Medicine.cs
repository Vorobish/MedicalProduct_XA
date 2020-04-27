using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Лекарство (в любых формах).
    /// </summary>
    public class Medicine
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование изделия медицинского назначения.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество единиц в упаковке.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Состав.
        /// </summary>
        public ICollection<Component> ComponentsInMedicine { get; set; }
        /// <summary>
        /// Показания к применению.
        /// </summary>
        public ICollection<IndicationsForUse> IndicationsForUseInMedicine { get; set; }

        public Medicine() { }
        /// <summary>
        /// Создание изделия медицинского назначения (по 2 критериям).
        /// </summary>
        /// <param name="name">Наименование изделия медицинского назначения.</param>
        /// <param name="number">Количество единиц в упаковке.</param>
        /// <param name="components">Состав.</param>
        /// <param name="indicationsForUses">Показания к применению.</param>
        public Medicine(string name, int number) 
        { 
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Наименование изделия медицинского назначения не может быть пустым.",nameof(name));
            }
        if(number < 0 || number > 200)
            {
                throw new ArgumentException("Количество не может быть отрицательным и не должно превышать 300 ед.", nameof(number));
            }
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Наименование изделия медицинского назначения: {Name}, Id лекарства: {Id}\n";
        }
    }
}
