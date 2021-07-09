using LibroApp.Model.Entities;
using LibroApp.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Searcher
{
	public class PublishYearSearcher : ISearcher
	{
		private int _value;
		public IEnumerable<Book> Search(IEnumerable<Book> list)
		{
			SelectValue();
			return list.Where(x => x.PublishYear == _value).ToList();
		}

		public void SelectValue()
		{
			Console.Write("Año de publicación a buscar: ");
			_value = Console.ReadLine().ToInt();
		}
	}
}
