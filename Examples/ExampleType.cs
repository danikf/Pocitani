using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples
{
    public enum ExampleType
    {
        /// <summary>2 + 3 =</summary>
        Num1PlusNum2,

        /// <summary>3 - 2 =</summary>
        Num1MinusNum2,

        /// <summary>2 + x = 4</summary>
        Num1PlusXEqualsNum2,

        /// <summary>x + 3 = 4</summary>
        XPlusNum1EqualsNum2,

        /// <summary>2 + 3 = x</summary>
        Num1PlusNum2EqualsX,

        /// <summary>2 . x = 6</summary>
        Num1MultipliedByXEqualsNum2,
    }
}
