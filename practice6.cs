using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("=== Программа «Статистика» ===\n");

            string text = "Вот дом, Который построил Джек. " +
                         "А это пшеница, Которая в темном чулане хранится " +
                         "В доме, Который построил Джек. " +
                         "А это веселая птица-синица, Которая часто ворует пшеницу, " +
                         "Которая в темном чулане хранится " +
                         "В доме, Который построил Джек.";

            Console.WriteLine("Исходный текст:");
            Console.WriteLine(text);
            Console.WriteLine();

            string[] words = text
                .ToLower()                          
                .Replace(",", "")                  
                .Replace(".", "")                   
                .Replace("-", " ")                  
                .Split(new char[] { ' ' },          
                       StringSplitOptions.RemoveEmptyEntries); 

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }

            var sortedWordCount = wordCount
                .OrderByDescending(pair => pair.Value)  
                .ThenBy(pair => pair.Key)               
                .ToList();

            Console.WriteLine("Статистика по тексту:");
            Console.WriteLine(new string('─', 45));
            Console.WriteLine($"{"№",-4} {"Слово",-25} {"Количество",-10}");
            Console.WriteLine(new string('─', 45));

            int number = 1;
            foreach (var pair in sortedWordCount)
            {
                Console.WriteLine($"{number,-4} {pair.Key,-25} {pair.Value,-10}");
                number++;
            }

            Console.WriteLine(new string('─', 45));
            Console.WriteLine($"Всего уникальных слов: {wordCount.Count}");
            Console.WriteLine($"Всего слов в тексте: {words.Length}");

            Console.WriteLine("\n\nДополнительная статистика:");
            Console.WriteLine(new string('─', 45));

            var mostFrequent = sortedWordCount.First();
            Console.WriteLine($"Самое частое слово: '{mostFrequent.Key}' (встречается {mostFrequent.Value} раз(а))");

            var uniqueWords = sortedWordCount.Where(pair => pair.Value == 1).ToList();
            Console.WriteLine($"\nСлова, встречающиеся 1 раз ({uniqueWords.Count}):");
            foreach (var pair in uniqueWords)
            {
                Console.WriteLine($"  • {pair.Key}");
            }

            Console.WriteLine("\nГруппировка по частоте:");
            var groupedByCount = wordCount
                .GroupBy(pair => pair.Value)
                .OrderByDescending(group => group.Key);

            foreach (var group in groupedByCount)
            {
                Console.WriteLine($"  Встречается {group.Key} раз(а): {string.Join(", ", group.Select(p => p.Key))}");
            }

            Console.ReadKey();
        }
    }
}
