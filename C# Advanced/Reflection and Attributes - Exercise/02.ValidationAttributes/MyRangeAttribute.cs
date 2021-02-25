using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int min = 12;
        private int max = 90;

        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }

            int value = (int)obj;

            if (value < min || value > max)
            {
                return false;
            }

            return true;
        }
    }
}
