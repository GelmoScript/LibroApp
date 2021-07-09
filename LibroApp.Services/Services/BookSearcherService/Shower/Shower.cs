using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Shower
{
	public class Shower : IShower
	{
		public string DisplayBook(Book book)
		{
			return @$"
				Nombre del libro: {book.Name}
				Año de publicación: {book.PublishYear}
				País de origen: {book.Editorial.Country}
				Nombre del editorial: {book.Editorial.Name}
				Nombre del autor: {book.Author.Name}
			";
		}

		public void Show(IEnumerable<Book> list)
		{
			Console.Clear();
			if (!list.Any())
			{
				Console.WriteLine("");
				Console.WriteLine("No hay elementos");
				Console.WriteLine("");
				Console.ReadLine();
				return;
			}
			foreach (var element in list)
			{
				Console.WriteLine("");
				Console.WriteLine(DisplayBook(element));
				Console.WriteLine("");
			}
			Console.ReadKey();
		}
	}
}
