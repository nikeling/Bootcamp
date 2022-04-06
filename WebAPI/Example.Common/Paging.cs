using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Common
{
    public class Paging : IPaging
    {
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
    }
}
