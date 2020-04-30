﻿using System;
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
        public IndicationsForUse(Medicine medicine, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 100)
            {
                throw new ArgumentNullException("Наименование недуга не может быть пустым и не должно превышать 100 знаков.",nameof(name));
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
