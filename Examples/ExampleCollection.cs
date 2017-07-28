using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Počítání.Examples
{
    public class ExampleCollection : IEnumerable<ExampleDef>
    {
        private readonly Dictionary<string, ExampleDef> _examples = new Dictionary<string, ExampleDef>(StringComparer.OrdinalIgnoreCase); //<id, exampleDef>

        public ExampleCollection(string exampleConfigXmlFile)
        {
            Load(exampleConfigXmlFile);
        }

        public IEnumerator<ExampleDef> GetEnumerator()
        {
            return _examples.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Load(string exampleConfigXmlFile)
        {
            var xDoc = new XmlDocument();
            xDoc.Load(exampleConfigXmlFile);

            foreach (XmlNode exampleNode in xDoc.DocumentElement.SelectNodes("add"))
            {
                Type exampleType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Single(type => type.Name == exampleNode.Attributes["class"].Value);
                //var example = (IExample)Activator.CreateInstance(exampleType);

                var code = exampleNode.Attributes["code"].Value;
                var name = exampleNode.Attributes["name"].Value;
                var frequency = int.Parse(exampleNode.Attributes["frequency"].Value);
                var exampleClass = exampleNode.Attributes["class"].Value;
                var successPrice = int.Parse(exampleNode.Attributes["successPrice"].Value);
                var failPrice = int.Parse(exampleNode.Attributes["failPrice"].Value);
                var maxNumber1 = int.Parse(exampleNode.Attributes["maxNumber1"].Value);
                var maxNumber2 = int.Parse(exampleNode.Attributes["maxNumber2"].Value);
                var parameters = exampleNode.Attributes["parameters"].Value;

                var exampleDef = new ExampleDef(code, name, exampleClass, frequency, successPrice, failPrice, maxNumber1, maxNumber2, parameters);

                _examples.Add(code, exampleDef);
            }
        }
    }
}
