using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    // 1. Структура Article (Товар)
    public struct Article
    {
        public string ProductCode { get; set; }      // код товара
        public string ProductName { get; set; }       // название товара
        public decimal Price { get; set; }            // цена товара

        public Article(string productCode, string productName, decimal price)
        {
            ProductCode = productCode;
            ProductName = productName;
            Price = price;
        }
    }

    // 2. Структура Client (Клиент)
    public struct Client
    {
        public string ClientCode { get; set; }        // код клиента
        public string FullName { get; set; }          // ФИО
        public string Address { get; set; }           // адрес
        public string Phone { get; set; }             // телефон
        public int OrderCount { get; set; }           // количество заказов
        public decimal TotalOrderAmount { get; set; } // общая сумма заказов

        public Client(string clientCode, string fullName, string address, string phone)
        {
            ClientCode = clientCode;
            FullName = fullName;
            Address = address;
            Phone = phone;
            OrderCount = 0;
            TotalOrderAmount = 0;
        }
    }

    // 3. Структура RequestItem (Позиция заказа)
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

    // 4. Структура Request (Заказ)
    public class Request
    {
        public string OrderCode { get; set; }           // код заказа
        public Client Client { get; set; }              // клиент
        public DateTime OrderDate { get; set; }         // дата заказа
        public List<RequestItem> Items { get; set; }    // перечень заказанных товаров

        public Request(string orderCode, Client client)
        {
            OrderCode = orderCode;
            Client = client;
            OrderDate = DateTime.Now;
            Items = new List<RequestItem>();
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
    }
    class Program
    {
        static void Main()
        {
            // Создаем товары
            Article product1 = new Article("P001", "Ноутбук", 75000.00m);
            Article product2 = new Article("P002", "Мышь", 1500.00m);

            // Создаем клиента
            Client client = new Client("C001", "Иванов Иван Иванович",
                                       "г. Москва, ул. Примерная, д. 1",
                                       "+7 (999) 123-45-67");

            // Создаем заказ
            Request order = new Request("ORD001", client);
            order.AddItem(product1, 1);
            order.AddItem(product2, 2);

            // Вывод информации
            Console.WriteLine($"Заказ: {order.OrderCode}");
            Console.WriteLine($"Клиент: {order.Client.FullName}");
            Console.WriteLine($"Дата: {order.OrderDate}");
            Console.WriteLine($"Товаров: {order.Items.Count}");
            Console.WriteLine($"Общая сумма: {order.GetTotalAmount():F2} руб.");
        }
    }
}
