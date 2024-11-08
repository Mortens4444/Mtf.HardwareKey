using System;
using System.ComponentModel;
using System.Reflection;

namespace Mtf.HardwareKey.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetDescription(this object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var valueStr = value.ToString();
            var type = value.GetType();

            var fieldInfo = type.IsEnum
                ? type.GetField(valueStr)
                : type.GetField(valueStr, BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfo == null)
            {
                return valueStr;
            }

            var descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);
            return descriptionAttribute?.Description ?? valueStr;
        }
    }
}
