using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Searcher
{
	public class EditorialCountrySearcher : ISearcher
	{
		private string _value;
		public IEnumerable<Book> Search(IEnumerable<Book> list)
		{
			SelectValue();
			return list.Where(x => x.Editorial.Country == _value).ToList();
		}

		public void SelectValue()
		{
			Console.Write("Nombre del pais de la editorial a buscar: ");
			_value = Console.ReadLine();
		}
	}
}
