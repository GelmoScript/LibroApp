using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService.Searcher
{
	public class SearcherFactory
	{
		public ISearcher SelectSearcher(BookSearcherOption BookSearcherOption)
		{
			return BookSearcherOption switch
			{
				BookSearcherOption.AuthorName => new AuthorNameSearcher(),
				BookSearcherOption.BookName => new BookNameSearcher(),
				BookSearcherOption.PublishYear => new PublishYearSearcher(),
				BookSearcherOption.EditorialCountry => new EditorialCountrySearcher(),
				BookSearcherOption.EditorialName => new EditorialNameSearcher(),
				_ => null
			};
		}

	}
}
