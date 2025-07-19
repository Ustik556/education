using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1000;

            // Сериализуемый объект
            var obj = F.Get();

            // --- Тестирование собственного CSV сериализатора ---
            var watch = Stopwatch.StartNew();

            string csvResult = "";
            for (int i = 0; i < iterations; i++)
            {
                csvResult = CsvSerializer.Serialize(obj);
            }

            watch.Stop();
            long serializeTime = watch.ElapsedMilliseconds;

            Console.WriteLine("CSV строка: " + csvResult);

            watch.Restart();

            for (int i = 0; i < iterations; i++)
            {
                var deserialized = CsvSerializer.Deserialize<F>(csvResult);
            }

            watch.Stop();
            long deserializeTime = watch.ElapsedMilliseconds;

            // --- Тестирование Newtonsoft.Json ---
            watch.Restart();

            string jsonResult = "";
            for (int i = 0; i < iterations; i++)
            {
                jsonResult = JsonConvert.SerializeObject(obj);
            }

            watch.Stop();
            long jsonSerializeTime = watch.ElapsedMilliseconds;

            watch.Restart();

            for (int i = 0; i < iterations; i++)
            {
                var deserialized = JsonConvert.DeserializeObject<F>(jsonResult);
            }

            watch.Stop();
            long jsonDeserializeTime = watch.ElapsedMilliseconds;

            // --- Вывод результата ---
            Console.WriteLine();
            Console.WriteLine("РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ:");
            Console.WriteLine("Сериализуемый класс: class F { int i1, i2, i3, i4, i5; }");
            Console.WriteLine($"Количество итераций: {iterations}");
            Console.WriteLine("Код сериализации-десериализации: Рефлексия через GetProperties/GetFields");
            Console.WriteLine();
            Console.WriteLine("МОЙ РЕФЛЕКСИОННЫЙ CSV:");
            Console.WriteLine($"Время на сериализацию = {serializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {deserializeTime} мс");
            Console.WriteLine();
            Console.WriteLine("STANDARDНЫЙ МЕХАНИЗМ (Newtonsoft.Json):");
            Console.WriteLine($"Время на сериализацию = {jsonSerializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {jsonDeserializeTime} мс");
        }
    }
}
