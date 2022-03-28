using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Model
{
    internal interface INewspaper
    {
        int IdOfNewspaper { get; set; }
        string Title { get; set; }
         DateTime Date { get; set; }
        string ArticleName { get; set; }
         string CompanyName { get; set; }
    }
}
