using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Lista de usuários");
            Console.WriteLine("-------------");

            List();
            Console.ReadKey();
            MenuUserScreen.Load();

        }

        public static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get();

            foreach (var item in user)
            {
                Console.WriteLine($"{item.Name} - {item.Email}");
            }

        }
    }

}