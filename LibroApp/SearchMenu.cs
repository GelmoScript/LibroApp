using LibroApp.Model.Extensions;
using LibroApp.Repository.Services.BookSearcherService;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp
{
	public class SearchMenu
	{
		public SearchMenu()
		{
		}
        public void Run()
		{
            BookSearcherOption searchOption = DisplaySearchOptions();
            BookSearcherOption orderOption = DisplayOrderOptions();
            var booksearcherService = new BookSearcherService();
            booksearcherService.SearchBook(searchOption, orderOption);
        }
        public BookSearcherOption DisplaySearchOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Buscar libro por: ---");
            Console.WriteLine("");
            Console.WriteLine("1- Nombre del libro");
            Console.WriteLine("2- El país del editorial");
            Console.WriteLine("3- Año de publicación del libro (desde - hasta )");
            Console.WriteLine("4- Nombre del autor");
            Console.WriteLine("5- Nombre del editorial");
            Console.WriteLine("");

            int res = Console.ReadLine().ToInt();

            switch (res)
            {
                case 1:
                    return BookSearcherOption.BookName;
                case 2:
                    return BookSearcherOption.AuthorName;
                case 3:
                    return BookSearcherOption.EditorialCountry;
                case 4:
                    return BookSearcherOption.EditorialName;
                case 5:
                    return BookSearcherOption.PublishYear;
                default:
                    goto Reload;
            }
        }

        public BookSearcherOption DisplayOrderOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Ordenar lista por: ---");
            Console.WriteLine("");
            Console.WriteLine("1- Nombre del libro (Alfabéticamente)");
            Console.WriteLine("2- El país del editorial (Alfabéticamente)");
            Console.WriteLine("3- Año de publicación del libro (desde el más reciente hasta el más antiguo)");
            Console.WriteLine("4- Nombre del autor (Alfabéticamente)");
            Console.WriteLine("5- Nombre del editorial (Alfabéticamente)");
            Console.WriteLine("");

            int res = Console.ReadLine().ToInt();

            switch (res)
            {
                case 1:
                    return BookSearcherOption.BookName;
                case 2:
                    return BookSearcherOption.AuthorName;
                case 3:
                    return BookSearcherOption.EditorialCountry;
                case 4:
                    return BookSearcherOption.EditorialName;
                case 5:
                    return BookSearcherOption.PublishYear;
                default:
                    goto Reload;
            }
        }
    }
}
