using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Ordenator
{
	public class EditorialCountryOrdenator : IOrdenator
	{
		public IEnumerable<Book> Order(IEnumerable<Book> list)
		{
			return list.OrderBy(x => x.Editorial.Country).ToList();
		}
	}
}
