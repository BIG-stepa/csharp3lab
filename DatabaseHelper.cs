using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CatalogOfServices
{
    public static class DatabaseHelper
    {
        private const string FilePath = "services.json";

        // Создание начальных данных
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

        // Чтение данных из файла
        public static List<Service> ReadData()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Файл базы данных не найден. Создается новый с начальными данными...");
                CreateInitialData();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Service>>(json) ?? new List<Service>();
        }

        // Сохранение данных в файл
        public static void SaveData(List<Service> services)
        {
            string json = JsonSerializer.Serialize(services, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}