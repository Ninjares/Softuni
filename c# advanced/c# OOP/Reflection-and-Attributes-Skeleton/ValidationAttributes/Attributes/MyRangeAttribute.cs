using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRangeAttribute:MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        public MyRangeAttribute(int minValue = 12, int maxValue = 90)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int value = Convert.ToInt32(obj);

            return value >= minValue && value <= maxValue;
        }
    }
}
