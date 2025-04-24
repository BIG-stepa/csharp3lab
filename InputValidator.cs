using System;

namespace CatalogOfServices
{
    public static class InputValidator
    {
        public static int GetInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка: Введите целое число.");
            }
        }

        public static decimal GetDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка: Введите число с плавающей точкой.");
            }
        }

        public static double GetDoubleInRange(string prompt, double min, double max)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Ошибка: Введите число в диапазоне от {min} до {max}.");
            }
        }

        public static string GetString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Ошибка: Поле не может быть пустым.");
            }
        }

        public static bool GetBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "true" || input == "false")
                {
                    return input == "true";
                }
                Console.WriteLine("Ошибка: Введите 'true' или 'false'.");
            }
        }
    }
}