using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp.Model.Extensions
{
	public static class StringExtensions
	{
		public static int ToInt(this string @string)
		{
			return Convert.ToInt32(@string);
		}

		public static double ToDouble(this string @string)
		{
			return Convert.ToDouble(@string);
		}
	}
}
