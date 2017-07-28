using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Počítání.Examples
{
    public class ExampleDef
    {
        private string _code;
        private string _name;
        private string _exampleClass;
        private int _frequency;
        private int _successPrice;
        private int _failPrice;
        private int _maxNumber1;
        private int _maxNumber2;
        string _parameters;

        public int Frequency => _frequency;

        public string Code => _code;

        public ExampleDef(string code, string name, string exampleClass, int frequency, int successPrice, int failPrice, int maxNumber1, int maxNumber2, string parameters)
        {
            _code = code;
            _name = name;
            _exampleClass = exampleClass;
            _frequency = Math.Min(10, Math.Max(0, frequency)); //0 .. 10
            _successPrice = successPrice;
            _failPrice = failPrice;
            _maxNumber1 = maxNumber1;
            _maxNumber2 = maxNumber2;
            _parameters = parameters;
        }

        internal IExample CreateExample(Random random)
        {
            Type exampleType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Single(type => type.Name == _exampleClass);
            var example = (IExample)Activator.CreateInstance(exampleType);
            example.Init(random, _successPrice, _failPrice, _maxNumber1, _maxNumber2, _parameters);

            return example;
        }
    }
}
