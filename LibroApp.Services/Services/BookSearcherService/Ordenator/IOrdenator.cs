using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Ordenator
{
	public interface IOrdenator
	{
		public IEnumerable<Book> Order(IEnumerable<Book> list);
	}
}
