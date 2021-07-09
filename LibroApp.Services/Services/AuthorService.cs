using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;
using System;
using System.Threading.Tasks;

namespace LibroApp.Repository.Services
{
    public interface IAuthorService : IBaseService<Author>
    {
       
    }
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IBaseRepository<Author> repo) : base(repo)
        {

        }

        public override int Select()
        {
            Console.Clear();
            Console.WriteLine("Seleccine un autor");
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
