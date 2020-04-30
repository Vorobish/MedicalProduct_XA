using MedicalProduct.BL.Controller;
using System;

namespace MedicalProduct.CMD
{
    public class Program
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
                Console.WriteLine("С - Добавить новую покупку.");
                Console.WriteLine("D - Найти и посмотреть конкретное изделие медицинского назначения по Id.");
                Console.WriteLine("E - Посмотреть список покупок.");
                Console.WriteLine("F - Найти и посмотреть конкретную покупку.");
                Console.WriteLine("G - Добавить изделие медицинского назначения в аптечку.");
                Console.WriteLine("H - Изменить количество единиц препарата в аптечке.");
                Console.WriteLine("I - Удалить все данные.");
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
                    #region С - Добавить новую покупку.
                    case ConsoleKey.C:
                        var moment = ParseDate("покупки.");
                        var purchaseController = new PurchaseController(userController.CurrentUser, moment);
                        var numberPosition = ParseInt("Количество препаратов в чеке.");
                        for (var j = 0; j < numberPosition; j++)
                        {
                            Console.WriteLine($"Заполняем {j+1} позицию.");
                            Console.WriteLine("Введите наименование препарата.");
                            var medNamePos = Console.ReadLine();
                            var numPos = ParseInt("Количество единиц в упаковке.");
                            var price = ParseDecimal("Цена за 1 упаковку.");
                            var quantity = ParseInt("Количество купленных упаковок.");
                            var numTotal = numPos * quantity;
                            var medContrPos = new MedicineController(medNamePos, numTotal);
                            #region Заполнение компонентов и показаний к применению, если лекарство новое.
                            if (medContrPos.IsNewMedicine == true)
                            {
                                //Компоненты.
                                Console.WriteLine("Заполняем состав медицинского изделия.");
                                var numberOfComponents = ParseInt("Количество компонентов в составе.");
                                for (var i = 0; i < numberOfComponents; i++)
                                {
                                    Console.WriteLine("Введите наименование компонента.");
                                    var componentName = Console.ReadLine();
                                    var componentController = new ComponentController(medContrPos.CurrentMedicine, componentName);
                                }
                                //Показания к применению.
                                Console.WriteLine("Заполняем показания к применению.");
                                var numberOfIndications = ParseInt("Количество показаний к применению.");
                                for (var i = 0; i < numberOfIndications; i++)
                                {
                                    Console.WriteLine("Введите наименование показания.");
                                    string indicationName = Console.ReadLine();
                                    var indicationController = new IndicationsForUseController(medContrPos.CurrentMedicine, indicationName);
                                }
                            }
                            #endregion
                            var positionContr = new PositionController(purchaseController.CurrentPurchase, medContrPos.CurrentMedicine, price, quantity);
                            positionContr.Save();
                        }
                        purchaseController.Total(purchaseController.CurrentPurchase.Id);
                        Console.WriteLine("Покупка создана.");
                        purchaseController.ShowOne(purchaseController.CurrentPurchase.Id);
                        break;
                    #endregion
                    #region D - Найти и посмотреть конкретное изделие медицинского назначения.
                    case ConsoleKey.D:
                        var currentMedicineID = ParseInt("Id изделия медицинского назначения.");
                        var showOne = new MedicineController();
                        showOne.ShowOne(currentMedicineID);
                        break;
                    #endregion
                    #region E - Посмотреть список покупок.
                    case ConsoleKey.E:
                        var purchase = new PurchaseController();
                        purchase.Show();
                        break;
                    #endregion
                    #region F - Найти и посмотреть конкретную покупку.
                    case ConsoleKey.F:
                        var currentPurchaseID = ParseInt("Id покупки.");
                        var showOnePur = new PurchaseController();
                        showOnePur.ShowOne(currentPurchaseID);
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
                                var componentController = new ComponentController(medicineController.CurrentMedicine, componentName);
                            }
                            //Показания к применению.
                            Console.WriteLine("Заполняем показания к применению.");
                            var numberOfIndications = ParseInt("Количество показаний к применению.");
                            for (var i = 0; i < numberOfIndications; i++)
                            {
                                Console.WriteLine("Введите наименование показания.");
                                string indicationName = Console.ReadLine();
                                var indicationController = new IndicationsForUseController(medicineController.CurrentMedicine, indicationName);
                            }
                            Console.WriteLine($"{medicineController.CurrentMedicine.Name} создан. ");
                        }
                        break;
                    #endregion
                    #region H - Изменить количество единиц препарата в аптечке по Id.
                    case ConsoleKey.H:
                        var medicineID = ParseInt("Id изделия медицинского назначения.");
                        var changeNumber = ParseInt("Итоговое количество единиц препарата.");
                        var change = new MedicineController();
                        change.ChangeNumber(medicineID, changeNumber);
                        break;
                    #endregion
                    #region I - Удалить все данные.
                    case ConsoleKey.I:
                        var u = new UserController();
                        u.RemoveRange();
                        var pu = new PurchaseController();
                        pu.RemoveRange();
                        var po = new PositionController();
                        po.RemoveRange();
                        var m = new MedicineController();
                        m.RemoveRange();
                        var c = new ComponentController();
                        c.RemoveRange();
                        var ind = new IndicationsForUseController();
                        ind.RemoveRange();
                        Console.WriteLine("Необходимо перезапустить приложение.");
                        Console.ReadLine();
                        Environment.Exit(0);
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

        private static DateTime ParseDate(string name)
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
