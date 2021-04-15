using System;

namespace Task_1_Library
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : System.Attribute
    {
        public string PropertyName { get; set; }

        public TrackingPropertyAttribute()
        { }

        public TrackingPropertyAttribute(string name)
        {
           PropertyName = name;
        }
    }
}
