using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var item in properties)
            {
                IEnumerable<MyValidationAttribute> customAttributes =
                    item.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in customAttributes)
                {
                    bool result = attribute.IsValid(item.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
