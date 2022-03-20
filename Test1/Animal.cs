using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public abstract class Animal : IAnimal
    { 
        public int Age { get; set; }
        public string Name { get; set; }
        public Taxonomy Taxonomy { get; set; }

        public virtual string GetTaxonomy()
        {
            return $"Taxonomy: {Taxonomy.Kingdom} {Taxonomy.Class} {Taxonomy.Species}";
        }


    }
}

