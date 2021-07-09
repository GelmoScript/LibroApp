using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;
using LibroApp.Repository.Services.BookOrdenatorService.Ordenator;
using LibroApp.Repository.Services.BookSearcherService.Searcher;
using LibroApp.Repository.Services.BookSearcherService.Shower;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Repository.Services.BookSearcherService
{
	public class BookSearcherService
	{
		private readonly OrdenatorFactory _ordenatorFactory;
		private readonly SearcherFactory _searcherFactory;
		private readonly IShower _shower;
		private readonly IBookService _bookService;

		public BookSearcherService()
		{
			_ordenatorFactory = new OrdenatorFactory();
			_searcherFactory = new SearcherFactory();
			_shower = new Shower.Shower();

			var repo = new BaseRepository<Book>();
			_bookService = new BookService(repo);
		}

		public void SearchBook(BookSearcherOption searchOption, BookSearcherOption orderOption)
		{
			var searcher = _searcherFactory.SelectSearcher(searchOption);
			var ordernator = _ordenatorFactory.SelectOrdenator(orderOption);

			var books = _bookService.Get();
			books = searcher.Search(books);
			books = ordernator.Order(books);

			_shower.Show(books);
		}
	}
}
