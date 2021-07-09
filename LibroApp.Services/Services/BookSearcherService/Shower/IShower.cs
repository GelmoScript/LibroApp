using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Shower
{
	interface IShower
	{
		public void Show(IEnumerable<Book> list);

		public string DisplayBook(Book book);
	}
}
