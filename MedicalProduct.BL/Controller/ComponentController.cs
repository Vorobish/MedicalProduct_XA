using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    /// <summary>
    /// Контроль создания новых компонентов.
    /// </summary>
    public class ComponentController : DataBaseManager
    {
        /// <summary>
        /// Список компонентов.
        /// </summary>
        public List<Component> Components { get; set; }
        /// <summary>
        /// Текущий компонент.
        /// </summary>
        public Component CurrentComponent { get; set; }
        public bool IsNewComponent { get; set; } = false;
        public ComponentController() { }

        /// <summary>
        /// Контроль добавления компонентов.
        /// </summary>
        public ComponentController(string componentName)
        {
            if (string.IsNullOrWhiteSpace(componentName))
            {
                throw new ArgumentNullException("Наименование компонента не может быть пустым.", nameof(componentName));
            }

            Components = GetAllComponents();

            CurrentComponent = Components.FirstOrDefault(c => c.Name == componentName);
            if (CurrentComponent == null)
            {
                CurrentComponent = new Component(componentName);
                Components.Add(CurrentComponent);
                IsNewComponent = true;
            }
        }
        /// <summary>
        /// Сохранение нового компонента.
        /// </summary>
        public void Save()
        {
            Save(CurrentComponent);
        }
        /// <summary>
        /// Получение общего списка компонентов.
        /// </summary>
        /// <returns></returns>
        public List<Component> GetAllComponents()
        {
            return Load<Component>();
        }
        /// <summary>
        /// Вывести общий спиок компонентов.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Общий список компонентов:");
            Show<Component>();
        }

        /// <summary>
        /// Отчистить таблицу компонентов.
        /// </summary>
        public void RemoveRange()
        {
            RemoveRange<Component>();
            Console.WriteLine("Все компоненты удалены.");
        }
    }
}
