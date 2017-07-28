using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples.Equation
{
    // X + 3 = 7; X = ?
    public class ExampleXPlusNum1EqualsNum2 : BaseExample
    {
        public override bool IsEquation => true;

        protected override void OnInit(Random random)
        {
            int number2 = random.Next(MaxNumber1 - 1) + 2;
            int number1 = random.Next(Math.Min(number2, MaxNumber1)) + 1;
            int x = number2 - number1;
            Result = x;
            Text = $"x + {number1} = {number2}";
        }
    }
}
