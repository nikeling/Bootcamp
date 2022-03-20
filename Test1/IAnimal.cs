using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public interface IAnimal
    {
        int Age { get; set; }
        string Name { get; set; }
        Taxonomy Taxonomy { get; set; }

        string GetTaxonomy();
    }

}
