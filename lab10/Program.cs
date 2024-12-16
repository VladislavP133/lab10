using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Завдання 1 масив чисел
            Console.WriteLine("\nЗавдання 1: Масив чисел");
            var numbers = Enumerable.Range(150, 51).OrderBy(x => Guid.NewGuid()).Take(25).ToArray();
            var selected = from n in numbers
                           where n > 170
                           select n;
            var average = selected.Average();
            Console.WriteLine("Числа > 170: " + string.Join(", ", selected));
            Console.WriteLine("Середнє арифметичне: " + average);
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ReadLine();

            // Завдання 2 пшук слова у тексті
            Console.WriteLine("\nЗавдання 2: Пошук слова у тексті");
            string[] textArray = { "hello", "world", "this", "is", "a", "test" };
            Console.WriteLine("Введіть слово для пошуку:");
            string word = Console.ReadLine();
            bool exists = textArray.Contains(word, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(exists ? "Слово знайдено" : "Слово не знайдено");
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ReadLine();

            // Завдання 3 клас Model
            Console.WriteLine("\nЗавдання 3: Відбір моделей");
            var models = new List<Model>
            {
                new Model("Anna", "Ivanova", 22, 176, 50),
                new Model("Maria", "Petrova", 24, 178, 53),
                new Model("Olga", "Sidorova", 26, 175, 55),
                new Model("Irina", "Fedorova", 23, 180, 52),
                new Model("Kateryna", "Shevchenko", 21, 177, 49),
                new Model("Nina", "Tkachenko", 20, 179, 54),
                new Model("Sofia", "Bondarenko", 19, 174, 48),
                new Model("Viktoria", "Zhukova", 25, 181, 57),
                new Model("Diana", "Kravchenko", 22, 176, 51),
                new Model("Elena", "Voronova", 23, 175, 55)
            };

            var selectedModels = models
                .Where(m => m.Age <= 25 && m.Height >= 175 && m.Height <= 180 && m.Weight <= 55)
                .OrderBy(m => m.LastName);

            Console.WriteLine("Відібрані моделі:");
            foreach (var model in selectedModels)
            {
                Console.WriteLine($"{model.LastName} {model.Name}, Вік: {model.Age}, Зріст: {model.Height}, Вага: {model.Weight}");
            }

            var tallestModel = models.OrderByDescending(m => m.Height).FirstOrDefault();
            Console.WriteLine("Модель із найбільшим зростом: " + tallestModel.LastName + " " + tallestModel.Name);
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ReadLine();

            // Завдання 4 колекція доменов
            Console.WriteLine("\nЗавдання 4: Колекція доменів");
            var domains = new List<string> { "example.com", "site.org", "website.ua", "example.net", "shop.com", "blog.ua" };
            var selectedDomains = domains.Where(d => d.EndsWith(".com") || d.EndsWith(".ua"));
            Console.WriteLine("Відібрані домени: " + string.Join(", ", selectedDomains));
            Console.WriteLine("Кількість вибраних доменів: " + selectedDomains.Count());
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ReadLine();

            // Завдання 5 масив чисел  {4,3,2,1,7,8,9}
            Console.WriteLine("\nЗавдання 5: Сума та добуток чисел");
            int[] array = { 4, 3, 2, 1, 7, 8, 9 };
            int sum = array.Sum();
            int product = array.Aggregate(1, (acc, val) => acc * val);
            Console.WriteLine("Сума чисел: " + sum);
            Console.WriteLine("Добуток чисел: " + product);
            Console.WriteLine("Натисніть Enter, щоб продовжити...");
            Console.ReadLine();

            // Завдання 6 вибірка чисел
            Console.WriteLine("\nЗавдання 6: Вибірка чисел після значення 3");
            int indexOfThree = Array.IndexOf(array, 3); 

            if (indexOfThree != -1 && indexOfThree + 1 < array.Length)
            {
                var subset = array.Skip(indexOfThree + 1).Take(3);
                Console.WriteLine("Вибрані числа: " + string.Join(", ", subset));
            }
            else
            {
                Console.WriteLine("Число 3 не знайдено або неможливо вибрати 3 числа після нього.");
            }
            Console.WriteLine("Натисніть Enter, щоб завершити програму...");
            Console.ReadLine();
        }

        class Model
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }

            public Model(string name, string lastName, int age, int height, int weight)
            {
                Name = name;
                LastName = lastName;
                Age = age;
                Height = height;
                Weight = weight;
            }
        }
    }
}
