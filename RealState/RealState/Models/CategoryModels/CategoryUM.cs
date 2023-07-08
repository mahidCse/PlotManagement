using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System.Collections.Generic;
using static Humanizer.In;

namespace RealState.Models.CategoryModels
{
    public class CategoryUM
    {

        private ICategoryService _customerService;

        public CategoryUM()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public void AddNewCategory(CategoryModel category)
        {
            _customerService.AddNewCategory(new Category
            {
                Name = category.Name
            });
        }

        public void UpdateCategory(CategoryModel category)
        {

            _customerService.EditCategory(new Category
            {
                Id = category.Id,
                Name = category.Name,
            });
        }


        public void DeleteCategory(int id)
        {
            _customerService.Remove(id);

        }
    }
}
