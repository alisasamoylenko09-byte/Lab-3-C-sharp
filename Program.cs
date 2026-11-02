using System;
using System.IO;

namespace Lab3Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення українських літер
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;

            // Головний цикл меню
            while (isRunning)
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine("                МЕНЮ ЛАБОРАТОРНОЇ             ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Завдання 1 (Обробка рядка з клавіатури)");
                Console.WriteLine("2. Завдання 2 (Слова з файлу на 's')");
                Console.WriteLine("3. Завдання 3 (Обробка input.txt -> output.txt)");
                Console.WriteLine("0. Вихід з програми");
                Console.WriteLine("==================================================");
                Console.Write("Виберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    Task1Menu();
                }
                else if (choice == "2")
                {
                    Task2Menu();
                }
                else if (choice == "3")
                {
                    Task3();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Дякую за використання програми! До побачення.");
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Невірний вибір! Введіть число від 0 до 3.");
                }
            }
        }

        // ==================================================
        // Меню для Завдання 1
        // ==================================================
        static void Task1Menu()
        {
            Console.WriteLine("--- Завдання 1 ---");
            Console.WriteLine("1. а) Підрахувати кількість слів, які починаються з голосної");
            Console.WriteLine("2. б) Вивести слова з непарною кількістю приголосних");
            Console.Write("Виберіть варіант (1 або 2): ");

            string subChoice = Console.ReadLine();
            Console.WriteLine();

            if (subChoice == "1")
            {
                Task1_PartA();
            }
            else if (subChoice == "2")
            {
                Task1_PartB();
            }
            else
            {
                Console.WriteLine("Невірний вибір підпункту.");
            }
        }

        // Завдання 1 (а)
        static void Task1_PartA()
        {
            Console.WriteLine("--- Завдання 1 (а) ---");
            Console.Write("Введіть текст: ");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');
            string vowels = "аеєиіїоуюяaeiouyАЕЄИІЇОУЮЯAEIOUY";

            int vowelWordsCount = 0;

            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstChar = word[0];
                    if (vowels.Contains(firstChar.ToString()))
                    {
                        vowelWordsCount++;
                    }
                }
            }

            Console.WriteLine("Кількість слів, що починаються з голосної літери: " + vowelWordsCount);
        }

        // Завдання 1 (б)
        static void Task1_PartB()
        {
            Console.WriteLine("--- Завдання 1 (б) ---");
            Console.Write("Введіть текст: ");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');
            string consonants = "бвгґджзклмнпрстфхцчшщbcdfghjklmnpqrstvwxzБВГҐДЖЗКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXZ";

            Console.WriteLine("Слова з непарною кількістю приголосних:");
            bool foundAny = false;

            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    int consonantCount = 0;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (consonants.Contains(word[i].ToString()))
                        {
                            consonantCount++;
                        }
                    }

                    if (consonantCount % 2 != 0)
                    {
                        Console.WriteLine("- " + word);
                        foundAny = true;
                    }
                }
            }

            if (!foundAny)
            {
                Console.WriteLine("Таких слів не знайдено.");
            }
        }

        // ==================================================
        // Завдання 2
        // ==================================================
        static void Task2Menu()
        {
            Console.WriteLine("--- Завдання 2 ---");
            Console.WriteLine("1. а) Відомо, що у файлі записано 10 слів");
            Console.WriteLine("2. б) Розмір файлу невідомий (випадкова кількість слів)");
            Console.Write("Виберіть варіант (1 або 2): ");

            string subChoice = Console.ReadLine();
            Console.WriteLine();

            string filePath = "task2_input.txt";
            Random rnd = new Random();

            string[] dictionary = { "sun", "coffee", "student", "summer", "star", "winter", "mirror", "apple", "silver", "banana", "cat", "dog", "code", "shadow", "blanket", "sudden", "paper", "whisper", "forest" };

            if (subChoice == "1")
            {
                // === ВАРІАНТ А (Генеруємо рівно 10 слів) ===
                string[] generatedWords = GenerateUniqueSequence(dictionary, 10, rnd);

                string textForFile = string.Join(" ", generatedWords);
                File.WriteAllText(filePath, textForFile);

                Console.WriteLine("Згенеровано та записано у файл 10 слів:");
                Console.WriteLine(textForFile);
                Console.WriteLine();

                // Масив строго на 10 елементів
                string[] words = new string[10];
                string text = File.ReadAllText(filePath);
                string[] tempWords = text.Split(' ');

                for (int i = 0; i < 10; i++)
                {
                    words[i] = tempWords[i];
                }

                Console.WriteLine("Слова, що починаються на 's' (Варіант А):");
                bool found = false;
                for (int i = 0; i < 10; i++)
                {
                    if (words[i].Length > 0)
                    {
                        string lowerWord = words[i].ToLower();
                        if (lowerWord[0] == 's')
                        {
                            Console.WriteLine("- " + words[i]);
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("У цьому запуску слів на 's' не випало.");
                }
            }
            else if (subChoice == "2")
            {
                // === ВАРІАНТ Б (Генеруємо випадкову кількість слів від 5 до 20) ===
                int randomWordCount = rnd.Next(5, 21);
                string[] generatedWords = GenerateUniqueSequence(dictionary, randomWordCount, rnd);

                string textForFile = string.Join(" ", generatedWords);
                File.WriteAllText(filePath, textForFile);

                Console.WriteLine("Згенеровано та записано у файл " + randomWordCount + " слів:");
                Console.WriteLine(textForFile);
                Console.WriteLine();

                // Динамічний розмір через Split
                string text = File.ReadAllText(filePath);
                string[] words = text.Split(' ');

                Console.WriteLine("Слова, що починаються на 's' (Варіант Б):");
                bool found = false;

                foreach (string word in words)
                {
                    if (word.Length > 0)
                    {
                        string lowerWord = word.ToLower();
                        if (lowerWord[0] == 's')
                        {
                            Console.WriteLine("- " + word);
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("У цьому запуску слів на 's' не випало.");
                }
            }
            else
            {
                Console.WriteLine("Невірний вибір підпункту.");
            }
        }

        // ==================================================
        // Завдання 3
        // ==================================================
        static void Task3()
        {
            Console.WriteLine("--- Завдання 3 ---");
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            Random rnd = new Random();

            string[] dictionary = { "кіт", "книга", "програма", "авто", "тест", "колір", "паркан", "слово", "комп'ютер", "вікно" };

            // Генеруємо випадковий текст у input.txt (від 6 до 12 слів)
            int randomCount = rnd.Next(6, 13);
            string[] generatedWords = GenerateUniqueSequence(dictionary, randomCount, rnd);

            string generatedText = string.Join(" ", generatedWords);

            // Записуємо згенеровані слова в input.txt
            File.WriteAllText(inputFile, generatedText);

            // Зчитуємо текст із input.txt
            string text = File.ReadAllText(inputFile);
            string[] words = text.Split(' ');

            string vowels = "аеєиіїоуюяaeiouyАЕЄИІЇОУЮЯAEIOUY";
            string resultText = "";

            foreach (string word in words)
            {
                bool remove = false;

                // Видаляємо слово, якщо передостання літера є голосною
                if (word.Length >= 2)
                {
                    char penultimateChar = word[word.Length - 2];

                    if (vowels.Contains(penultimateChar.ToString()))
                    {
                        remove = true;
                    }
                }

                if (!remove)
                {
                    resultText += word + " ";
                }
            }

            // Записуємо результат в output.txt
            File.WriteAllText(outputFile, resultText.Trim());

            Console.WriteLine("Повний шлях до файлу: " + Path.GetFullPath(inputFile));
            Console.WriteLine("Згенеровано та записано у " + inputFile + ":");
            Console.WriteLine(text);
            Console.WriteLine("\nОброблено та записано у " + outputFile + " (без слів з голосною передостаньою літерою):");
            Console.WriteLine(resultText.Trim());
        }

        // ==================================================
        // Допоміжний метод генерації послідовності слів не підряд і не більше 2 разів
        // ==================================================
        static string[] GenerateUniqueSequence(string[] dict, int count, Random rnd)
        {
            string[] result = new string[count];

            for (int i = 0; i < count; i++)
            {
                string candidate = "";
                bool isValid = false;

                while (!isValid)
                {
                    int randomIndex = rnd.Next(0, dict.Length);
                    candidate = dict[randomIndex];

                    // 1. Перевірка: слово не повинно збігатися з попереднім (гарантує хоча б 1 інше слово між ними)
                    if (i > 0 && result[i - 1] == candidate)
                    {
                        continue;
                    }

                    // 2. Перевірка: слово не повинно повторюватися більше 2 разів загалом
                    int usedCount = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (result[j] == candidate)
                        {
                            usedCount++;
                        }
                    }

                    if (usedCount < 2)
                    {
                        isValid = true;
                    }
                }

                result[i] = candidate;
            }

            return result;
        }
    }
}