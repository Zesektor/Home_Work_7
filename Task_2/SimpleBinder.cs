using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Task_2
{
    public class SimpleBinder
    {
        private static readonly SimpleBinder _sb;

        private SimpleBinder()
        {
        }

        static SimpleBinder()
        {
            _sb = new SimpleBinder();
        }

        const BindingFlags flags = BindingFlags.NonPublic |
                                   BindingFlags.Public |
                                   BindingFlags.Instance |
                                   BindingFlags.Static;

        public static SimpleBinder GetInstance() => _sb;

        private static Type[] _processedTypes =
        {
            typeof(int),
            typeof(double),
            typeof(string)
        }; 

        public object Bind(Type type, IDictionary<string, string> dictionary)
        {
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new ArgumentException("Type must have parameterless constructor!");
            }
            var caseInsensitiveDictionary = new Dictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase);

            var obj = Activator.CreateInstance(type);

            var properties = type.GetProperties(flags).Where(x => _processedTypes.Contains(x.PropertyType));
            var fields = type.GetFields(flags).Where(x => _processedTypes.Contains(x.FieldType));

            foreach (var property in properties)
            {
                if (caseInsensitiveDictionary.TryGetValue(property.Name, out var value))
                {
                    property.SetValue(obj,Convert.ChangeType(value, property.PropertyType, CultureInfo.InvariantCulture));
                }
            }

            foreach (var field in fields)
            {
                if (caseInsensitiveDictionary.TryGetValue(field.Name, out var value))
                {
                    field.SetValue(obj, Convert.ChangeType(value, field.FieldType, CultureInfo.InvariantCulture));
                }
            }

            return obj;
        }
    }
}