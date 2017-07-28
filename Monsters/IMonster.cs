using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Počítání.Examples;

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

        void OnSuccess();

        void OnFail();

        /// <summary>
        /// Vraci 0, pokud se dany example nema vubec pouzit, jinak cislo 1-10.
        /// </summary>
        int GetExampleFrequencyByMonster(ExampleDef exampleDef);

        /// <summary>
        /// Muze modifikovat priklad dle potvory. Instance example je per-call.
        /// </summary>
        void UpdateExampleByMonster(IExample example); 
    }
}
