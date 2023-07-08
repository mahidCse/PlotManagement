using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Models.CategoryModels
{
    public class CategoryVM
    {
        private ICategoryService _categoryService;

        public CategoryVM()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }


        public object GetCategorys(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _categoryService.GetCategorys(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name
                        }
                    ).ToArray()

            };
        }

        public CategoryModel Load(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public IList<CategoryModel> FindAllCategory()
        {
            var customers = _categoryService.GetAllCategory();

            var customerList = new List<CategoryModel>();

            foreach (var category in customers)
            {
                customerList.Add(new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return customerList;
        }
    }
}
