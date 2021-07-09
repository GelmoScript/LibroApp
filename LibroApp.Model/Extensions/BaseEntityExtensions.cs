using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibroApp.Model.Extensions
{
	public static class BaseEntityExtensions
	{
		public static List<IBase> OrderOld(this IEnumerable<IBase> list)
		{
			return list.OrderBy(e => e.Id).ToList();
		}

		public static List<IBase> OrderNew(this IEnumerable<IBase> list)
		{
			return list.OrderByDescending(e => e.Id).ToList();
		}

		public static List<IBase> OrderByAlphabet(this IEnumerable<IBase> list)
		{
			return list.OrderByDescending(e => e.Name).ToList();
		}

	}
}
