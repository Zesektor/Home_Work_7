using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Task_1_Library
{
    public class Logger
    {
        private string _logFilename;

        public Logger(string logFileName)
        {
            _logFilename = logFileName;
        } 

        public void Track(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            var type = entity.GetType();

            if (type.GetCustomAttribute<TrackingEntityAttribute>() == null)
            {
                return;
            }

            var propertyValues = new Dictionary<string, object>();
            
            var properties = type.GetProperties(BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Instance);

            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute<TrackingPropertyAttribute>();
                if (attr == null)
                {
                     continue;
                }
                var assignedName = attr.PropertyName;
                if (string.IsNullOrEmpty(attr.PropertyName))
                {
                    assignedName = property.Name;
                }
                propertyValues.Add(assignedName, property.GetValue(entity));
            }

            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<TrackingPropertyAttribute>();
                if (attr == null)
                {
                    continue;
                }
                var assignedName = attr.PropertyName;
                if (string.IsNullOrEmpty(attr.PropertyName))
                {
                    assignedName = field.Name;
                }
                propertyValues.Add(assignedName, field.GetValue(entity));
            }

            var json = JsonSerializer.Serialize(propertyValues);
            File.WriteAllText(_logFilename, json);
        }
    }
}
