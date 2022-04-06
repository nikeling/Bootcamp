using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Common
{
    public class Filtering : IFiltering
    {
        public int IdOfNewspaper { get; set; }
        public string Title { get; set; }
        public string ArticleName { get; set; }
        public string CompanyName { get; set; }

    }
}
