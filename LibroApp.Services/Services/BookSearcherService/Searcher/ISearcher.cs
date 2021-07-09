using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Searcher
{
	public interface ISearcher
	{
		public void SelectValue();
		public IEnumerable<Book> Search(IEnumerable<Book> list);
	}
}
