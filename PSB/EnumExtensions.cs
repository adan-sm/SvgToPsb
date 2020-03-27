using System;
using System.ComponentModel;
using System.Linq;

namespace Psb
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attribute = field
                                .GetCustomAttributes(false)
                                .OfType<DescriptionAttribute>()
                                .FirstOrDefault();

            return attribute?.Description ?? "No description";
        }
    }
}
