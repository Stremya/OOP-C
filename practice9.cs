using System;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace practice
{
    // Класс «Счет для оплаты»
    [Serializable]
    public class PaymentInvoice
    {
        // Основные поля
        public double DailyRate { get; set; }              // оплата за день
        public int DaysCount { get; set; }                 // количество дней
        public double PenaltyPerDay { get; set; }          // штраф за один день задержки
        public int DelayedDays { get; set; }               // количество дней задержки оплаты

        // Статическое свойство, влияющее на сериализацию вычисляемых полей
        public static bool SerializeCalculatedFields { get; set; } = true;

        // Вычисляемое поле: сумма к оплате без штрафа
        public double AmountWithoutPenalty
        {
            get { return DailyRate * DaysCount; }
        }

        // Вычисляемое поле: штраф
        public double Penalty
        {
            get { return PenaltyPerDay * DelayedDays; }
        }

        // Вычисляемое поле: общая сумма к оплате
        public double TotalAmount
        {
            get { return AmountWithoutPenalty + Penalty; }
        }

        // Конструктор по умолчанию
        public PaymentInvoice()
        {
            DailyRate = 0;
            DaysCount = 0;
            PenaltyPerDay = 0;
            DelayedDays = 0;
        }

        // Конструктор с параметрами
        public PaymentInvoice(double dailyRate, int daysCount,
                             double penaltyPerDay, int delayedDays)
        {
            DailyRate = dailyRate;
            DaysCount = daysCount;
            PenaltyPerDay = penaltyPerDay;
            DelayedDays = delayedDays;
        }

        // Метод для отображения информации о счете
        public void DisplayInfo()
        {
            Console.WriteLine("\n=== СЧЕТ НА ОПЛАТУ ===");
            Console.WriteLine($"Оплата за день: {DailyRate:C2}");
            Console.WriteLine($"Количество дней: {DaysCount}");
            Console.WriteLine($"Сумма без штрафа: {AmountWithoutPenalty:C2}");
            Console.WriteLine($"Штраф за день задержки: {PenaltyPerDay:C2}");
            Console.WriteLine($"Дней задержки: {DelayedDays}");
            Console.WriteLine($"Штраф: {Penalty:C2}");
            Console.WriteLine($"ИТОГО К ОПЛАТЕ: {TotalAmount:C2}");
            Console.WriteLine("=======================");
        }
    }

    // Класс для демонстрации сериализации и десериализации
    public class InvoiceSerializer
    {
        // Метод для сериализации в JSON (собственная реализация)
        public static string SerializeToJson(PaymentInvoice invoice)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");

            // Основные поля
            sb.AppendLine($"  \"DailyRate\": {invoice.DailyRate},");
            sb.AppendLine($"  \"DaysCount\": {invoice.DaysCount},");
            sb.AppendLine($"  \"PenaltyPerDay\": {invoice.PenaltyPerDay},");
            sb.AppendLine($"  \"DelayedDays\": {invoice.DelayedDays}");

            // Если нужно сериализовать вычисляемые поля
            if (PaymentInvoice.SerializeCalculatedFields)
            {
                sb.AppendLine(",");
                sb.AppendLine($"  \"AmountWithoutPenalty\": {invoice.AmountWithoutPenalty},");
                sb.AppendLine($"  \"Penalty\": {invoice.Penalty},");
                sb.AppendLine($"  \"TotalAmount\": {invoice.TotalAmount}");
            }

            sb.AppendLine();
            sb.Append("}");

            return sb.ToString();
        }

        // Метод для десериализации из JSON (собственная реализация)
        public static PaymentInvoice DeserializeFromJson(string json)
        {
            PaymentInvoice invoice = new PaymentInvoice();

            // Простой парсинг JSON строки
            string[] lines = json.Split(new char[] { '\n', '\r' },
                                       StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim().TrimEnd(',');

                if (trimmedLine.StartsWith("\"DailyRate\""))
                {
                    string value = ExtractValue(trimmedLine);
                    invoice.DailyRate = double.Parse(value);
                }
                else if (trimmedLine.StartsWith("\"DaysCount\""))
                {
                    string value = ExtractValue(trimmedLine);
                    invoice.DaysCount = int.Parse(value);
                }
                else if (trimmedLine.StartsWith("\"PenaltyPerDay\""))
                {
                    string value = ExtractValue(trimmedLine);
                    invoice.PenaltyPerDay = double.Parse(value);
                }
                else if (trimmedLine.StartsWith("\"DelayedDays\""))
                {
                    string value = ExtractValue(trimmedLine);
                    invoice.DelayedDays = int.Parse(value);
                }
            }

            return invoice;
        }

        // Вспомогательный метод для извлечения значения из JSON строки
        private static string ExtractValue(string jsonLine)
        {
            int colonIndex = jsonLine.IndexOf(':');
            if (colonIndex == -1) return "0";

            string value = jsonLine.Substring(colonIndex + 1).Trim();
            return value;
        }

        // Метод для сериализации в XML
        public static string SerializeToXml(PaymentInvoice invoice)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PaymentInvoice));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, invoice);
                return writer.ToString();
            }
        }

        // Метод для десериализации из XML
        public static PaymentInvoice DeserializeFromXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PaymentInvoice));
            using (StringReader reader = new StringReader(xml))
            {
                return (PaymentInvoice)serializer.Deserialize(reader);
            }
        }

        // Сохранение в файл
        public static void SaveToFile(string filePath, PaymentInvoice invoice, string format = "json")
        {
            try
            {
                string data;
                if (format.ToLower() == "xml")
                {
                    data = SerializeToXml(invoice);
                }
                else
                {
                    data = SerializeToJson(invoice);
                }

                File.WriteAllText(filePath, data);
                Console.WriteLine($"\nДанные сохранены в файл: {filePath}");
                Console.WriteLine($"Формат: {format.ToUpper()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        // Чтение из файла
        public static PaymentInvoice LoadFromFile(string filePath, string format = "json")
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл {filePath} не найден!");
                    return null;
                }

                string data = File.ReadAllText(filePath);

                if (format.ToLower() == "xml")
                {
                    return DeserializeFromXml(data);
                }
                else
                {
                    return DeserializeFromJson(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }
    }

    class MainProgram
    {
        static void Main()
        {
            Console.WriteLine("=== Демонстрация класса «Счет для оплаты» ===\n");

            // Создание нескольких счетов для демонстрации
            PaymentInvoice invoice1 = new PaymentInvoice(1500.50, 30, 100, 5);
            PaymentInvoice invoice2 = new PaymentInvoice(2500, 20, 150, 3);
            PaymentInvoice invoice3 = new PaymentInvoice(800, 45, 50, 10);

            // Демонстрация вычисляемых полей
            Console.WriteLine("1. Демонстрация счетов:");
            invoice1.DisplayInfo();
            invoice2.DisplayInfo();
            invoice3.DisplayInfo();

            // Демонстрация сериализации с вычисляемыми полями
            Console.WriteLine("\n2. Сериализация С ВЫЧИСЛЯЕМЫМИ ПОЛЯМИ:");
            PaymentInvoice.SerializeCalculatedFields = true;

            string jsonWithCalculated = InvoiceSerializer.SerializeToJson(invoice1);
            Console.WriteLine("\nJSON с вычисляемыми полями:");
            Console.WriteLine(jsonWithCalculated);

            // Сохранение в файл с вычисляемыми полями
            InvoiceSerializer.SaveToFile("invoice_full.json", invoice1);
            InvoiceSerializer.SaveToFile("invoice_full.xml", invoice1, "xml");

            // Демонстрация сериализации без вычисляемых полей
            Console.WriteLine("\n3. Сериализация БЕЗ ВЫЧИСЛЯЕМЫХ ПОЛЕЙ:");
            PaymentInvoice.SerializeCalculatedFields = false;

            string jsonWithoutCalculated = InvoiceSerializer.SerializeToJson(invoice1);
            Console.WriteLine("\nJSON без вычисляемых полей:");
            Console.WriteLine(jsonWithoutCalculated);

            // Сохранение в файл без вычисляемых полей
            InvoiceSerializer.SaveToFile("invoice_basic.json", invoice1);
            InvoiceSerializer.SaveToFile("invoice_basic.xml", invoice1, "xml");

            // Демонстрация чтения из файла
            Console.WriteLine("\n4. Чтение данных из файлов:");

            Console.WriteLine("\nЧтение полного JSON:");
            PaymentInvoice loadedFull = InvoiceSerializer.LoadFromFile("invoice_full.json");
            if (loadedFull != null)
            {
                loadedFull.DisplayInfo();
            }

            Console.WriteLine("\nЧтение базового JSON (без вычисляемых полей):");
            PaymentInvoice loadedBasic = InvoiceSerializer.LoadFromFile("invoice_basic.json");
            if (loadedBasic != null)
            {
                loadedBasic.DisplayInfo();
            }

            Console.WriteLine("\nЧтение XML файла:");
            PaymentInvoice loadedXml = InvoiceSerializer.LoadFromFile("invoice_full.xml", "xml");
            if (loadedXml != null)
            {
                loadedXml.DisplayInfo();
            }

            // Демонстрация изменения статического свойства
            Console.WriteLine("\n5. Демонстрация влияния статического свойства:");

            PaymentInvoice.SerializeCalculatedFields = true;
            Console.WriteLine($"\nSerializeCalculatedFields = {PaymentInvoice.SerializeCalculatedFields}");
            string json1 = InvoiceSerializer.SerializeToJson(invoice2);
            Console.WriteLine($"Длина JSON: {json1.Length} символов");
            Console.WriteLine("Содержит вычисляемые поля: " +
                (json1.Contains("AmountWithoutPenalty") &&
                 json1.Contains("Penalty") &&
                 json1.Contains("TotalAmount")));

            PaymentInvoice.SerializeCalculatedFields = false;
            Console.WriteLine($"\nSerializeCalculatedFields = {PaymentInvoice.SerializeCalculatedFields}");
            string json2 = InvoiceSerializer.SerializeToJson(invoice2);
            Console.WriteLine($"Длина JSON: {json2.Length} символов");
            Console.WriteLine("Содержит вычисляемые поля: " +
                (json2.Contains("AmountWithoutPenalty") &&
                 json2.Contains("Penalty") &&
                 json2.Contains("TotalAmount")));

            // Интерактивный режим
            Console.WriteLine("\n6. Интерактивное создание счета:");
            CreateInvoiceInteractively();

            // Вывод информации о созданных файлах
            Console.WriteLine("\n7. Созданные файлы:");
            DisplayFilesInfo();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void CreateInvoiceInteractively()
        {
            try
            {
                Console.Write("Введите оплату за день: ");
                double dailyRate = double.Parse(Console.ReadLine());

                Console.Write("Введите количество дней: ");
                int daysCount = int.Parse(Console.ReadLine());

                Console.Write("Введите штраф за один день задержки: ");
                double penaltyPerDay = double.Parse(Console.ReadLine());

                Console.Write("Введите количество дней задержки оплаты: ");
                int delayedDays = int.Parse(Console.ReadLine());

                PaymentInvoice invoice = new PaymentInvoice(dailyRate, daysCount,
                                                          penaltyPerDay, delayedDays);

                invoice.DisplayInfo();

                // Сохранение в файл
                Console.Write("\nВведите имя файла для сохранения (без расширения): ");
                string fileName = Console.ReadLine();

                if (!string.IsNullOrEmpty(fileName))
                {
                    InvoiceSerializer.SaveToFile(fileName + ".json", invoice);
                    InvoiceSerializer.SaveToFile(fileName + ".xml", invoice, "xml");
                    Console.WriteLine($"Счет сохранен в файлы {fileName}.json и {fileName}.xml");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено некорректное значение!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DisplayFilesInfo()
        {
            string[] files = { "invoice_full.json", "invoice_full.xml",
                              "invoice_basic.json", "invoice_basic.xml" };

            Console.WriteLine("\nИнформация о файлах:");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"Имя файла",-25} {"Существует",-12} {"Размер",-10}");
            Console.WriteLine(new string('-', 60));

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"{file,-25} {"Да",-12} {fileInfo.Length,8} байт");
                }
                else
                {
                    Console.WriteLine($"{file,-25} {"Нет",-12} {"-",10}");
                }
            }
            Console.WriteLine(new string('-', 60));
        }
    }
}