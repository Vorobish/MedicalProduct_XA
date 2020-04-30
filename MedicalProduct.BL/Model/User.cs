﻿using System;
using System.Collections.Generic;

namespace MedicalProduct.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }
        public ICollection<Purchase> PurchasesUser { get; set; }
        public User() { }
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length > 100)
            {
                throw new ArgumentNullException("Имя пользователя не может пустым и не должно превышать 100 знаков.", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, Id {Id}\n";
        }

    }
}
