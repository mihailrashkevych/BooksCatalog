using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogData.Repository
{
    public class Category
    {
        CatalogContext context;

        public Category(IConfiguration configuration)
        {
            this.context = new CatalogContext(configuration);
        }
        public IEnumerable<Entities.Category> Get()
        {
            var categories = context.Categories.ToList();
            return categories;
        }

        public Entities.Category GetById(int id)
        {
            Entities.Category category = context.Categories.Find(id);
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public void Create(Entities.Category category)
        {
            context.Add(category);
        }

        public void Edit(Entities.Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Entities.Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                context.Categories.Remove(category);
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
