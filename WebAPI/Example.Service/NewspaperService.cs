using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Repository;
using Example.Model;

namespace Example.Service
{
    public class NewspaperService : INewspaperService
    {
        NewspaperRepository newspaperRepo = new NewspaperRepository();

        public async Task<List<Newspaper>> GetNewspapersAsync()
        {
            List<Newspaper> newspapers = await Task.Run(() => newspaperRepo.GetNewspapersAsync());
            return newspapers;
        }

        public async Task<Newspaper> GetNewspaperByIdAsync(int id)
        {
            return await Task.Run(() => newspaperRepo.GetNewspaperByIdAsync(id));
        }

        public async Task PostNewNewspaperAsync(Newspaper newspaper)
        {
            await Task.Run(() => newspaperRepo.PostNewNewspaperAsync(newspaper));
            
        }

        public async Task PutNewTitleAsync(int id, string value)
        {
            await Task.Run(() => newspaperRepo.PutNewTitleAsync(id, value));
            
        }

        public async Task DeleteNewspaperAsync(int id)
        {
            await Task.Run(() => newspaperRepo.DeleteNewspaperAsync(id));
            
        }

        
    }
}
