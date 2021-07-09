using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;
using System;
using System.Threading.Tasks;

namespace LibroApp.Repository.Services
{
    public interface IEditorialService : IBaseService<Editorial>, ISelectionable
    {

    }
    public class EditorialService : BaseService<Editorial>, IEditorialService
    {
        public EditorialService(IBaseRepository<Editorial> repo) : base(repo)
        {

        }

        public int Select()
        {
            Console.Clear();
            Console.WriteLine("Seleccine un editorial");
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
