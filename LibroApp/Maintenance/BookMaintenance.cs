using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using LibroApp.Model.Repositories;
using LibroApp.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp.Maintenance
{
	class BookMaintenance : IMaintenance
    {
        private readonly IBookService service;
		private readonly ICategoryService categoryService;
		private readonly IEditorialService editorialService;
		private readonly IAuthorService authorService;

		public BookMaintenance()
        {
            var repo = new BaseRepository<Book>();
            service = new BookService(repo);

            var categoryRepo = new BaseRepository<Category>();
            categoryService = new CategoryService(categoryRepo);

            var editorialRepo = new BaseRepository<Editorial>();
            editorialService = new EditorialService(editorialRepo);

            var authorRepo = new BaseRepository<Author>();
            authorService = new AuthorService(authorRepo);
        }

        public async Task DisplayOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Mantenimiento de Libros ---");
            Console.WriteLine("");
            Console.WriteLine("1- Agregar libro");
            Console.WriteLine("2- Editar libro");
            Console.WriteLine("3- Eliminar libro");
            Console.WriteLine("4- Listar libros");
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
                    return;
                default:
                    goto Reload;
            }
        }

        private async Task Add()
        {
            if (!CheckDependencies())
            {
                Console.Write("No es posible agregar un libro." +
                    "Esto puede ser debido a no tener autores, editoriales o categorias agregados en el sistema.");
                return;
            }
            Console.Write("Nombre del libro: ");
            string name = Console.ReadLine();

            Console.Write("Fecha de publicación: ");
            int publishYear = Console.ReadLine().ToInt();

            int categoryId = categoryService.Select();
            int editorialId = editorialService.Select();
            int authorId = authorService.Select();

            var book = new Book()
            {
                Name = name,
                PublishYear = publishYear,
                CategoryId = categoryId,
                EditorialId = editorialId,
                AuthorId = authorId
            };

            await service.Add(book);
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
            if (!CheckDependencies())
            {
                Console.Write("No es posible editar un libro." +
                    "Esto puede ser debido a no tener autores, editoriales o categorias agregados en el sistema.");
                return;
            }
            Show();
            Console.WriteLine();
            Console.Write("Seleccione el id de un libro: ");
            int id = Console.ReadLine().ToInt();

            Console.Write("Nuevo nombre para el libro: ");
            string name = Console.ReadLine();

            Console.Write("Nueva fcha de publicación: ");
            int publishYear = Console.ReadLine().ToInt();

            int categoryId = SelectFrom(categoryService);
            int editorialId = SelectFrom(editorialService);
            int authorId = SelectFrom(authorService);

            var book = new Book()
            {
                Id = id,
                Name = name,
                PublishYear = publishYear,
                CategoryId = categoryId,
                EditorialId = editorialId,
                AuthorId = authorId
            };

            await service.Update(id, book);
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

        private bool CheckDependencies()
		{
            if (!categoryService.Get().Any()) return false;
            if (!editorialService.Get().Any()) return false;
            if (!authorService.Get().Any()) return false;
            return true;
        }

		private int SelectFrom(IBaseService<IBase> selectionable)
		{
            
			if (selectionable is null)
				return -1;

			return selectionable.Select();
		}
	}
}
