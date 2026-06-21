using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1
{
    // Задание 1
    /*
    internal class Program1
    {
        // Метод для отображения квадрата
        static void DrawSquare(int sideLength, char symbol)
        {
            if (sideLength <= 0)
            {
                Console.WriteLine("Ошибка: длина стороны должна быть положительной!");
                return;
            }

            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Console.Write("Введите длину стороны квадрата: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Введите символ: ");
            char symbol = Console.ReadKey().KeyChar;
            Console.WriteLine("\n");

            DrawSquare(length, symbol);
        }
    }
    */

    // Задание 2
    /*
    internal class Program2
    {
        // Метод проверки числа на палиндром
        static bool IsPalindrome(int number)
        {
            string numStr = number.ToString();
            char[] charArray = numStr.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);

            return numStr == reversedStr;
        }

        static void Main()
        {
            Console.Write("Введите число: ");
            int num = int.Parse(Console.ReadLine());

            if (IsPalindrome(num))
                Console.WriteLine($"{num} - палиндром");
            else
                Console.WriteLine($"{num} - не палиндром");
        }        
    }
    */

    // Задание 3
    /*
    internal class Program3
    {
        // Метод фильтрации массива
        static int[] FilterArray(int[] originalArray, int[] filterArray)
        {
            List<int> result = new List<int>();

            foreach (int item in originalArray)
            {
                if (!filterArray.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        static void Main()
        {
            int[] original = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filter = { 6, 88, 7 };

            int[] result = FilterArray(original, filter);

            Console.WriteLine("Оригинальный массив: " + string.Join(" ", original));
            Console.WriteLine("Массив для фильтрации: " + string.Join(" ", filter));
            Console.WriteLine("Результат: " + string.Join(" ", result));
        }
    }
    */

    // Задание 4
    /*
    class Website
    {
        // Поля класса
        private string name;
        private string url;
        private string description;
        private string ipAddress;

        // Конструктор
        public Website()
        {
            name = "";
            url = "";
            description = "";
            ipAddress = "";
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.Write("Введите название сайта: ");
            name = Console.ReadLine();

            Console.Write("Введите путь к сайту (URL): ");
            url = Console.ReadLine();

            Console.Write("Введите описание сайта: ");
            description = Console.ReadLine();

            Console.Write("Введите IP-адрес сайта: ");
            ipAddress = Console.ReadLine();
        }

        // Метод для вывода данных
        public void DisplayData()
        {
            Console.WriteLine("\n=== Информация о сайте ===");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"IP-адрес: {ipAddress}");
        }

        // Методы доступа к отдельным полям
        public string GetName() { return name; }
        public string GetUrl() { return url; }
        public string GetDescription() { return description; }
        public string GetIpAddress() { return ipAddress; }

    }

    internal class Program4
    {
        static void Main()
        {
            Website site = new Website();
            site.InputData();
            site.DisplayData();

            Console.WriteLine("\nДоступ через методы:");
            Console.WriteLine($"Название: {site.GetName()}");

            Console.ReadKey();
        }
    }
    */

    // Задание 5
    /*
    class Magazine
    {
        // Поля класса
        private string name;
        private int foundationYear;
        private string description;
        private string contactPhone;
        private string contactEmail;

        // Конструктор
        public Magazine()
        {
            name = "";
            foundationYear = 0;
            description = "";
            contactPhone = "";
            contactEmail = "";
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.Write("Введите название журнала: ");
            name = Console.ReadLine();

            Console.Write("Введите год основания: ");
            foundationYear = int.Parse(Console.ReadLine());

            Console.Write("Введите описание журнала: ");
            description = Console.ReadLine();

            Console.Write("Введите контактный телефон: ");
            contactPhone = Console.ReadLine();

            Console.Write("Введите контактный e-mail: ");
            contactEmail = Console.ReadLine();
        }

        // Метод для вывода данных
        public void DisplayData()
        {
            Console.WriteLine("\n=== Информация о журнале ===");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Год основания: {foundationYear}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Телефон: {contactPhone}");
            Console.WriteLine($"E-mail: {contactEmail}");
        }

        // Методы доступа к отдельным полям
        public string GetName() { return name; }
        public int GetFoundationYear() { return foundationYear; }
        public string GetDescription() { return description; }
        public string GetContactPhone() { return contactPhone; }
        public string GetContactEmail() { return contactEmail; }

        // Свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int FoundationYear
        {
            get { return foundationYear; }
            set { foundationYear = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }

        public string ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }
    }

    internal class Program5
    {
        static void Main()
        {
            Magazine magazine = new Magazine();
            magazine.InputData();
            magazine.DisplayData();

            Console.ReadKey();
        }
    }
    */

    // Задание 6
    class Shop
    {
        // Поля класса
        private string name;
        private string address;
        private string profileDescription;
        private string contactPhone;
        private string contactEmail;

        // Конструктор
        public Shop()
        {
            name = "";
            address = "";
            profileDescription = "";
            contactPhone = "";
            contactEmail = "";
        }

        // Конструктор с параметрами
        public Shop(string name, string address, string description, string phone, string email)
        {
            this.name = name;
            this.address = address;
            this.profileDescription = description;
            this.contactPhone = phone;
            this.contactEmail = email;
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.Write("Введите название магазина: ");
            name = Console.ReadLine();

            Console.Write("Введите адрес магазина: ");
            address = Console.ReadLine();

            Console.Write("Введите описание профиля магазина: ");
            profileDescription = Console.ReadLine();

            Console.Write("Введите контактный телефон: ");
            contactPhone = Console.ReadLine();

            Console.Write("Введите контактный e-mail: ");
            contactEmail = Console.ReadLine();
        }

        // Метод для вывода данных
        public void DisplayData()
        {
            Console.WriteLine("\n=== Информация о магазине ===");
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Профиль: {profileDescription}");
            Console.WriteLine($"Телефон: {contactPhone}");
            Console.WriteLine($"E-mail: {contactEmail}");
        }

        // Методы доступа к отдельным полям
        public string GetName() { return name; }
        public string GetAddress() { return address; }
        public string GetProfileDescription() { return profileDescription; }
        public string GetContactPhone() { return contactPhone; }
        public string GetContactEmail() { return contactEmail; }

        // Свойства
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string ProfileDescription
        {
            get { return profileDescription; }
            set { profileDescription = value; }
        }

        public string ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }

        public string ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }
    }

    internal class Program6
    {
        static void Main()
        {
            Shop shop = new Shop();
            shop.InputData();
            shop.DisplayData();

            Console.WriteLine("\nТест свойств:");
            shop.Name = "Новое название";
            Console.WriteLine($"Измененное название: {shop.Name}");

            Console.ReadKey();
        }
    }
}
