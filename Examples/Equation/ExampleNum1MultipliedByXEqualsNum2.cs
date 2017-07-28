using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples.Equation
{
    // 3 * X = 10; X = ?
    public class ExampleNum1MultipliedByXEqualsNum2 : BaseExample
    {
        public override bool IsEquation => true;

        protected override void OnInit(Random random)
        {
            var possibleX = Parameters.Split(',').Select(p => int.Parse(p.Trim())).ToArray();//new int[] { 1, 2, 3, 10 };
            int number1 = random.Next(MaxNumber1) + 1;
            int index = random.Next(possibleX.Length);
            int x = possibleX[index];
            int number2 = number1 * x;
            Result = x;
            Text = $"{number1} . x = {number2}";
        }
    }
}
