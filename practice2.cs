using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace practice
{
    // Задание 1
    /*
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 1: Строка цифр в число ===\n");

            while (true)
            {
                try
                {
                    Console.Write("Введите строку из цифр (0-9): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Строка не может быть пустой!");
                    }

                    foreach (char c in input)
                    {
                        if (!char.IsDigit(c))
                        {
                            throw new FormatException($"Недопустимый символ: '{c}'. Разрешены только цифры 0-9!");
                        }
                    }

                    int number;
                    if (!int.TryParse(input, out number))
                    {
                        throw new OverflowException(
                            $"Число '{input}' выходит за границы типа int " +
                            $"({int.MinValue} до {int.MaxValue})!");
                    }

                    Console.WriteLine($"Преобразование успешно! Число: {number}");

                    if (input.Length > 1 && input[0] == '0')
                    {
                        Console.WriteLine("Примечание: число начинается с нуля, " +
                                        $"но преобразовано как {number}");
                    }

                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка формата: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Ошибка переполнения: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка аргумента: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
    */

    // Задание 2
    /*
    class Program2
    {
        class BinaryFormatException : Exception
        {
            public BinaryFormatException(string message) : base(message) { }
        }

        static int BinaryToDecimal(string binaryString)
        {
            if (string.IsNullOrEmpty(binaryString))
            {
                throw new BinaryFormatException("Строка не может быть пустой!");
            }

            foreach (char c in binaryString)
            {
                if (c != '0' && c != '1')
                {
                    throw new BinaryFormatException(
                        $"Недопустимый символ: '{c}'. " +
                        "Двоичное число может содержать только 0 и 1!");
                }
            }

            if (binaryString.Length > 31)
            {
                throw new OverflowException(
                    $"Двоичное число '{binaryString}' слишком длинное. " +
                    "Максимальная длина для типа int: 31 бит.");
            }

            try
            {
                int result = Convert.ToInt32(binaryString, 2);
                return result;
            }
            catch (OverflowException)
            {
                throw new OverflowException(
                    $"Двоичное число '{binaryString}' выходит за границы типа int " +
                    $"({int.MinValue} до {int.MaxValue})!");
            }
        }

        static void Main()
        {
            Console.WriteLine("=== Задача 2: Двоичная строка в десятичное число ===\n");
            Console.WriteLine("Примечание: вводите только символы 0 и 1\n");

            while (true)
            {
                try
                {
                    Console.Write("Введите двоичное число: ");
                    string binaryInput = Console.ReadLine();

                    int decimalResult = BinaryToDecimal(binaryInput);

                    Console.WriteLine($"\nРезультат преобразования:");
                    Console.WriteLine($"Двоичное: {binaryInput}");
                    Console.WriteLine($"Десятичное: {decimalResult}");
                    Console.WriteLine($"Шестнадцатеричное: 0x{decimalResult:X}");

                    Console.WriteLine("\nПроцесс вычисления:");
                    int power = binaryInput.Length - 1;
                    for (int i = 0; i < binaryInput.Length; i++)
                    {
                        if (binaryInput[i] == '1')
                        {
                            int value = (int)Math.Pow(2, power - i);
                            Console.WriteLine($"  Бит {i}: 1 × 2^{power - i} = {value}");
                        }
                    }
                    Console.WriteLine($"  Сумма = {decimalResult}");

                    break;
                }
                catch (BinaryFormatException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Ошибка переполнения: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
    */

    // Задание 3
    /*
    class CreditCardException : Exception
    {
        public CreditCardException(string message) : base(message) { }
    }

    class InvalidCardNumberException : CreditCardException
    {
        public InvalidCardNumberException(string message) : base(message) { }
    }

    class InvalidCardHolderException : CreditCardException
    {
        public InvalidCardHolderException(string message) : base(message) { }
    }

    class InvalidCVCException : CreditCardException
    {
        public InvalidCVCException(string message) : base(message) { }
    }

    class ExpiredCardException : CreditCardException
    {
        public ExpiredCardException(string message) : base(message) { }
    }

    class CreditCard
    {
        private string cardNumber;
        private string cardHolderName;
        private string cardHolderSurname;
        private string cardHolderPatronymic;
        private string cvc;
        private DateTime expiryDate;
        private string bankName;
        private decimal balance;
        private string cardType; 

        // Свойства с проверками
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                if (!IsValidCardNumber(value))
                {
                    throw new InvalidCardNumberException(
                        $"Некорректный номер карты: {value}. " +
                        "Номер должен содержать 16 цифр!");
                }
                cardNumber = FormatCardNumber(value);
            }
        }

        public string CardHolderName
        {
            get { return cardHolderName; }
            set
            {
                if (!IsValidName(value))
                {
                    throw new InvalidCardHolderException(
                        $"Некорректное имя: {value}. " +
                        "Имя должно содержать только буквы!");
                }
                cardHolderName = CapitalizeName(value);
            }
        }

        public string CardHolderSurname
        {
            get { return cardHolderSurname; }
            set
            {
                if (!IsValidName(value))
                {
                    throw new InvalidCardHolderException(
                        $"Некорректная фамилия: {value}. " +
                        "Фамилия должна содержать только буквы!");
                }
                cardHolderSurname = CapitalizeName(value);
            }
        }

        public string CardHolderPatronymic
        {
            get { return cardHolderPatronymic; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !IsValidName(value))
                {
                    throw new InvalidCardHolderException(
                        $"Некорректное отчество: {value}. " +
                        "Отчество должно содержать только буквы!");
                }
                cardHolderPatronymic = string.IsNullOrEmpty(value) ? "" : CapitalizeName(value);
            }
        }

        public string CVC
        {
            get { return cvc; }
            set
            {
                if (!IsValidCVC(value))
                {
                    throw new InvalidCVCException(
                        $"Некорректный CVC код: {value}. " +
                        "CVC должен содержать 3 цифры!");
                }
                cvc = value;
            }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ExpiredCardException(
                        $"Карта просрочена! Дата окончания: {value:MM/yyyy}");
                }
                if (value > DateTime.Now.AddYears(10))
                {
                    throw new CreditCardException(
                        "Дата окончания не может быть больше 10 лет от текущей даты!");
                }
                expiryDate = value;
            }
        }

        public string BankName
        {
            get { return bankName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new CreditCardException("Название банка не может быть пустым!");
                }
                bankName = value;
            }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new CreditCardException("Баланс не может быть отрицательным!");
                }
                balance = value;
            }
        }

        public string CardType
        {
            get { return cardType; }
            set
            {
                string[] validTypes = { "Visa", "MasterCard", "American Express", "Мир", "UnionPay" };
                if (Array.IndexOf(validTypes, value) == -1)
                {
                    throw new CreditCardException(
                        $"Некорректный тип карты: {value}. " +
                        $"Допустимые типы: {string.Join(", ", validTypes)}");
                }
                cardType = value;
            }
        }

        // Конструктор
        public CreditCard(string cardNumber, string name, string surname,
                         string patronymic, string cvc, DateTime expiryDate,
                         string bankName = "Неизвестный банк",
                         decimal balance = 0, string cardType = "Visa")
        {
            CardNumber = cardNumber;
            CardHolderName = name;
            CardHolderSurname = surname;
            CardHolderPatronymic = patronymic;
            CVC = cvc;
            ExpiryDate = expiryDate;
            BankName = bankName;
            Balance = balance;
            CardType = cardType;
        }

        // Методы проверки
        private bool IsValidCardNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            number = number.Replace(" ", "").Replace("-", "");

            if (number.Length != 16 || !Regex.IsMatch(number, @"^\d{16}$"))
                return false;

            int sum = 0;
            bool alternate = false;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return Regex.IsMatch(name, @"^[а-яА-ЯёЁa-zA-Z\- ]+$");
        }

        private bool IsValidCVC(string cvc)
        {
            return !string.IsNullOrEmpty(cvc) &&
                   cvc.Length == 3 &&
                   Regex.IsMatch(cvc, @"^\d{3}$");
        }

        // Метод форматирования номера карты
        private string FormatCardNumber(string number)
        {
            number = number.Replace(" ", "").Replace("-", "");
            return $"{number.Substring(0, 4)} {number.Substring(4, 4)} " +
                   $"{number.Substring(8, 4)} {number.Substring(12, 4)}";
        }

        // Метод капитализации имени
        private string CapitalizeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        // Метод для маскировки номера карты
        public string GetMaskedCardNumber()
        {
            string cleanNumber = cardNumber.Replace(" ", "");
            return $"**** **** **** {cleanNumber.Substring(12, 4)}";
        }

        // Метод для отображения информации
        public void DisplayCardInfo()
        {
            Console.WriteLine("\n=== ИНФОРМАЦИЯ О КАРТЕ ===");
            Console.WriteLine($"Номер карты: {GetMaskedCardNumber()}");
            Console.WriteLine($"Владелец: {cardHolderSurname} {cardHolderName} {cardHolderPatronymic}");
            Console.WriteLine($"Тип карты: {cardType}");
            Console.WriteLine($"Банк: {bankName}");
            Console.WriteLine($"CVC: ***");
            Console.WriteLine($"Срок действия: {expiryDate:MM/yyyy}");
            Console.WriteLine($"Баланс: {balance:C2}");

            // Проверка срока действия
            TimeSpan remaining = expiryDate - DateTime.Now;
            Console.WriteLine($"Осталось дней до окончания: {remaining.Days}");

            if (remaining.Days < 30)
            {
                Console.WriteLine("ВНИМАНИЕ: Срок действия карты истекает менее чем через месяц!");
            }
        }
    }

    class Program3
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 3: Кредитная карточка ===\n");

            try
            {
                Console.WriteLine("Пример 1: Корректная карта");
                CreditCard card1 = new CreditCard(
                    "4532015112830366",  // Номер 
                    "Иван",              // Имя
                    "Иванов",            // Фамилия
                    "Иванович",          // Отчество
                    "123",               // CVC
                    new DateTime(2025, 12, 31), // Срок действия
                    "Сбербанк",          // Банк
                    50000.50m,           // Баланс
                    "Visa"               // Тип карты
                );

                card1.DisplayCardInfo();

                Console.WriteLine("\nПример 2: Некорректный номер карты");
                try
                {
                    CreditCard card2 = new CreditCard(
                        "1234567890123456", 
                        "Петр",
                        "Петров",
                        "Петрович",
                        "456",
                        new DateTime(2024, 6, 30)
                    );
                }
                catch (InvalidCardNumberException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\nПример 3: Просроченная карта");
                try
                {
                    CreditCard card3 = new CreditCard(
                        "4916338506082832",
                        "Анна",
                        "Сидорова",
                        "",
                        "789",
                        new DateTime(2023, 1, 1) 
                    );
                }
                catch (ExpiredCardException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\n=== Интерактивное создание карты ===");
                CreateCardInteractively();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void CreateCardInteractively()
        {
            try
            {
                Console.Write("Введите номер карты (16 цифр): ");
                string number = Console.ReadLine();

                Console.Write("Введите имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();

                Console.Write("Введите отчество (можно пропустить): ");
                string patronymic = Console.ReadLine();

                Console.Write("Введите CVC (3 цифры): ");
                string cvc = Console.ReadLine();

                Console.Write("Введите срок действия (ГГГГ-ММ): ");
                DateTime expiry = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите название банка: ");
                string bank = Console.ReadLine();

                Console.Write("Введите тип карты (Visa, MasterCard, Мир): ");
                string type = Console.ReadLine();

                CreditCard card = new CreditCard(number, name, surname,
                                               patronymic, cvc, expiry,
                                               bank, 0, type);

                Console.WriteLine("\nКарта успешно создана!");
                card.DisplayCardInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания карты: {ex.Message}");
            }
        }
    }
    */

    // Задание 4
    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message) : base(message) { }
    }

    class OverflowResultException : Exception
    {
        public OverflowResultException(string message) : base(message) { }
    }

    class Program
    {
        static int CalculateProduct(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new InvalidExpressionException("Выражение не может быть пустым!");
            }

            expression = expression.Replace(" ", "");

            if (expression.StartsWith("*") || expression.EndsWith("*"))
            {
                throw new InvalidExpressionException(
                    "Выражение не может начинаться или заканчиваться знаком *!");
            }

            if (expression.Contains("**"))
            {
                throw new InvalidExpressionException(
                    "Выражение не может содержать два знака * подряд!");
            }

            string[] parts = expression.Split('*');

            foreach (string part in parts)
            {
                if (string.IsNullOrEmpty(part))
                {
                    throw new InvalidExpressionException(
                        "Обнаружен пустой операнд между знаками *!");
                }

                if (!int.TryParse(part, out int number))
                {
                    throw new InvalidExpressionException(
                        $"'{part}' не является целым числом!");
                }
            }

            long result = 1; 

            Console.WriteLine("\nПроцесс вычисления:");
            Console.Write("  ");

            for (int i = 0; i < parts.Length; i++)
            {
                int number = int.Parse(parts[i]);

                result *= number;

                if (result > int.MaxValue || result < int.MinValue)
                {
                    throw new OverflowResultException(
                        $"Результат {result} выходит за границы типа int " +
                        $"({int.MinValue} до {int.MaxValue})!");
                }

                Console.Write(number);
                if (i < parts.Length - 1)
                    Console.Write(" × ");
            }

            Console.WriteLine($" = {result}");

            return (int)result;
        }

        static void Main()
        {
            Console.WriteLine("=== Задача 4: Калькулятор произведения ===\n");
            Console.WriteLine("Введите выражение с операцией умножения (*)");
            Console.WriteLine("Например: 3*2*1*4\n");

            while (true)
            {
                try
                {
                    Console.Write("Введите выражение: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit" || input.ToLower() == "выход")
                        break;

                    Console.WriteLine($"\nИсходное выражение: {input}");

                    int result = CalculateProduct(input);

                    Console.WriteLine($"\nРезультат: {result}");

                    if (result == 0)
                    {
                        Console.WriteLine("Примечание: результат равен 0, " +
                                        "так как один из множителей равен 0");
                    }
                    else if (result == 1)
                    {
                        Console.WriteLine("Примечание: результат равен 1, " +
                                        "так как все множители равны 1");
                    }

                    Console.WriteLine("\n--- Новое выражение ---\n");
                }
                catch (InvalidExpressionException ex)
                {
                    Console.WriteLine($"\nОшибка в выражении: {ex.Message}");
                    Console.WriteLine("Проверьте правильность ввода и попробуйте снова.\n");
                }
                catch (OverflowResultException ex)
                {
                    Console.WriteLine($"\nОшибка переполнения: {ex.Message}");
                    Console.WriteLine("Попробуйте использовать меньшие числа.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nНеожиданная ошибка: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.\n");
                }
            }

            // Демонстрационные примеры
            Console.WriteLine("\n=== Демонстрационные примеры ===\n");

            TestExpression("3*2*1*4");      // Корректное
            TestExpression("10*10*10*10");  // Корректное
            TestExpression("2**3");         // Ошибка: две звёздочки
            TestExpression("*5*6");         // Ошибка: начинается с *
            TestExpression("5*6*");         // Ошибка: заканчивается на *
            TestExpression("5*abc*3");      // Ошибка: не число
            TestExpression("1000*1000*1000*1000"); // Ошибка: переполнение

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void TestExpression(string expression)
        {
            try
            {
                Console.WriteLine($"Выражение: {expression}");
                int result = CalculateProduct(expression);
                Console.WriteLine($"Результат: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
        }
    }
}
