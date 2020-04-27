using System;

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
        public User() { }
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может пустым.", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, Id {Id}\n";
        }

    }
}
