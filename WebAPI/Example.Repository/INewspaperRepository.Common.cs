using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Common;
using Example.Model;

namespace Example.Repository
{
    public interface INewspaperRepository
    {
        Task <List<Newspaper>> GetNewspapersAsync(Paging paging, Filtering filtering, Sorting sorting);

        Task<Newspaper> GetNewspaperByIdAsync(int id);

        Task PostNewNewspaperAsync(Newspaper newspaper);

        Task PutNewTitleAsync(int id, string value);

        Task DeleteNewspaperAsync(int id);
    }
}
