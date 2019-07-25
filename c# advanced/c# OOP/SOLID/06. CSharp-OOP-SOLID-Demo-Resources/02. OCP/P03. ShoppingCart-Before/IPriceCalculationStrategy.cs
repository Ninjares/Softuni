using P03._ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before
{
    interface IPriceCalculationStrategy
    {
        decimal Calculate(OrderItem item);

    }
}
