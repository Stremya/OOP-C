using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Задание 1
    /*
    class Program5
    {
        static void Main()
        {
            Console.WriteLine("=== Безопасное деление и работа с массивами ===\n");

            double[] results = new double[3];      // массив для хранения результатов
            int resultIndex = 0;                   // текущий индекс в массиве
            bool continueProgram = true;           // флаг продолжения программы

            while (continueProgram && resultIndex < 3)
            {
                try
                {
                    Console.Write("Введите первое целое число: ");
                    string input1 = Console.ReadLine();
                    int number1 = int.Parse(input1);

                    Console.Write("Введите второе целое число: ");
                    string input2 = Console.ReadLine();
                    int number2 = int.Parse(input2);

                    double result = (double)number1 / number2;
                    Console.WriteLine($"Результат деления {number1} / {number2} = {result:F2}");

                    results[resultIndex] = result;
                    resultIndex++;

                    Console.WriteLine($"Результат сохранён в массив. Занято элементов: {resultIndex} из {results.Length}");
                    Console.WriteLine("Текущее содержимое массива: " + string.Join(" | ", results));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Массив результатов заполнен, дальнейшие вычисления невозможны");
                    continueProgram = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Попытка выполнения операции завершена");
                    Console.WriteLine(new string('-', 50));
                }

                if (resultIndex < 3 && continueProgram)
                {
                    Console.Write("\nХотите продолжить? (да/нет): ");
                    string answer = Console.ReadLine().ToLower();

                    if (answer != "да" && answer != "yes" && answer != "д" && answer != "y")
                    {
                        continueProgram = false;
                        Console.WriteLine("Программа завершена пользователем.");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n=== ИТОГИ РАБОТЫ ===");
            Console.WriteLine($"Количество успешных операций: {resultIndex}");
            Console.WriteLine("Сохранённые результаты:");

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"  results[{i}] = {results[i]}");
            }

            Console.WriteLine("\nПрограмма завершена.");
            Console.ReadKey();
        }
    }
    */

    // Задание 2

    // Пользовательское исключение для некорректной суммы
    public class InvalidAmountException : Exception
    {
        public decimal InvalidAmount { get; set; }     // некорректная сумма

        public InvalidAmountException()
            : base() { }

        public InvalidAmountException(string message)
            : base(message) { }

        public InvalidAmountException(string message, Exception innerException)
            : base(message, innerException) { }

        public InvalidAmountException(string message, decimal invalidAmount)
            : base(message)
        {
            InvalidAmount = invalidAmount;
        }
    }

    // Пользовательское исключение для недостатка средств
    public class InsufficientFundsException : Exception
    {
        public decimal CurrentBalance { get; set; }    // текущий баланс
        public decimal RequestedAmount { get; set; }   // запрашиваемая сумма
        public decimal Shortage { get; set; }          // нехватка средств

        public InsufficientFundsException()
            : base() { }

        public InsufficientFundsException(string message)
            : base(message) { }

        public InsufficientFundsException(string message, Exception innerException)
            : base(message, innerException) { }

        public InsufficientFundsException(string message, decimal currentBalance,
                                          decimal requestedAmount)
            : base(message)
        {
            CurrentBalance = currentBalance;
            RequestedAmount = requestedAmount;
            Shortage = requestedAmount - currentBalance;
        }
    }

    // Банковский счёт
    public class BankAccount
    {
        public string AccountNumber { get; private set; }  // номер счёта
        public decimal Balance { get; private set; }       // баланс счёта
        public string OwnerName { get; set; }              // имя владельца
        public DateTime CreationDate { get; private set; } // дата создания счёта
        private static int accountCounter = 0;             // счётчик для генерации номеров

        public BankAccount(string ownerName = "")
        {
            OwnerName = ownerName;
            Balance = 0;
            CreationDate = DateTime.Now;
            AccountNumber = GenerateAccountNumber();
        }

        // Генерация номера счёта
        private string GenerateAccountNumber()
        {
            accountCounter++;
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string counterPart = accountCounter.ToString("D8");
            return $"{datePart}-{counterPart}";
        }

        // Метод пополнения счёта
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException(
                    "Сумма пополнения должна быть положительной",
                    amount
                );
            }

            if (amount > 1000000)
            {
                throw new InvalidAmountException(
                    "Сумма пополнения не может превышать 1 000 000 за одну операцию",
                    amount
                );
            }

            Balance += amount;
            Console.WriteLine($"Счёт пополнен на {amount:C2}");
        }

        // Метод снятия средств
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException(
                    "Сумма снятия должна быть положительной",
                    amount
                );
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException(
                    "Недостаточно средств на счете",
                    Balance,
                    amount
                );
            }

            Balance -= amount;
            Console.WriteLine($"Со счёта снято {amount:C2}");
        }

        // Метод для отображения информации о счёте
        public void DisplayAccountInfo()
        {
            Console.WriteLine("\n=== ИНФОРМАЦИЯ О СЧЁТЕ ===");
            Console.WriteLine($"Владелец: {(string.IsNullOrEmpty(OwnerName) ? "Не указан" : OwnerName)}");
            Console.WriteLine($"Номер счёта: {AccountNumber}");
            Console.WriteLine($"Дата создания: {CreationDate:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Текущий баланс: {Balance:C2}");
            Console.WriteLine("===========================");
        }
    }

    class Program7
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 2: Банковский счёт ===\n");

            Console.Write("Введите имя владельца счёта: ");
            string ownerName = Console.ReadLine();

            BankAccount account = new BankAccount(ownerName);

            Console.WriteLine($"\nСчёт успешно создан!");
            Console.WriteLine($"Номер счёта: {account.AccountNumber}");
            Console.WriteLine($"Баланс: {account.Balance:C2}");

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    // Меню выбора действий
                    Console.WriteLine("\n" + new string('═', 50));
                    Console.WriteLine("ВЫБЕРИТЕ ДЕЙСТВИЕ:");
                    Console.WriteLine(new string('═', 50));
                    Console.WriteLine("1. Пополнить счёт");
                    Console.WriteLine("2. Снять средства");
                    Console.WriteLine("3. Показать баланс");
                    Console.WriteLine("4. Информация о счёте");
                    Console.WriteLine("5. Выход");
                    Console.Write("\nВаш выбор: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите сумму для пополнения: ");
                            string depositInput = Console.ReadLine();

                            if (!decimal.TryParse(depositInput, out decimal depositAmount))
                            {
                                throw new FormatException("Введено некорректное числовое значение");
                            }

                            account.Deposit(depositAmount);
                            Console.WriteLine($"Текущий баланс: {account.Balance:C2}");
                            break;

                        case "2":
                            Console.Write("Введите сумму для снятия: ");
                            string withdrawInput = Console.ReadLine();

                            if (!decimal.TryParse(withdrawInput, out decimal withdrawAmount))
                            {
                                throw new FormatException("Введено некорректное числовое значение");
                            }

                            account.Withdraw(withdrawAmount);
                            Console.WriteLine($"Текущий баланс: {account.Balance:C2}");
                            break;

                        case "3":
                            Console.WriteLine($"Текущий баланс: {account.Balance:C2}");
                            break;

                        case "4":
                            account.DisplayAccountInfo();
                            break;

                        case "5":
                            continueProgram = false;
                            Console.WriteLine("Спасибо за использование банковской системы!");
                            break;

                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 1 до 5.");
                            break;
                    }
                }
                catch (InvalidAmountException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nОШИБКА: {ex.Message}");
                    if (ex.InvalidAmount != 0)
                    {
                        Console.WriteLine($"Указанная сумма: {ex.InvalidAmount:C2}");
                    }
                    Console.ResetColor();
                }
                catch (InsufficientFundsException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nОШИБКА: {ex.Message}");
                    Console.WriteLine($"Текущий баланс: {ex.CurrentBalance:C2}");
                    Console.WriteLine($"Запрашиваемая сумма: {ex.RequestedAmount:C2}");
                    Console.WriteLine($"Не хватает: {ex.Shortage:C2}");
                    Console.ResetColor();
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nОШИБКА ВВОДА: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите корректное числовое значение.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nОШИБКА: Введено слишком большое число!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nНЕПРЕДВИДЕННАЯ ОШИБКА: {ex.Message}");
                    Console.WriteLine($"Тип ошибки: {ex.GetType().Name}");
                    Console.ResetColor();
                }
                finally
                {
                    if (continueProgram)
                    {
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
            }

            Console.WriteLine("\n=== ЗАВЕРШЕНИЕ РАБОТЫ ===");
            account.DisplayAccountInfo();
            Console.WriteLine("\nПрограмма завершена.");
            Console.ReadKey();
        }
    }
}
