using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples.Minus
{
    // 2 - 1 = ?
    public class ExampleNum1MinusNum2 : BaseExample
    {
        public override bool IsEquation => false;

        protected override void OnInit(Random random)
        {
            int number1 = random.Next(MaxNumber1) + 1;
            int number2 = random.Next(Math.Min(number1, MaxNumber2)) + 1;
            Result = number1 - number2;
            Text = $"{number1} - {number2} =";
        }
    }
}
