using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.Write("Atualizando Tags");
            Console.WriteLine("--------");

            Console.WriteLine("Id");
            var id = Console.ReadLine();

            Console.Write("Nome ");
            var name = Console.ReadLine();

            Console.Write("Slug ");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenutagScreen.Load();
        }

        public static void Update(Tag tag)
        {

            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);

                Console.WriteLine("Tag Atualizada com sucesso!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a TAG");
                Console.WriteLine(ex.Message);
            }
        }


    }
}