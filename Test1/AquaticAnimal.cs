using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class AquaticAnimal : Animal
    {
        public string TypeOfWater { get; set; }
        public DateTime Date { get; set; }
        public List<Food> Food { get; set; }

        public override string GetTaxonomy()
        {
            return $"\nKingdom: {Taxonomy.Kingdom} \nClass: {Taxonomy.Class} \nSpecies: {Taxonomy.Species}";
        }

    }
}
