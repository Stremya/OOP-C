using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_practice

{   // Задание 1
    /*
    internal class Task1
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину прямоугольника A: ");
            int A = GetPositiveInteger();

            Console.Write("Введите ширину прямоугольника B: ");
            int B = GetPositiveInteger();

            Console.Write("Введите сторону квадрата C: ");
            int C = GetPositiveInteger();

            
            if (C > A && C > B)
            {
                Console.WriteLine($"\nОШИБКА: Невозможно разместить ни одного квадрата со стороной {C}!");
                Console.WriteLine($"Сторона квадрата ({C}) превышает обе стороны прямоугольника ({A}x{B}).");
                return;
            }
            else if (C > A)
            {
                Console.WriteLine($"\nОШИБКА: Невозможно разместить ни одного квадрата со стороной {C}!");
                Console.WriteLine($"Сторона квадрата ({C}) превышает длину прямоугольника ({A}).");
                return;
            }
            else if (C > B)
            {
                Console.WriteLine($"\nОШИБКА: Невозможно разместить ни одного квадрата со стороной {C}!");
                Console.WriteLine($"Сторона квадрата ({C}) превышает ширину прямоугольника ({B}).");
                return;
            }

            int squaresHorizontal = A / C;  
            int squaresVertical = B / C;    

            // Общее количество квадратов
            int totalSquares = squaresHorizontal * squaresVertical;

            // Вычисление площади
            int rectangleArea = A * B;
            int squaresArea = totalSquares * (C * C);
            int unoccupiedArea = rectangleArea - squaresArea;

            // Вывод результатов
            Console.WriteLine("РЕЗУЛЬТАТЫ:");
            Console.WriteLine($"Прямоугольник: {A} x {B} (площадь: {rectangleArea})");
            Console.WriteLine($"Квадраты: {C} x {C} (площадь одного: {C * C})");
            Console.WriteLine($"Количество квадратов по горизонтали: {squaresHorizontal}");
            Console.WriteLine($"Количество квадратов по вертикали: {squaresVertical}");
            Console.WriteLine($"Общее количество квадратов: {totalSquares}");
            Console.WriteLine($"Площадь, занятая квадратами: {squaresArea}");
            Console.WriteLine($"Площадь незанятой части: {unoccupiedArea}");

            Console.ReadKey();
        }

        // Метод для получения положительного целого числа
        static int GetPositiveInteger()
        {
            int number;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number) && number > 0)
                {
                    return number;
                }
                Console.Write("Ошибка! Введите положительное целое число: ");
            }
        }
    
    }
    */
    // Задание 2
    /*
    internal class Task2
    {
        static void Main(string[] args)
        {
            double bank = 10000; // начальный вклад в банке
            int percent; // процент введеный пользователем
            double convertP; // вещественное число от процента 
            double calc; // процент от текущего вклада
            int monthes = 0;

            while (bank < 11000) {
                Console.WriteLine($"Текущий вклад: {bank}");
                Console.WriteLine("Введите процент имеющейся суммы (0-25): ");
                percent = Convert.ToInt32(Console.ReadLine());
                if (percent < 0 || percent > 25)
                {
                    Console.WriteLine("Ошибка! Процент в недопустимых границах");
                    continue;
                }
                convertP = percent / 100.0;
                calc = bank * convertP;
                bank += calc;

                monthes++;
            }

            Console.WriteLine($"Вклад в банк превысит 11000 рублей через {monthes} месяцев");
        }
    }
    */

    // Задание 3
    /*
    internal class Task3
    {
        static void Main(string[] args)
        {
            int val1, val2;
            Console.WriteLine("Введите 1 число: ");
            val1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
            val2 = Convert.ToInt32(Console.ReadLine());

            if (val2 < val1)
            {
                Console.WriteLine("Ошибка! 1 число больше 2");
                return;
            }

            for (int i = val1; i <= val2; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i);

                    if (j < i - 1)
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
    */
    internal class Task4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            string count = Console.ReadLine();
            char[] countArr = count.ToCharArray();
            Array.Reverse(countArr);
            string reversedCount = new string(countArr);

            Console.WriteLine($"Введенное вами число: {count}");
            Console.WriteLine($"Перевернутое: {reversedCount}");

        }
    }
}
