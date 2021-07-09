using LibroApp.Maintenance;
using System;

namespace LibroApp
{
    public class App
    {
        private readonly static App _instance = new App();
        private readonly Menu menu;
        private App()
        {
            menu = new Menu();
        }
        public static App Instance
        {
            get
            {
                return _instance;
            }
        }
        public void Run()
        {
        Run:
            IMaintenance maintenance = null;
            switch (Router.CurrentRoute)
            {
                case Routes.HOME:
                    string option = menu.DisplayOptions();
                    Router.CurrentRoute = option;
                    break;
                case Routes.EXIT:
                    Environment.Exit(0);
                    break;
                case Routes.CATEGORIES:
                    maintenance = new CategoryMaintenance();
                    break;
                case Routes.AUTHORS:
                    maintenance = new AuthorMaintenance();
                    break;
                case Routes.EDITORIALS:
                    maintenance = new EditorialMaintenance();
                    break;
                case Routes.BOOKS:
                    maintenance = new BookMaintenance();
                    break;
                case Routes.SEARCH:
                    var searchMenu = new SearchMenu();
                    searchMenu.Run();
                    goto Run;
                default:
                    Router.CurrentRoute = Routes.HOME;
                    break;
            }

            if (maintenance != null)
                maintenance.DisplayOptions().Wait();

            goto Run;
        }

    }
}
