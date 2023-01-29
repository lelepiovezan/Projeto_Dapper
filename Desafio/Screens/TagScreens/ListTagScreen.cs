using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Lista de Tags");
            Console.WriteLine("--------");
            List();
            Console.ReadKey();
            MenutagScreen.Load();


        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tag = repository.Get();
            foreach (var item in tag)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }


    }
}