﻿using MedicalProduct.BL.Controller;
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
                Console.WriteLine("B - Посмотреть список изделий медицинского назначения.");
                Console.WriteLine("С - Добавить новую покупки.НЕТ");
                Console.WriteLine("D - Найти и посмотреть конкретное изделие медицинского назначения.НЕТ");
                Console.WriteLine("E - Посмотреть список покупок.НЕТ");
                Console.WriteLine("F - Найти и посмотреть конкретную покупку.НЕТ");
                Console.WriteLine("G - Добавить изделие медицинского назначения в аптечку.");
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
                    #region B - Посмотреть список изделий медицинского назначения.
                    case ConsoleKey.B:
                        var medicineShow = new MedicineController();
                        medicineShow.Show();
                        break;
                    #endregion

                    #region G - Добавить изделие медицинского назначения в аптечку.
                    case ConsoleKey.G:
                        Console.WriteLine("Введите наименование изделия медицинского назначения.");
                        var medicineName = Console.ReadLine();
                        var number = ParseInt("Количество единиц препарата.");
                        var medicineController = new MedicineController(medicineName, number);
                        //Заполнение компонентов и показаний к применению, если лекарство новое.
                        if (medicineController.IsNewMedicine == true)
                        {
                            //Компоненты.
                            Console.WriteLine("Заполняем состав медицинского изделия.");
                            var numberOfComponents = ParseInt("Количество компонентов в составе.");
                            for(var i =0; i<numberOfComponents; i++)
                            {
                                Console.WriteLine("Введите наименование компонента.");
                                var componentName = Console.ReadLine();
                                var componentController = new ComponentController(componentName);
                                componentController.CurrentComponent.MedicineId = medicineController.CurrentMedicine.Id;
                                componentController.Save();
                            }
                            //Показания к применению.
                            Console.WriteLine("Заполняем показания к применению.");
                            var numberOfIndications = ParseInt("Количество показаний к применению.");
                            for (var i = 0; i < numberOfIndications; i++)
                            {
                                Console.WriteLine("Введите наименование показания.");
                                string indicationName = Console.ReadLine();
                                var indicationController = new IndicationsForUseController(indicationName);
                                indicationController.CurrentIndicationsForUse.MedicineId = medicineController.CurrentMedicine.Id;
                                indicationController.Save();
                            }
                            Console.WriteLine($"{medicineController.CurrentMedicine.Name} создан. ");
                        }
                        else
                        {
                            Console.WriteLine($"Препарат добавлен. Итоговое количество = {medicineController.CurrentMedicine.Number}");
                        }
                        break;
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
