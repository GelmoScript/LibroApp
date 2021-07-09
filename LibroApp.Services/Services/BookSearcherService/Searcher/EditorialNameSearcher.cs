using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LibroApp.Repository.Services.BookSearcherService.Searcher
{
	public class EditorialNameSearcher : ISearcher
	{
		private string _value;
		public IEnumerable<Book> Search(IEnumerable<Book> list)
		{
			SelectValue();
			return list.Where(x => x.Name == _value).ToList();
		}
		public void SelectValue()
		{
			Console.Write("Nombre de la editorial a buscar: ");
			_value = Console.ReadLine();
		}
	}
}
