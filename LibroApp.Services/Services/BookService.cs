using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;
using System;
using System.Threading.Tasks;

namespace LibroApp.Repository.Services
{
    public interface IBookService : IBaseService<Book>
    {

    }
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IBaseRepository<Book> repo) : base(repo)
        {

        }
        public override int Select()
        {
            Console.Clear();
            Console.WriteLine("Seleccine un libro");
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
