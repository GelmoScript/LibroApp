using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp
{
    public class Menu
    {
        public string DisplayOptions()
        {
        Reload:

            Console.Clear();
            Console.WriteLine("--- Menu Principal ---");
            Console.WriteLine("");
            Console.WriteLine("1- Mantenimiento de Categorias");
            Console.WriteLine("2- Mantenimiento de Autores");
            Console.WriteLine("3- Mantenimiento de Editoriales");
            Console.WriteLine("4- Mantenimiento de Libros");
            Console.WriteLine("S- Salir");
            Console.WriteLine("");

            string res = Console.ReadLine().ToUpper();

            switch (res)
            {
                case "1":
                    return Routes.CATEGORIES;
                case "2":
                    return Routes.AUTHORS;
                case "3":
                    return Routes.EDITORIALS;
                case "4":
                    return Routes.BOOKS;
                case "S":
                    return Routes.EXIT;
                default:
                    goto Reload;
            }
        }
    }
}
