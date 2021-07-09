using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using LibroApp.Model.Repositories;
using LibroApp.Repository.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibroApp.Maintenance
{
    public class AuthorMaintenance : IMaintenance
    {
        private readonly IAuthorService service;
        public AuthorMaintenance()
        {
            var repo = new BaseRepository<Author>();
            service = new AuthorService(repo);
        }
        public async Task DisplayOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Mantenimiento de autores ---");
            Console.WriteLine("");
            Console.WriteLine("1- Agregar autor");
            Console.WriteLine("2- Editar autor");
            Console.WriteLine("3- Eliminar autor");
            Console.WriteLine("4- Listar autores");
            Console.WriteLine("5- Volver atras");
            Console.WriteLine("");

            string res = Console.ReadLine();

            switch (res)
            {
                case "1":
                    await Add();
                    goto Reload;
                case "2":
                    await Edit();
                    goto Reload;
                case "3":
                    await Delete();
                    goto Reload;
                case "4":
                    List();
                    break;
                case "5":
                    return;
                default:
                    goto Reload;
            }
        }

        private async Task Add()
        {
            Console.Write("Nombre del autor: ");
            string name = Console.ReadLine();

            Console.Write("Correo del autor: ");
            string email = Console.ReadLine();

            var Author = new Author()
            {
                Name = name,
                Email = email
            };

            await service.Add(Author);
        }

        private void Show()
        {
            var list = service.Get().OrderNew();
            Console.Clear();
            foreach (var element in list)
            {
                Console.WriteLine($"{element.Id}- {element.Name}");
            }
        }

        private void List()
        {
            var list = service.GetAsParallel().OrderByAlphabet();
            Console.Clear();
            foreach (var element in list)
            {
                Console.WriteLine($"{element.Name}");
            }
        }

        private async Task Edit()
        {
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de un autor: ");
            string id = Console.ReadLine();

            Console.Write("Nuevo nombre del autor: ");
            string name = Console.ReadLine();

            Console.Write("Nuevo correo del autor: ");
            string email = Console.ReadLine();

            int authorId = int.Parse(id);

            var Author = new Author()
            {
                Id = authorId,
                Name = name,
                Email = email
            };

            await service.Update(authorId, Author);
        }


        private async Task Delete()
        {
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de una autor: ");
            string id = Console.ReadLine();

            Console.Write("Esta seguro que desea eliminar? (S/N): ");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.S)
                await service.Delete(int.Parse(id));
        }

	}
}
