using Počítání.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Monsters
{
    /// <summary>
    /// Pri uspechu dava o 1Kc vic, pri neuspechu odebira o 2Kc vic
    /// </summary>
    public class Dracek: BaseMonster
    {
        public override void  UpdateExampleByMonster(IExample example)
        {
            example.SuccessPrice = example.SuccessPrice + 1;
            example.FailPrice = example.FailPrice + 2;
        }
    }
}
