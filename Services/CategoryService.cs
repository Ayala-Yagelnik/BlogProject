using Microsoft.AspNetCore.Mvc;
using Posts_project.Entities;

namespace Posts_project.Services
{
    public class CategoryService
    {

        static List<Category> _categories = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Category 3",
                Description = "Description of Category 3",
                ParentID = 2
            }
        };
        public List<Category> Get() => _categories;

        public Category GetById(int id) => _categories.FirstOrDefault(x => x.Id == id);

        public bool AddCategory(Category c)
        {
            _categories.Add(c);
            return true;
        }
        public bool Update(int id, Category c)
        {
            Category existingCategoryToUpdate = _categories.FirstOrDefault(x => x.Id == id);
            if (existingCategoryToUpdate != null)
            {
                existingCategoryToUpdate.Name = c.Name;
                existingCategoryToUpdate.ParentID = c.ParentID;
                existingCategoryToUpdate.Id = c.Id;
                existingCategoryToUpdate.Description = c.Description;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _categories.Remove(_categories.FirstOrDefault(x => x.Id == id));
        }
    }
}
