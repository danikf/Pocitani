using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Počítání.Examples;

namespace Počítání.Monsters
{
    /// <summary>
    /// Preferuje rovnice
    /// </summary>
    public class Tygrik : BaseMonster
    {
        public override int GetExampleFrequencyByMonster(ExampleDef exampleDef)
        {
            if (exampleDef.Code.Contains("XEquals") || exampleDef.Code.Contains("EqualsX") || exampleDef.Code.Contains("XPlus"))
                return 10;
            else
                return base.GetExampleFrequencyByMonster(exampleDef);
        }
    }
}
