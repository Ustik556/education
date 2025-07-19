using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр финального класса
            var originalObject = new FinalClass
            {
                Id = 1,
                Name = "Test Object",
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            Console.WriteLine("Original:");
            PrintDetails(originalObject);

            // Глубокая копия с использованием собственного интерфейса
            var deepCopiedObject = ((IMyCloneable<FinalClass>)originalObject).DeepCopy();
            Console.WriteLine("\nDeep Copied with IMyCloneable:");
            PrintDetails(deepCopiedObject);

            // Копируем объект через стандартный интерфейс ICloneable
            var clonedObject = (FinalClass)((ICloneable)originalObject).Clone();
            Console.WriteLine("\nCloned with ICloneable:");
            PrintDetails(clonedObject);
        }

        private static void PrintDetails(FinalClass obj)
        {
            Console.WriteLine($"Id: {obj.Id}, Name: {obj.Name}, Created At: {obj.CreatedAt}, Active: {obj.IsActive}");
        }
    }
}
