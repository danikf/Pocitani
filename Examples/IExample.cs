using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples
{
    public interface IExample
    {
        bool IsEquation { get; } //TODO to je trochu prasarna, ale je to nejsnazsi na refaktoring :-)

        string Text { get; }

        int SuccessPrice { get; set; }

        int FailPrice { get; set; }

        void Init(Random random, int successPrice, int failPrice, int maxNumber1, int maxNumber2, string parameters);

        int Result { get; }
    }
}
