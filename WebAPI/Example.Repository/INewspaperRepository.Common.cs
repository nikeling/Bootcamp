using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Repository
{
    public interface INewspaperRepository
    {
        Task <List<Newspaper>> GetNewspapersAsync();

        Task<Newspaper> GetNewspaperByIdAsync(int id);

        Task PostNewNewspaperAsync(Newspaper newspaper);

        Task PutNewTitleAsync(int id, string value);

        Task DeleteNewspaperAsync(int id);
    }
}
