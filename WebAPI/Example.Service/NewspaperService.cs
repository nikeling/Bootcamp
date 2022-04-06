using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Repository;
using Example.Model;
using Example.Common;

namespace Example.Service
{
    public class NewspaperService : INewspaperService
    {
        private INewspaperRepository newspaperRepo;
        

        public NewspaperService(INewspaperRepository newspaperRepo)
        {
            this.newspaperRepo = newspaperRepo;

        }

        public async Task<List<Newspaper>> GetNewspapersAsync(Paging paging, Filtering filtering, Sorting sorting)
        {
            List<Newspaper> newspapers = await Task.Run(() => newspaperRepo.GetNewspapersAsync(paging, filtering, sorting));
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
