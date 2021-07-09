using System;

namespace LibroApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Router.CurrentRoute = Routes.HOME;
			App.Instance.Run();
			Console.ReadKey();
		}
	}
}
