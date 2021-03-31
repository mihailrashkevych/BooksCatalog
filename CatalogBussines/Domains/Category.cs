using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogBussines.Domains
{
    public class Category
    {
        CatalogData.Repository.Category repository;
        IMapper mapper;

        public Category(IConfiguration configuration)
        {
            this.repository = new CatalogData.Repository.Category(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CatalogData.Entities.Category, ViewModels.Category>();
                cfg.CreateMap<ViewModels.Category, CatalogData.Entities.Category>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Category> Get()
        {
            var categories = repository.Get();
            return categories.Select(category => mapper.Map<CatalogData.Entities.Category, ViewModels.Category>(category));
        }
        public ViewModels.Category GetById(int id)
        {
            var book = repository.GetById(id);
            return mapper.Map<CatalogData.Entities.Category, ViewModels.Category>(book); ;
        }

        public void Create(ViewModels.Category category)
        {
            var repoCategory = mapper.Map<ViewModels.Category, CatalogData.Entities.Category>(category);
            repository.Create(repoCategory);
            repository.Save();
            category.CategoryId = repoCategory.CategoryId;
        }

        public void Edit(ViewModels.Category category)
        {
            var repoCategory = mapper.Map<ViewModels.Category, CatalogData.Entities.Category>(category);
            repository.Edit(repoCategory);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
        }

    }
}
