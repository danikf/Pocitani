using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples.Equation
{
    // 1 + 2 = X; X = ?
    public class ExampleNum1PlusNum2EqualsX : BaseExample
    {
        public override bool IsEquation => true;

        protected override void OnInit(Random random)
        {
            int number1 = random.Next(MaxNumber1) + 1;
            int number2 = random.Next(MaxNumber2) + 1;
            int x = number2 + number1;
            Result = x;
            Text = $"{number1} + {number2} = x";
        }
    }
}
