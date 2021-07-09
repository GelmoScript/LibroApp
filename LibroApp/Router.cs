using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace LibroApp
{
    public static class Router
    {
        public static string CurrentRoute;

        public static void Redirect(string route)
        {
            CurrentRoute = route;
            App.Instance.Run();
        }
    }
}
