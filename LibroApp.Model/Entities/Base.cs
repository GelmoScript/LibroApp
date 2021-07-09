
using System;

namespace LibroApp.Model.Entities
{
    public class Base : IBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
		public DateTime? Created { get; set; }
		public string Name { get; set; }
	}
}
