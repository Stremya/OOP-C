using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // Перечисление ArticleType определяющее типы товаров
    public enum ArticleType
    {
        Electronics,      // Электроника
        Clothing,         // Одежда
        Food,             // Продукты
        Furniture,        // Мебель
        Books,            // Книги
        Sports,           // Спорттовары
        Toys,             // Игрушки
        Other             // Другое
    }

    // Перечисление ClientType определяющее важность клиента
    public enum ClientType
    {
        Regular,          // Обычный
        VIP,              // VIP
        Wholesale,        // Оптовый
        Corporate,        // Корпоративный
        New               // Новый
    }

    // Перечисление PayType определяющее форму оплаты клиентом заказа
    public enum PayType
    {
        Cash,             // Наличные
        CreditCard,       // Кредитная карта
        DebitCard,        // Дебетовая карта
        BankTransfer,     // Банковский перевод
        ElectronicMoney,  // Электронные деньги
        Cryptocurrency    // Криптовалюта
    }

    // Структура Article (Товар)
    public struct Article
    {
        public string ProductCode { get; set; }      // код товара
        public string ProductName { get; set; }       // название товара
        public decimal Price { get; set; }            // цена товара
        public ArticleType Type { get; set; }         // тип товара (задание 5)

        public Article(string productCode, string productName, decimal price, ArticleType type = ArticleType.Other)
        {
            ProductCode = productCode;
            ProductName = productName;
            Price = price;
            Type = type;
        }
    }

    // Структура Client (Клиент)
    public struct Client
    {
        public string ClientCode { get; set; }        // код клиента
        public string FullName { get; set; }          // ФИО
        public string Address { get; set; }           // адрес
        public string Phone { get; set; }             // телефон
        public int OrderCount { get; set; }           // количество заказов
        public decimal TotalOrderAmount { get; set; } // общая сумма заказов
        public ClientType Type { get; set; }          // важность клиента (задание 6)

        public Client(string clientCode, string fullName, string address, string phone, ClientType type = ClientType.Regular)
        {
            ClientCode = clientCode;
            FullName = fullName;
            Address = address;
            Phone = phone;
            OrderCount = 0;
            TotalOrderAmount = 0;
            Type = type;
        }
    }

    // Структура RequestItem (Позиция заказа)
    public struct RequestItem
    {
        public Article Product { get; set; }          // товар
        public int Quantity { get; set; }             // количество единиц товара

        public RequestItem(Article product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // Вычисление стоимости позиции
        public decimal GetItemTotal()
        {
            return Product.Price * Quantity;
        }
    }

    // Структура Request (Заказ)
    public class Request
    {
        public string OrderCode { get; set; }           // код заказа
        public Client Client { get; set; }              // клиент
        public DateTime OrderDate { get; set; }         // дата заказа
        public List<RequestItem> Items { get; set; }    // перечень заказанных товаров
        public PayType PaymentMethod { get; set; }      // форма оплаты (задание 7)

        public Request(string orderCode, Client client, PayType paymentMethod = PayType.Cash)
        {
            OrderCode = orderCode;
            Client = client;
            OrderDate = DateTime.Now;
            Items = new List<RequestItem>();
            PaymentMethod = paymentMethod;
        }

        // Добавить товар в заказ
        public void AddItem(Article product, int quantity)
        {
            Items.Add(new RequestItem(product, quantity));
        }

        // Вычисление общей суммы заказа
        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.GetItemTotal();
            }
            return total;
        }

        // Получение скидки в зависимости от типа клиента
        public decimal GetDiscount()
        {
            decimal total = GetTotalAmount();
            switch (Client.Type)
            {
                case ClientType.VIP:
                    return total * 0.10m; // 10% скидка для VIP
                case ClientType.Wholesale:
                    return total * 0.15m; // 15% скидка для оптовых
                case ClientType.Corporate:
                    return total * 0.12m; // 12% скидка для корпоративных
                case ClientType.New:
                    return total * 0.05m; // 5% скидка для новых
                default:
                    return 0;              // без скидки для обычных
            }
        }

        // Вывод полной информации о заказе
        public void PrintOrderInfo()
        {
            Console.WriteLine($"Заказ: {OrderCode}");
            Console.WriteLine($"Клиент: {Client.FullName} ({Client.Type})");
            Console.WriteLine($"Телефон: {Client.Phone}");
            Console.WriteLine($"Адрес: {Client.Address}");
            Console.WriteLine($"Дата: {OrderDate}");
            Console.WriteLine($"Способ оплаты: {PaymentMethod}");
            Console.WriteLine("Товары в заказе:");

            foreach (var item in Items)
            {
                Console.WriteLine($"  {item.Product.ProductName} - {item.Quantity} шт. x {item.Product.Price} = {item.GetItemTotal()}");
            }

            decimal totalAmount = GetTotalAmount();
            decimal discount = GetDiscount();

            Console.WriteLine($"Общая сумма: {totalAmount:F2} руб.");
            if (discount > 0)
            {
                Console.WriteLine($"Скидка: -{discount:F2} руб.");
                Console.WriteLine($"Итого к оплате: {(totalAmount - discount):F2} руб.");
            }
            Console.WriteLine();
        }
    }

    // Класс Student (Студент)
    public class Student
    {
        public string LastName { get; set; }           // фамилия
        public string FirstName { get; set; }          // имя
        public string Patronymic { get; set; }         // отчество
        public string Group { get; set; }              // группа
        public int Age { get; set; }                   // возраст

        private int[][] grades;

        public Student(string lastName, string firstName, string patronymic, string group, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Group = group;
            Age = age;

            // инициализация зубчатого массива
            grades = new int[3][];
            grades[0] = new int[0]; // программирование
            grades[1] = new int[0]; // администрирование
            grades[2] = new int[0]; // дизайн
        }

        // Добавление оценки по предмету
        public void AddGrade(int subjectIndex, int grade)
        {
            if (subjectIndex < 0 || subjectIndex > 2)
                throw new ArgumentException("Индекс предмета должен быть 0-2 (0-программирование, 1-администрирование, 2-дизайн)");

            if (grade < 1 || grade > 5)
                throw new ArgumentException("Оценка должна быть от 1 до 5");

            Array.Resize(ref grades[subjectIndex], grades[subjectIndex].Length + 1);
            grades[subjectIndex][grades[subjectIndex].Length - 1] = grade;
        }

        // Установка всех оценок по предмету
        public void SetGrades(int subjectIndex, int[] newGrades)
        {
            if (subjectIndex < 0 || subjectIndex > 2)
                throw new ArgumentException("Индекс предмета должен быть 0-2");

            grades[subjectIndex] = newGrades;
        }

        // Получение оценок по предмету
        public int[] GetGrades(int subjectIndex)
        {
            if (subjectIndex < 0 || subjectIndex > 2)
                throw new ArgumentException("Индекс предмета должен быть 0-2");

            return grades[subjectIndex];
        }

        // Получение среднего балла по заданному предмету
        public double GetAverageGrade(int subjectIndex)
        {
            if (subjectIndex < 0 || subjectIndex > 2)
                throw new ArgumentException("Индекс предмета должен быть 0-2");

            if (grades[subjectIndex].Length == 0)
                return 0;

            return grades[subjectIndex].Average();
        }

        // Получение общего среднего балла
        public double GetOverallAverage()
        {
            List<int> allGrades = new List<int>();
            allGrades.AddRange(grades[0]);
            allGrades.AddRange(grades[1]);
            allGrades.AddRange(grades[2]);

            if (allGrades.Count == 0)
                return 0;

            return allGrades.Average();
        }

        // Получение названия предмета по индексу
        public static string GetSubjectName(int index)
        {
            switch (index)
            {
                case 0: return "Программирование";
                case 1: return "Администрирование";
                case 2: return "Дизайн";
                default: return "Неизвестный предмет";
            }
        }

        // Распечатка данных о студенте
        public void PrintInfo()
        {
            Console.WriteLine($"Студент: {LastName} {FirstName} {Patronymic}");
            Console.WriteLine($"Группа: {Group}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine("Оценки:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"  {GetSubjectName(i)}: ");
                if (grades[i].Length == 0)
                {
                    Console.WriteLine("нет оценок");
                }
                else
                {
                    Console.WriteLine($"{string.Join(", ", grades[i])} | Средний балл: {GetAverageGrade(i):F2}");
                }
            }

            Console.WriteLine($"Общий средний балл: {GetOverallAverage():F2}");
            Console.WriteLine();
        }
    }

    class ProgramMain
    {
        static void Main()
        {
            // Демонстрация работы с заказами (задания 1-7)
            Console.WriteLine("=== Демонстрация работы с заказами ===\n");

            // товары
            Article product1 = new Article("P001", "Ноутбук", 75000.00m, ArticleType.Electronics);
            Article product2 = new Article("P002", "Мышь", 1500.00m, ArticleType.Electronics);
            Article product3 = new Article("P003", "Книга C#", 2500.00m, ArticleType.Books);

            // клиенты
            Client client1 = new Client("C001", "Иванов Иван Иванович",
                                       "г. Москва, ул. Примерная, д. 1",
                                       "+7 (999) 123-45-67", ClientType.VIP);

            Client client2 = new Client("C002", "Петров Петр Петрович",
                                       "г. Москва, ул. Тестовая, д. 2",
                                       "+7 (999) 765-43-21", ClientType.New);

            // заказы
            Request order1 = new Request("ORD001", client1, PayType.CreditCard);
            order1.AddItem(product1, 1);
            order1.AddItem(product2, 2);
            order1.AddItem(product3, 1);

            Request order2 = new Request("ORD002", client2, PayType.Cash);
            order2.AddItem(product1, 1);
            order2.AddItem(product2, 1);

            // Вывод информации о заказах
            order1.PrintOrderInfo();
            order2.PrintOrderInfo();

            // Демонстрация работы со студентами (задание 8)
            Console.WriteLine("=== Демонстрация работы со студентами ===\n");

            Student student = new Student("Сидоров", "Алексей", "Дмитриевич", "П-42", 20);

            // добавление оценок
            student.AddGrade(0, 5); // программирование
            student.AddGrade(0, 4);
            student.AddGrade(0, 5);
            student.AddGrade(0, 3);

            student.AddGrade(1, 4); // администрирование
            student.AddGrade(1, 4);
            student.AddGrade(1, 5);

            student.AddGrade(2, 5); // дизайн
            student.AddGrade(2, 5);
            student.AddGrade(2, 4);
            student.AddGrade(2, 5);

            // распечатка данных о студенте
            student.PrintInfo();

            // демонстрация получения оценок
            Console.WriteLine($"Оценки по программированию: {string.Join(", ", student.GetGrades(0))}");
            Console.WriteLine($"Средний балл по программированию: {student.GetAverageGrade(0):F2}");

            // изменение оценок
            student.SetGrades(0, new int[] { 5, 5, 5, 4 });
            Console.WriteLine($"\nПосле изменения оценок по программированию:");
            Console.WriteLine($"Оценки: {string.Join(", ", student.GetGrades(0))}");
            Console.WriteLine($"Средний балл: {student.GetAverageGrade(0):F2}");

            Console.ReadKey();
        }
    }
}
