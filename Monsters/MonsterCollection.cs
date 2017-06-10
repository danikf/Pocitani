using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Počítání.Monsters
{
    public class MonsterCollection: IEnumerable<IMonster>
    {
        private readonly Dictionary<string, IMonster> _monsters = new Dictionary<string, IMonster>(StringComparer.OrdinalIgnoreCase); //<id, animal>
        public MonsterCollection(string animalConfigXmlFile)
        {
            Load(animalConfigXmlFile);
        }

        private void Load(string monsterConfigXmlFile)
        {
            var xDoc = new XmlDocument();
            xDoc.Load(monsterConfigXmlFile);

            foreach(XmlNode monsterNode in xDoc.DocumentElement.SelectNodes("add"))
            {
                Type animalType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Single(type => type.Name == monsterNode.Attributes["class"].Value);
                var monster = (IMonster)Activator.CreateInstance(animalType);

                var id = monsterNode.Attributes["id"].Value;
                var name = monsterNode.Attributes["name"].Value;
                var nameGenitive = monsterNode.Attributes["nameGenitive"].Value;
                var image = monsterNode.Attributes["image"].Value;
                var thumbnail = monsterNode.Attributes["thumbnail"].Value;
                var image2 = monsterNode.Attributes["image2"].Value;
                var price = int.Parse(monsterNode.Attributes["price"].Value);
                monster.Setup(id, name, nameGenitive, image, thumbnail, image2, price);

                _monsters.Add(id, monster);
            }
        }

        public IEnumerator<IMonster> GetEnumerator()
        {
            return _monsters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _monsters.Values.GetEnumerator();
        }

        public IMonster FindById(string id)
        {
            IMonster result;
            if (_monsters.TryGetValue(id, out result))
                return result;
            else
                return null;
        }
    }
}

