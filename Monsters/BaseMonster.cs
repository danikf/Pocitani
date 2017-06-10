using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Počítání.Monsters
{
    /// <summary>
    /// Zvire bez specialnich vlastnosti
    /// </summary>
    public class BaseMonster : IMonster
    {
        private string _id;
        private string _image;
        private string _image2;
        private string _name;
        private string _nameGenitive;
        private string _thumnail;
        private int _price;

        public string Id => _id;

        public string Image => _image;

        public string Image2 => _image2;

        public string Name => _name;

        public string NameGenitive => _nameGenitive;

        public string Thumbnail => _thumnail;

        public int Price => _price;

        public bool Bought { get; set; }

        public Button Button { get; set; }

        public void Setup(string id, string name, string nameGenitive, string image, string thumbnail, string image2, int price)
        {
            _id = id;
            _name = name;
            _nameGenitive = nameGenitive;
            _image = image;
            _thumnail = thumbnail;
            _image2 = image2;
            _price = price;
        }
    }
}
