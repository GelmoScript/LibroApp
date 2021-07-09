using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Model.Entities
{
	public class Book : Base
	{
		public int PublishYear { get; set; }
		public int EditorialId { get; set; }
		public int AuthorId { get; set; }
		public int CategoryId { get; set; }
		public virtual Author Author { get; set; }
		public virtual Editorial Editorial { get; set; }
		public virtual Category Category { get; set; }
	}
}
