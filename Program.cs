using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creyon
{
    // Задание 1
    /*
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число от 1 до 100: ");
            int val = Convert.ToInt32(Console.ReadLine());
            if (val < 1 || val > 100)
            {
                Console.WriteLine("Ошибка число не в диапазоне");
                return;
            }

            if (val % 5 == 0 && val % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (val % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (val % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(val);
            }
        }
    }
    */
    // Задание 2
    /*
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 число: ");
            int val1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
            int val2 = Convert.ToInt32(Console.ReadLine());

            int res = (val1 * val2) / 100;
            Console.WriteLine(res);
        }
    }
    */
    // Задание 3
    /*
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 число: ");
            string val1 = Console.ReadLine();
            Console.WriteLine("Введите 2 число: ");
            string val2 = Console.ReadLine();
            Console.WriteLine("Введите 3 число: ");
            string val3 = Console.ReadLine();
            Console.WriteLine("Введите 4 число: ");
            string val4 = Console.ReadLine();

            string res = val1 + val2 + val3 + val4;
            Console.WriteLine(res);
        }
    }
    */
    // Задание 4
    /*
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите шестизначное число: ");
            string val = Console.ReadLine();
            int length = val.Length;
            if (length != 6)
            {
                Console.WriteLine("Ошибка! Число не шестизначное!");
                return;
            }
            char[] charArray = val.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine(reversed);
        }
    }
    */

    // Задание 5
    /*
    internal class Program5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату в формате дд.мм.гггг:");
            string input = Console.ReadLine();

            // Parse the date from the input string
            string[] parts = input.Split('.');
            if (parts.Length != 3)
            {
                Console.WriteLine("Ошибка! Неверный формат даты");
                return;
            }

            int day = Convert.ToInt32(parts[0]);
            int month = Convert.ToInt32(parts[1]);
            int year = Convert.ToInt32(parts[2]);

            // Validate the date
            if (day < 1) { Console.WriteLine("Ошибка! День не может быть меньше 1"); return; }

            int max = 0;
            if (month == 1 || month == 3 ||
                month == 5 || month == 7 ||
                month == 8 || month == 10 || month == 12)
            {
                max = 31;
            }
            else if (month == 4 || month == 6 ||
                    month == 9 || month == 11)
            {
                max = 30;
            }
            else if (month == 2)
            {
                // Check for leap year
                if (DateTime.IsLeapYear(year))
                    max = 29;
                else
                    max = 28;
            }
            else
            {
                Console.WriteLine("Ошибка! В году только 12 месяцев");
                return;
            }

            if (day > max)
            {
                Console.WriteLine("Ошибка! Количество дней превышает допустимый максимум");
                return;
            }

            // Create DateTime object to get day of week
            DateTime date = new DateTime(year, month, day);

            // Determine season
            string season = GetSeason(month, day);

            // Get day of week in English
            string dayOfWeek = date.DayOfWeek.ToString();

            // Display result
            Console.WriteLine($"\n{season} {dayOfWeek}");
        }

        static string GetSeason(int month, int day)
        {
            // Meteorological seasons
            if (month == 12 && day >= 1)
                return "Winter";
            else if (month == 1 || month == 2)
                return "Winter";
            else if (month == 3)
                return day < 20 ? "Winter" : "Spring";
            else if (month == 4 || month == 5)
                return "Spring";
            else if (month == 6)
                return day < 21 ? "Spring" : "Summer";
            else if (month == 7 || month == 8)
                return "Summer";
            else if (month == 9)
                return day < 23 ? "Summer" : "Autumn";
            else if (month == 10 || month == 11)
                return "Autumn";
            else if (month == 12)
                return "Autumn";

            return "Unknown";
        }
    }
    */
    // Задание 6
    /*
    internal class Program6
    {
        static void Main(string[] args)
        {
            double degrees;
            int choice;
            Console.WriteLine("Введите градусы: ");
            degrees = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите\n1.Фаренгейта\n2.Цельсия");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    degrees /= 33.8;
                    Console.WriteLine($"Градусы Фаренгейты в Цельсия - {degrees}");
                    break;
                case 2:
                    degrees *= 33.8;
                    Console.WriteLine($"Градусы Цельсия в Фаренгейты - {degrees}");
                    break;
                default:
                    Console.WriteLine("Неверно введены данные");
                    break;
            }
        }
    }
    */
    internal class Program7
    {
        static void Main(string[] args)
        {
            int val1, val2;
            Console.WriteLine("Введите 1 число: ");
            val1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
            val2 = Convert.ToInt32(Console.ReadLine());

            if (val1 > val2)
            {
                int temp = val1;
                val1 = val2;
                val2 = temp;
            }

            Console.WriteLine($"\nЧетные числа в диапазоне от {val1} до {val2}: ");
            for (int i = val1; i <= val2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
