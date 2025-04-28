using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CatalogOfServices
{
    public static class DatabaseHelper
    {
        // Путь к файлу базы данных 
        private const string FilePath = "services.json";

        // Создание начальных данных для базы данных
        public static void CreateInitialData()
        {
            var services = new List<Service>
            {
                new Service(1, "Разработка сайта", 5000, "Техническая", 4.8, true),
                new Service(2, "Юридическая консультация", 1500, "Юридическая", 4.5, true),
                new Service(3, "Услуги сантехника", 800, "Бытовая", 4.2, false),
                new Service(4, "Дизайн логотипа", 3000, "Творческая", 4.7, true),
                new Service(5, "Подготовка декларации", 2000, "Финансовая", 4.0, true)
            };

            SaveData(services); 
        }

        // Чтение данных из файла базы данных
        public static List<Service> ReadData()
        {
            if (!File.Exists(FilePath))
            {
                // Если файл не существует, создаем новый с начальными данными
                Console.WriteLine("Файл базы данных не найден. Создается новый с начальными данными...");
                CreateInitialData();
            }

            string json = File.ReadAllText(FilePath);

            // Десериализация JSON в объект List<Service>
            // JsonSerializer.Deserialize может вернуть null, если данные некорректны,
            // поэтому используется оператор ?? для возврата пустого списка в таком случае.
            return JsonSerializer.Deserialize<List<Service>>(json) ?? new List<Service>();
        }

        public static void SaveData(List<Service> services)
        {
            // Сериализация данных в JSON с отступами для удобства чтения
            // WriteIndented = true делает JSON более читаемым для человека.
            string json = JsonSerializer.Serialize(services, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FilePath, json);
        }
    }
}
