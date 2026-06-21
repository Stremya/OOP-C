using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Задача 1
    /*
    internal class Program1
    {
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
            Console.WriteLine("=== Задача 1: Квадрат из символа ===\n");

            // Демонстрация
            Console.WriteLine("Квадрат 5x5 из символа '*':\n");
            DrawSquare(5, '*');

            Console.WriteLine("\nКвадрат 3x3 из символа '#':\n");
            DrawSquare(3, '#');
        }
    }
    */

    // Задача 2
    /*
    class Program2
    {
        static bool IsPalindrome(int number)
        {
            string str = number.ToString();
            string reversed = new string(str.Reverse().ToArray());
            return str == reversed;
        }

        static void Main()
        {
            Console.WriteLine("=== Задача 2: Проверка на палиндром ===\n");

            // Интерактивный режим
            Console.Write("\nВведите число для проверки: ");
            int number = int.Parse(Console.ReadLine());

            if (IsPalindrome(number))
                Console.WriteLine($"{number} - палиндром");
            else
                Console.WriteLine($"{number} - не палиндром");
        }
    }
    */

    // Задача 3
    /*
    class Program3
    {
        static int[] FilterArray(int[] originalArray, int[] filterArray)
        {
            if (originalArray == null || filterArray == null)
                throw new ArgumentNullException("Массивы не могут быть null");

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
            Console.WriteLine("=== Задача 3: Фильтрация массива ===\n");

            // Пример из задания
            int[] original = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filter = { 6, 88, 7 };

            Console.WriteLine($"Оригинальный массив: [{string.Join(", ", original)}]");
            Console.WriteLine($"Массив для фильтрации: [{string.Join(", ", filter)}]");

            int[] result = FilterArray(original, filter);
            Console.WriteLine($"Результат: [{string.Join(", ", result)}]");

        }
    }
    */

    // Задача 4
    /*
    class Website
    {
        // Приватные поля
        private string name;
        private string url;
        private string description;
        private string ipAddress;

        // Конструктор по умолчанию
        public Website()
        {
            name = "Неизвестный сайт";
            url = "http://";
            description = "Описание отсутствует";
            ipAddress = "0.0.0.0";
        }

        // Конструктор с параметрами
        public Website(string name, string url, string description, string ipAddress)
        {
            this.name = name;
            this.url = url;
            this.description = description;
            this.ipAddress = ipAddress;
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.WriteLine("=== Ввод данных о сайте ===");

            Console.Write("Введите название сайта: ");
            name = Console.ReadLine();

            Console.Write("Введите URL сайта: ");
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
            Console.WriteLine("===========================");
        }

        // геттеры
        public string GetName()
        {
            return name;
        }

        public string GetUrl()
        {
            return url;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetIpAddress()
        {
            return ipAddress;
        }

        // сеттеры
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: название не может быть пустым!");
                return;
            }
            this.name = name;
        }

        public void SetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("Ошибка: URL не может быть пустым!");
                return;
            }
            this.url = url;
        }

        public void SetDescription(string description)
        {
            this.description = description ?? "Описание отсутствует";
        }

        public void SetIpAddress(string ipAddress)
        {
            if (IsValidIpAddress(ipAddress))
            {
                this.ipAddress = ipAddress;
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный IP-адрес!");
            }
        }

        // Вспомогательный метод для проверки IP-адреса
        private bool IsValidIpAddress(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return false;

            string[] parts = ip.Split('.');
            if (parts.Length != 4)
                return false;

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int num) || num < 0 || num > 255)
                    return false;
            }

            return true;
        }
    }

    class Program4
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 4: Класс «Веб-сайт» ===\n");

            // Создание объекта через ввод данных
            Website site1 = new Website();
            site1.InputData();
            site1.DisplayData();

            // Создание объекта через конструктор
            Console.WriteLine("\nСоздание сайта через конструктор:");
            Website site2 = new Website(
                "YouTube",
                "https://www.youtube.com",
                "Видеохостинг",
                "142.250.74.206"
            );
            site2.DisplayData();

            // Демонстрация геттеров
            Console.WriteLine("\nДемонстрация методов доступа:");
            Console.WriteLine($"Название сайта: {site2.GetName()}");
            Console.WriteLine($"URL: {site2.GetUrl()}");

            // Изменение данных через сеттеры
            Console.WriteLine("\nИзменение названия сайта:");
            site2.SetName("YouTube Russia");
            Console.WriteLine($"Новое название: {site2.GetName()}");

            Console.ReadKey();
        }
    }
    */

    // Задача 5
    /*
    class Magazine
    {
        // Приватные поля
        private string name;
        private int foundationYear;
        private string description;
        private string contactPhone;
        private string contactEmail;

        // Конструктор по умолчанию
        public Magazine()
        {
            name = "Неизвестный журнал";
            foundationYear = DateTime.Now.Year;
            description = "Описание отсутствует";
            contactPhone = "Не указан";
            contactEmail = "Не указан";
        }

        // Конструктор с параметрами
        public Magazine(string name, int year, string description,
                       string phone, string email)
        {
            this.name = name;
            this.foundationYear = year;
            this.description = description;
            this.contactPhone = phone;
            this.contactEmail = email;
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.WriteLine("=== Ввод данных о журнале ===");

            Console.Write("Введите название журнала: ");
            name = Console.ReadLine();

            Console.Write("Введите год основания: ");
            while (!int.TryParse(Console.ReadLine(), out foundationYear) ||
                   foundationYear < 1700 || foundationYear > DateTime.Now.Year)
            {
                Console.Write("Некорректный год! Введите год от 1700 до " +
                             DateTime.Now.Year + ": ");
            }

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
            Console.WriteLine($"Лет на рынке: {DateTime.Now.Year - foundationYear}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Телефон: {contactPhone}");
            Console.WriteLine($"E-mail: {contactEmail}");
            Console.WriteLine("============================");
        }

        // Методы доступа (геттеры)
        public string GetName() { return name; }
        public int GetFoundationYear() { return foundationYear; }
        public string GetDescription() { return description; }
        public string GetContactPhone() { return contactPhone; }
        public string GetContactEmail() { return contactEmail; }

        // Методы для установки значений (сеттеры)
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                this.name = name;
        }

        public void SetFoundationYear(int year)
        {
            if (year >= 1700 && year <= DateTime.Now.Year)
                this.foundationYear = year;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public void SetContactPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                this.contactPhone = phone;
        }

        public void SetContactEmail(string email)
        {
            if (email.Contains("@"))
                this.contactEmail = email;
        }
    }

    class Program5
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 5: Класс «Журнал» ===\n");

            // Создание объекта через ввод данных
            Magazine magazine1 = new Magazine();
            magazine1.InputData();
            magazine1.DisplayData();

            // Создание объекта через конструктор
            Console.WriteLine("\nСоздание журнала через конструктор:");
            Magazine magazine2 = new Magazine(
                "National Geographic",
                1888,
                "Научно-популярный географический журнал",
                "+1-800-647-5463",
                "natgeo@example.com"
            );
            magazine2.DisplayData();

            // Демонстрация методов доступа
            Console.WriteLine("\nДемонстрация методов доступа:");
            Console.WriteLine($"Название: {magazine2.GetName()}");
            Console.WriteLine($"Год основания: {magazine2.GetFoundationYear()}");
            Console.WriteLine($"Возраст журнала: {DateTime.Now.Year - magazine2.GetFoundationYear()} лет");

            Console.ReadKey();
        }
    }
    */

    // Задача 6
    class Shop
    {
        // Приватные поля
        private string name;
        private string address;
        private string profileDescription;
        private string contactPhone;
        private string contactEmail;
        private double rating;
        private bool isOpen;

        // Конструктор по умолчанию
        public Shop()
        {
            name = "Неизвестный магазин";
            address = "Адрес не указан";
            profileDescription = "Описание отсутствует";
            contactPhone = "Не указан";
            contactEmail = "Не указан";
            rating = 0;
            isOpen = true;
        }

        // Конструктор с параметрами
        public Shop(string name, string address, string description,
                   string phone, string email)
        {
            this.name = name;
            this.address = address;
            this.profileDescription = description;
            this.contactPhone = phone;
            this.contactEmail = email;
            this.rating = 0;
            this.isOpen = true;
        }

        // Метод для ввода данных
        public void InputData()
        {
            Console.WriteLine("=== Ввод данных о магазине ===");

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

            Console.Write("Введите рейтинг магазина (0-5): ");
            double.TryParse(Console.ReadLine(), out rating);
            rating = Math.Max(0, Math.Min(5, rating)); 
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
            Console.WriteLine($"Рейтинг: {new string('★', (int)rating)}{new string('☆', 5 - (int)rating)} ({rating:F1})");
            Console.WriteLine($"Статус: {(isOpen ? "Открыт" : "Закрыт")}");
            Console.WriteLine("============================");
        }

        // Методы доступа (геттеры)
        public string GetName() { return name; }
        public string GetAddress() { return address; }
        public string GetProfileDescription() { return profileDescription; }
        public string GetContactPhone() { return contactPhone; }
        public string GetContactEmail() { return contactEmail; }
        public double GetRating() { return rating; }
        public bool IsOpen() { return isOpen; }

        // Методы для установки значений (сеттеры)
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                this.name = name;
        }

        public void SetAddress(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
                this.address = address;
        }

        public void SetProfileDescription(string description)
        {
            this.profileDescription = description;
        }

        public void SetContactPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                this.contactPhone = phone;
        }

        public void SetContactEmail(string email)
        {
            if (email != null && email.Contains("@"))
                this.contactEmail = email;
        }

        public void SetRating(double rating)
        {
            this.rating = Math.Max(0, Math.Min(5, rating));
        }

        // Дополнительные методы
        public void OpenShop()
        {
            isOpen = true;
            Console.WriteLine($"Магазин \"{name}\" открыт!");
        }

        public void CloseShop()
        {
            isOpen = false;
            Console.WriteLine($"Магазин \"{name}\" закрыт!");
        }

        public string GetShortInfo()
        {
            return $"{name} | {address} | {contactPhone} | Рейтинг: {rating:F1}";
        }
    }

    class Program6
    {
        static void Main()
        {
            Console.WriteLine("=== Задача 6: Класс «Магазин» ===\n");

            // Создание объекта через ввод данных
            Shop shop1 = new Shop();
            shop1.InputData();
            shop1.DisplayData();

            // Создание объекта через конструктор
            Console.WriteLine("\nСоздание магазина через конструктор:");
            Shop shop2 = new Shop(
                "ТехноМир",
                "ул. Ленина, 15, Москва",
                "Продажа электроники и бытовой техники",
                "+7 (495) 123-45-67",
                "info@technoworld.ru"
            );
            shop2.SetRating(4.5);
            shop2.DisplayData();

            // Демонстрация методов доступа
            Console.WriteLine("\nДемонстрация методов доступа:");
            Console.WriteLine($"Название: {shop2.GetName()}");
            Console.WriteLine($"Адрес: {shop2.GetAddress()}");
            Console.WriteLine($"Краткая информация: {shop2.GetShortInfo()}");

            // Демонстрация управления статусом
            Console.WriteLine("\nУправление статусом магазина:");
            shop2.CloseShop();
            Console.WriteLine($"Статус: {(shop2.IsOpen() ? "Открыт" : "Закрыт")}");
            shop2.OpenShop();
            Console.WriteLine($"Статус: {(shop2.IsOpen() ? "Открыт" : "Закрыт")}");

            Console.ReadKey();
        }
    }
}
