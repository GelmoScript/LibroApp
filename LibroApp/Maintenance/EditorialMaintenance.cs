using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using LibroApp.Model.Repositories;
using LibroApp.Repository.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibroApp.Maintenance
{
    public class EditorialMaintenance : IMaintenance
    {
        private readonly IEditorialService service;
        public EditorialMaintenance()
        {
            var repo = new BaseRepository<Editorial>();
            service = new EditorialService(repo);

        }
        public async Task DisplayOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Mantenimiento de editoriales ---");
            Console.WriteLine("");
            Console.WriteLine("1- Agregar editorial");
            Console.WriteLine("2- Editar editorial");
            Console.WriteLine("3- Eliminar editorial");
            Console.WriteLine("4- Listar editoriales");
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
            Console.Write("Nombre del editorial: ");
            string name = Console.ReadLine();

            Console.Write("Pais del editorial: ");
            string country = Console.ReadLine();

            Console.Write("Telefono del editorial: ");
            string phone = Console.ReadLine();

            var Editorial = new Editorial()
            {
                Name = name,
                Country = country,
                Phone = phone
            };

            await service.Add(Editorial);
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
            Console.Write("Seleccione el id de un editorial: ");
            string id = Console.ReadLine();

            Console.Write("Nuevo nombre del editorial: ");
            string name = Console.ReadLine();

            Console.Write("Nuevo pais del editorial: ");
            string country = Console.ReadLine();

            Console.Write("Nuevo telefono del editorial: ");
            string phone = Console.ReadLine();

            int editorialId = int.Parse(id);

            var Editorial = new Editorial()
            {
                Id = editorialId,
                Name = name,
                Country = country,
                Phone = phone
            };

            await service.Update(editorialId, Editorial);
        }


        private async Task Delete()
        {
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de un editorial: ");
            string id = Console.ReadLine();

            Console.Write("Esta seguro que desea eliminar? (S/N): ");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.S)
                await service.Delete(int.Parse(id));
        }
    }
}
