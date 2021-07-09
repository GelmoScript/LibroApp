using LibroApp.Repository.Services.BookSearcherService;
using LibroApp.Repository.Services.BookSearcherService.Ordenator;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookOrdenatorService.Ordenator
{
	public class OrdenatorFactory
	{
		public IOrdenator SelectOrdenator(BookSearcherOption BookSearcherOption)
		{
			return BookSearcherOption switch
			{
				BookSearcherOption.AuthorName => new AuthorNameOrdenator(),
				BookSearcherOption.BookName => new BookNameOrdenator(),
				BookSearcherOption.PublishYear => new PublishYearOrdenator(),
				BookSearcherOption.EditorialCountry => new EditorialCountryOrdenator(),
				BookSearcherOption.EditorialName => new EditorialNameOrdenator(),
				_ => null
			};
		}
	}
}
