using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.BL.Controller
{
    public class DataBaseManager
    {

        /// <summary>
        /// Сохранение элементов.
        /// </summary>
        /// <param name="name">Наименование элемента таблицы.</param>
        protected void Save<T>(T item) where T: class
        {
            using (var db = new MedicalProductContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение элементов таблицы.
        /// </summary>
        /// <returns>список элементов.</returns>
        protected List<T> Load<T>() where T: class
        {
            using (var db = new MedicalProductContext())

            {
                return db.Set<T>().Where(t => true).ToList() ?? new List<T>();
            }
        }
        /// <summary>
        /// Показать список элементов.
        /// </summary>
        protected void Show<T>() where T: class
        {
            using (var db = new MedicalProductContext())
            {
                var items = db.Set<T>().Where(t => true).ToList();
                foreach (var item in items)
                {
                    Console.Write(item.ToString());
                }
            };
        }
        /// <summary>
        /// Отчистить таблицу.
        /// </summary>
        /// <typeparam name="T">Класс таблицы.</typeparam>
        protected void RemoveRange<T>() where T : class
        {
            using (var db = new MedicalProductContext())
            {
                db.Set<T>().RemoveRange(db.Set<T>());
                db.SaveChanges();
            }
        }
    }
}
