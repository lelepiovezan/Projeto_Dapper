using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("");
            Console.WriteLine();

            List();
            Console.ReadKey();
            MenuRoleScreen.Load();

        }

        public static void List()
        {
            var repository = new Repository<Role>(Database.Connection);
            var roles = repository.Get();

            foreach (var item in roles)
            {
                Console.WriteLine($"{item.Name} - {item.Slug}");
            }
        }

    }

}