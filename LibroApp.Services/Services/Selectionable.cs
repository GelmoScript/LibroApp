using System;

namespace LibroApp.Repository.Services
{
	public interface ISelectionable
	{
		int Select(Action showAction);
	}

	public class Selectionable : ISelectionable
	{
		public int Select(Action showAction)
		{
			showAction.Invoke();
			int res = Convert.ToInt32(Console.ReadKey());
			return res;
		}
	}
}
