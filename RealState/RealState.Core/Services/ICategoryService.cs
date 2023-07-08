using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface ICategoryService
    {
        void AddNewCategory(Category block);
        IEnumerable<Category> GetAllCategory();
        Category GetCategoryById(int id);
        void EditCategory(Category block);
        void Remove(int id);
        IEnumerable<Category> GetCategorys(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
    }
}