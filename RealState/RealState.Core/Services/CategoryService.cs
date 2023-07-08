using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;

        public CategoryService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }
        public void AddNewCategory(Category category)
        {
            _realStateUnitOfWork.CategoryRepository.Add(category);
            _realStateUnitOfWork.Save();
        }

        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _realStateUnitOfWork.CategoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _realStateUnitOfWork.CategoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetCategorys(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.CategoryRepository.Get(

                out total,
                out totalFiltered,
                 x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public void Remove(int id)
        {
            _realStateUnitOfWork.CategoryRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }
    }
}
