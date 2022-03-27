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
        public List<Newspaper> GetNewspapers()
        {
            List<Newspaper> newspapers = newspaperRepo.GetNewspapers();
            return newspapers;
        }

        public Newspaper GetNewspaperById(int id)
        {
            return newspaperRepo.GetNewspaperById(id); 
        }

        public void PostNewNewspaper(Newspaper newspaper)
        {
            newspaperRepo.PostNewNewspaper(newspaper);
        }

        public void PutNewTitle(int id, string value)
        {
            newspaperRepo.PutNewTitle(id, value);
        }

        public void DeleteNewspaper(int id)
        {
            newspaperRepo.DeleteNewspaper(id);
        }


    }
}
