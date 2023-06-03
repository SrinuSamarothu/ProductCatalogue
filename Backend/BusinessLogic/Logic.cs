using DataService;
using DataService.Entities;

namespace BusinessLogic
{
    public class Logic
    {

        private IRepo repo;
        public Logic(IRepo _repo)
        {
            repo = _repo;
        }

        public IEnumerable<Category> getCategories()
        {
            return repo.getAllCategories();
        }

        public Category? AddCategory(Category category)
        {
            try
            {
                return repo.AddCategory(category);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /*public Category UpdateCategory(Category category)
        {
            try
            {
                return repo.
            }
        }*/

    }
}