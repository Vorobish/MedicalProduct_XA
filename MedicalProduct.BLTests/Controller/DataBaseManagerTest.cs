using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProduct.BLTests.Controller
{
    public class DataBaseManagerTest
    {


        /// <summary>
        /// Сохранение элементов.
        /// </summary>
        /// <param name="name">Наименование элемента таблицы.</param>
        protected void Save<T>(T item) where T : class
        {
            using (var db = new MedicalProductContextTests())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получение элементов таблицы.
        /// </summary>
        /// <returns>список элементов.</returns>
        protected List<T> Load<T>() where T : class
        {
            using (var db = new MedicalProductContextTests())

            {
                var result = db.Set<T>().Where(t => true).ToList();
                if (result == null)
                {
                    result = new List<T>();
                }
                return result;
            }
        }
        /// <summary>
        /// Показать списка элементов.
        /// </summary>
        protected void Show<T>() where T : class
        {
            using (var db = new MedicalProductContextTests())
            {
                var items = db.Set<T>().Where(t => true).ToList();
                foreach (var item in items)
                {
                    Console.Write(item.ToString());
                }
            };
        }
    }
}
