using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp.Repository.Services
{
    public interface ICategoryService : IBaseService<Category>, ISelectionable
    {

    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IBaseRepository<Category> repo) : base(repo)
        {

        }

        public int Select()
        {
            Console.Clear();
            Console.WriteLine("Seleccine una categoria");
            return Select(() =>
            {
                var list = Get();
                Console.Clear();
                foreach (var element in list)
                {
                    Console.WriteLine($"{element.Id}- {element.Name}");
                }
            });
        }

      
    }
}
