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
        public override void OnSuccess(ref int successPrice)
        {
            successPrice = successPrice + 1;

            base.OnSuccess(ref successPrice);
        }

        public override void OnFail(ref int failPrice)
        {
            failPrice = failPrice + 2;

            base.OnFail(ref failPrice);
        }
    }
}
