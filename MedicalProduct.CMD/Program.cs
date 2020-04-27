using MedicalProduct.BL.Controller;
using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalProduct.CMD
{
    public class Program : DataBaseManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение MedicalProduct!");
            Console.WriteLine("Введите, пожалуйста, Ваше имя.");
            var userName = Console.ReadLine();
            var userController = new UserController(userName);
            if (userController.IsNewUser == true)
            {
                userController.Save();
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Какое действие Вы хотите выполнить?");
                Console.WriteLine("A - Закрыть приложение.");
                Console.WriteLine("B - Посмотреть список изделий медицинского назначения.НЕТ");
                Console.WriteLine("С - Добавить новую покупки.НЕТ");
                Console.WriteLine("D - Найти и посмотреть конкретное изделие медицинского назначения.НЕТ");
                Console.WriteLine("E - Посмотреть список покупок.НЕТ");
                Console.WriteLine("F - Найти и посмотреть конкретную покупку.НЕТ");
                Console.WriteLine("G - Добавить изделие медицинского назначения в аптечку.НЕТ");
                Console.WriteLine("H - Изменить количество единиц препарата в аптечке.НЕТ");
                Console.WriteLine();

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    #region A - Закрыть приложение.
                    case ConsoleKey.A:
                        Environment.Exit(0);
                        break;
                    #endregion
                    //case ConsoleKey.S: //Посмотреть список всех покупок.
                    //    var purchaseShow = new PurchaseController();
                    //    purchaseShow.Show();
                    //    break;
                    //case ConsoleKey.P: //Добавить новую покупку.
                    //    var moment = ParseDare("покупки");
                    //    var purchaseController = new PurchaseController(userName, moment);
                    //    Console.WriteLine("Заполняем список препаратов.");
                    //    var numOfPosition = ParseInt("Количество позиций в чеке");
                    //    if (numOfPosition > 50)
                    //    {
                    //        throw new ArgumentException("Значение не должно превышать 50 позиций", nameof(numOfPosition));
                    //    }
                    //    for (var i = 0; i < numOfPosition; i++)
                    //    {
                    //        Console.WriteLine("Введите наименование изделия медицинского назначения.");
                    //        var nameMedicines = Console.ReadLine();
                    //        var price = ParseDecimal("Цена за упаковку.");
                    //        var number = ParseInt("Количество единиц в упаковке.");
                    //        var quantity = ParseInt("Количество упаковок");
                    //        var components = new List<Component>();
                    //    }

                    //    break;
                    #region G - Добавить изделие медицинского назначения в аптечку.
                    //case ConsoleKey.G:
                    //    Console.WriteLine("Введите наименование изделия медицинского назначения.");
                    //    var medicineName = Console.ReadLine();
                    //    var number = ParseInt("Количество единиц препарата.");
                    //    var medicineController = new MedicineController(medicineName, number);
                        ////Заполнение компонентов и показаний к применению, если лекарство новое.
                        //if (medicineController.IsNewMedicine == true)
                        //{
                        //    //Компоненты.
                        //    Console.WriteLine("Заполняем состав медицинского изделия. Когда компоненты закончатся вместо наименования введите - 0.");
                        //    Console.WriteLine("Введите наименование компонента.");
                        //    string componentName = Console.ReadLine();
                        //    while (componentName == "0")
                        //    {
                        //        var componentController = new ComponentController(componentName);
                        //        componentController.CurrentComponent.MedicineId = medicineController.CurrentMedicine.Id;
                        //        componentController.Save();
                        //    }
                        //    //Показания к применению.
                        //    Console.WriteLine("Заполняем показания к применению. Когда список закончится вместо наименования введите - 0.");
                        //    Console.WriteLine("Введите наименование показания.");
                        //    string indicationName = Console.ReadLine();
                        //    while (indicationName == "0")
                        //    {
                        //        var indicationController = new IndicationsForUseController(indicationName);
                        //        indicationController.CurrentIndicationsForUse.MedicineId = medicineController.CurrentMedicine.Id;
                        //        indicationController.Save();
                        //    }
                        //    Console.WriteLine($"{medicineController.CurrentMedicine} создан. ");
                        //}
                        //break;
                        #endregion
                }
            }
        }

        private static Decimal ParseDecimal(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите значение: {name}");
                var price = Console.ReadLine();
                if (Decimal.TryParse(price, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Значение: {name} введено не корректно.");
                }
            }
        }

        private static DateTime ParseDare(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите дату {name} в формате ДД.ММ.ГГГГ.");
                var momPur = Console.ReadLine();
                if (DateTime.TryParse(momPur, out DateTime result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Значение даты {name} введено не корректно.");
                }
            }
        }

        public static int ParseInt(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}");
                var id = Console.ReadLine();
                if (int.TryParse(id, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Значение: {name} введено не корректно.");
                }
            }
        }


    }
}
