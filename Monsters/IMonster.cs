using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Počítání.Monsters
{
    public interface IMonster
    {
        string Id { get; }

        string Name { get; } 

        string NameGenitive { get; }

        string Image { get; }

        string Thumbnail { get; }

        string Image2 { get; }

        int Price { get; }

        void Setup(string id, string name, string nameGenitive, string image, string thumbnail, string image2, int price);

        bool Bought { get; set; }

        Button Button { get; set; }
    }
}
