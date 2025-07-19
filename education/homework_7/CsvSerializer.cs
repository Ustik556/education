using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_7
{
    public static class CsvSerializer
    {
        public static string Serialize<T>(T obj)
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var header = new List<string>();
            var values = new List<string>();

            foreach (var prop in properties)
            {
                header.Add(prop.Name);
                values.Add(prop.GetValue(obj)?.ToString() ?? string.Empty);
            }

            foreach (var field in fields)
            {
                header.Add(field.Name);
                values.Add(field.GetValue(obj)?.ToString() ?? string.Empty);
            }

            return string.Join(",", values);
        }

        public static T Deserialize<T>(string csv) where T : new()
        {
            var values = csv.Split(',');
            var obj = new T();
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            int index = 0;

            foreach (var prop in properties)
            {
                if (index >= values.Length) break;
                var val = Convert.ChangeType(values[index], prop.PropertyType);
                prop.SetValue(obj, val);
                index++;
            }

            foreach (var field in fields)
            {
                if (index >= values.Length) break;
                var val = Convert.ChangeType(values[index], field.FieldType);
                field.SetValue(obj, val);
                index++;
            }

            return obj;
        }
    }
}
