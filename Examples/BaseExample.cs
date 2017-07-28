using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples
{
    public abstract class BaseExample : IExample
    {
        public abstract bool IsEquation { get; }

        protected int MaxNumber1 { get; private set; }

        protected int MaxNumber2 { get; private set; }

        public string Parameters { get; private set; }

        public string Text { get; protected set; }

        public int SuccessPrice { get; set; }

        public int FailPrice { get; set; }

        public int Result { get; protected set; }


        public void Init(Random random, int successPrice, int failPrice, int maxNumber1, int maxNumber2, string parameters)
        {
            SuccessPrice = successPrice;
            FailPrice = failPrice;
            MaxNumber1 = maxNumber1;
            MaxNumber2 = maxNumber2;
            Parameters = parameters;

            OnInit(random);
        }

        protected abstract void OnInit(Random random);
    }
}
