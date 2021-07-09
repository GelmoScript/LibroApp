using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using LibroApp.Model.Repositories;
using LibroApp.Repository.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibroApp.Maintenance
{
    public class CategoryMaintenance : IMaintenance
    {
        private ICategoryService service;
        public CategoryMaintenance()
        {
            var repo = new BaseRepository<Category>();
            service = new CategoryService(repo);
        }
        public async Task DisplayOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Mantenimiento de Categorias ---");
            Console.WriteLine("");
            Console.WriteLine("1- Agregar categoria");
            Console.WriteLine("2- Editar producto");
            Console.WriteLine("3- Eliminar categoria");
            Console.WriteLine("4- Listar Categorias");
            Console.WriteLine("5- Volver Atras");
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
                    Router.CurrentRoute = Routes.HOME;
                    return;
                default:
                    goto Reload;
            }
        }
    
        private async Task Add()
        {
            Console.Write("Nombre de la categoria: ");

            string name = Console.ReadLine();
            await service.Add(new Category
            {
                Name = name
            });
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
        private void ParallelList()
        {
            var list = service.Get();
            Console.Clear();
            Parallel.ForEach(list, element =>
            {
                Console.WriteLine($"{element.Id}- {element.Name}");
            });
            Console.ReadKey();
        }

        private async Task Edit()
        {
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de una categoria: ");
            string id = Console.ReadLine();

            Console.Write("Escriba el nuevo nombre de la categoria: ");
            string name = Console.ReadLine();

            var category = new Category()
            {
                Name = name
            };

            await service.Update(int.Parse(id), category);
        }


        private async Task Delete()
        {
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de una categoria: ");
            string id = Console.ReadLine();

            Console.Write("Esta seguro que desea eliminar? (S/N): ");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.S)
                await service.Delete(int.Parse(id));
        }
    }
}
