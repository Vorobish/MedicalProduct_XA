using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроль списка пользователей.
    /// </summary>
    public class UserController : DataBaseManager
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; set; }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; set; }
        public bool IsNewUser { get; set; } = false;
        public UserController() { }

        /// <summary>
        /// Контроль добавления пользователя.
        /// </summary>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Length > 100)
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым и не должно превышать 100 знаков.", nameof(userName));
            }

            Users = GetAllUsers();

            CurrentUser = Users.SingleOrDefault(c => c.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Сохранение нового пользователя.
        /// </summary>
        public void Save()
        {
            Save(CurrentUser);
        }
        /// <summary>
        /// Получение списка зарегистрированных пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public List<User> GetAllUsers()
        {
            return Load<User>();
        }
        /// <summary>
        /// Вывод общего списка пользователей.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Все пользователи:");
            Show<User>();
        }
        /// <summary>
        /// Отчистить таблицу пользователей.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<User>();
            Console.WriteLine("Все пользователи удалены.");
        }
    }
}
