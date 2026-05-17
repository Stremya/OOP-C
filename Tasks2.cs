using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks2
{
    // Задание 1
    /*
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 1: Анализ массива ===\n");

            int[] array = { 1, 2, 3, 4, 5, 2, 3, 1, 6, 7, 8, 9, 10, 5 };

            Console.WriteLine("Массив: " + string.Join(" ", array));

            int evenCount = array.Count(x => x % 2 == 0);
            Console.WriteLine($"Количество чётных: {evenCount}");

            int oddCount = array.Count(x => x % 2 != 0);
            Console.WriteLine($"Количество нечётных: {oddCount}");

            int uniqueCount = array.Distinct().Count();
            Console.WriteLine($"Количество уникальных: {uniqueCount}");

            var uniqueElements = array.Distinct().OrderBy(x => x);
            Console.WriteLine("Уникальные элементы: " + string.Join(" ", uniqueElements));
        }
    }
    */
    // Задание 2
    /*
    internal class Program2
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 2: Значения меньше заданного ===\n");

            int[] array = { 1, 5, 3, 8, 2, 9, 4, 7, 6, 10, 3, 5, 2, 8 };

            Console.WriteLine("Массив: " + string.Join(" ", array));
            Console.Write("Введите число для сравнения: ");
            int threshold = int.Parse(Console.ReadLine());

            // Подсчёт элементов меньше заданного
            int count = array.Count(x => x < threshold);

            // Вывод элементов меньше заданного
            var elements = array.Where(x => x < threshold).OrderBy(x => x);

            Console.WriteLine($"\nКоличество значений меньше {threshold}: {count}");
            Console.WriteLine("Эти значения: " + string.Join(" ", elements));

            // Дополнительная статистика
            Console.WriteLine($"\nСтатистика:");
            Console.WriteLine($"Меньше {threshold}: {array.Count(x => x < threshold)}");
            Console.WriteLine($"Равно {threshold}: {array.Count(x => x == threshold)}");
            Console.WriteLine($"Больше {threshold}: {array.Count(x => x > threshold)}");
        }
    }
    */

    // Задание 3
    /*
    internal class Program3
    {
        static int CountSequence(int[] array, int[] sequence)
        {
            int count = 0;
            for (int i = 0; i <= array.Length - sequence.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (array[i + j] != sequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    count++;
                    Console.WriteLine($"Найдено совпадение на позиции {i}");
                }
            }
            return count;
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 3: Поиск последовательности ===\n");

            int[] array = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };
            int[] sequence = new int[3];

            Console.WriteLine("Массив: " + string.Join(" ", array));

            Console.WriteLine("Введите три числа последовательности:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Число {i + 1}: ");
                sequence[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"\nПоиск последовательности: {string.Join(" ", sequence)}");

            int count = CountSequence(array, sequence);
            Console.WriteLine($"\nКоличество повторений последовательности: {count}");
        }
    }
    */

    // Задание 4
    /*
    internal class Program4
    {
        static void Main()
        {
            Console.WriteLine("=== Задание 4: Общие элементы массивов ===\n");

            int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 2, 3 };
            int[] array2 = { 4, 5, 6, 7, 8, 9, 10, 4, 5 };

            Console.WriteLine("Массив 1: " + string.Join(" ", array1));
            Console.WriteLine("Массив 2: " + string.Join(" ", array2));

            // Поиск общих элементов без повторений
            int[] commonElements = array1.Intersect(array2).ToArray();

            Console.WriteLine($"\nОбщие элементы без повторений: {string.Join(" ", commonElements)}");
            Console.WriteLine($"Количество общих элементов: {commonElements.Length}");

            // Создание третьего массива
            int[] resultArray = commonElements;

            Console.WriteLine("\nТретий массив (результат): " + string.Join(" ", resultArray));
        }
    }
    */

    // Задание 5
    /*
    internal class Program5
    {
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }

        static (int min, int max, int minRow, int minCol, int maxRow, int maxCol)
            FindMinMax(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int min = matrix[0, 0];
            int max = matrix[0, 0];
            int minRow = 0, minCol = 0;
            int maxRow = 0, maxCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            return (min, max, minRow, minCol, maxRow, maxCol);
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 5: Мин и макс в матрице ===\n");

            int[,] matrix = {
            { 5, 12, 3, 8 },
            { 15, 7, 22, 1 },
            { 9, 18, 4, 11 },
            { 6, 20, 14, 2 }
        };

            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);

            var result = FindMinMax(matrix);

            Console.WriteLine($"\nМинимальное значение: {result.min}");
            Console.WriteLine($"Позиция минимума: строка {result.minRow + 1}, столбец {result.minCol + 1}");
            Console.WriteLine($"\nМаксимальное значение: {result.max}");
            Console.WriteLine($"Позиция максимума: строка {result.maxRow + 1}, столбец {result.maxCol + 1}");
        }
    }
    */

    // Задание 6
    /*
    internal class Program6
    {
        static int CountWords(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return 0;

            // Разбиваем строку по пробелам и фильтруем пустые элементы
            return sentence.Split(new char[] { ' ', '\t', '\n', '\r' },
                                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 6: Подсчёт слов ===\n");

            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();

            int wordCount = CountWords(input);

            Console.WriteLine($"\nИсходное предложение: \"{input}\"");
            Console.WriteLine($"Количество слов: {wordCount}");

            // Вывод каждого слова
            if (wordCount > 0)
            {
                string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' },
                                           StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("\nСлова:");
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. \"{words[i]}\"");
                }
            }
        }
    }
    */

    // Задание 7
    /*
    internal class Program7
    {
        static string ReverseWord(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static string ReverseEachWord(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return sentence;

            string[] words = sentence.Split(new char[] { ' ', '\t', '\n', '\r' },
                                           StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ReverseWord(words[i]);
            }

            return string.Join(" ", words);
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 7: Переворот слов ===\n");

            // Тестовый пример
            string testInput = "sun cat dogs cup tea";
            Console.WriteLine($"Тестовый пример:");
            Console.WriteLine($"Исходное: \"{testInput}\"");
            Console.WriteLine($"Результат: \"{ReverseEachWord(testInput)}\"");

            // Ввод пользователя
            Console.Write("\nВведите предложение: ");
            string userInput = Console.ReadLine();

            Console.WriteLine($"\nИсходное предложение: \"{userInput}\"");
            Console.WriteLine($"После переворота: \"{ReverseEachWord(userInput)}\"");
        }
    }
    */

    // Задание 8
    /*
    internal class Program8
    {
        static int CountVowels(string text)
        {
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                         'a', 'e', 'i', 'o', 'u', 'y' };

            return text.ToLower().Count(c => vowels.Contains(c));
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 8: Подсчёт гласных ===\n");

            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();

            int vowelCount = CountVowels(input);

            Console.WriteLine($"\nИсходное предложение: \"{input}\"");
            Console.WriteLine($"Количество гласных букв: {vowelCount}");

            // Детальный анализ
            Console.WriteLine($"\nСтатистика:");
            Console.WriteLine($"Всего символов: {input.Length}");
            Console.WriteLine($"Гласных: {vowelCount}");
            Console.WriteLine($"Согласных и других: {input.Length - vowelCount}");

            // Подсчёт каждой гласной
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                         'a', 'e', 'i', 'o', 'u', 'y' };

            Console.WriteLine("\nДетализация по гласным:");
            foreach (char vowel in vowels)
            {
                int count = input.ToLower().Count(c => c == vowel);
                if (count > 0)
                {
                    Console.WriteLine($"'{vowel}': {count} раз(а)");
                }
            }
        }
    }
    */

    // Задание 9
    internal class Program9
    {
        static int CountSubstringOccurrences(string text, string substring)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(substring))
                return 0;

            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(substring, index,
                   StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += substring.Length;
            }

            return count;
        }

        static void Main()
        {
            Console.WriteLine("=== Задание 9: Поиск подстроки ===\n");

            // Тестовый пример
            string testText = "Why she had to go. I don't know, she wouldn't say";
            string testSubstring = "she";

            Console.WriteLine("Тестовый пример:");
            Console.WriteLine($"Текст: \"{testText}\"");
            Console.WriteLine($"Подстрока: \"{testSubstring}\"");
            Console.WriteLine($"Количество вхождений: {CountSubstringOccurrences(testText, testSubstring)}");

            // Ввод пользователя
            Console.Write("\nВведите исходную строку: ");
            string text = Console.ReadLine();

            Console.Write("Введите слово для поиска: ");
            string substring = Console.ReadLine();

            int occurrences = CountSubstringOccurrences(text, substring);

            Console.WriteLine($"\nРезультат поиска: {occurrences}");

            if (occurrences > 0)
            {
                Console.WriteLine($"\nПодстрока \"{substring}\" найдена {occurrences} раз(а)");
            }
            else
            {
                Console.WriteLine($"Подстрока \"{substring}\" не найдена");
            }
        }
    }
}
