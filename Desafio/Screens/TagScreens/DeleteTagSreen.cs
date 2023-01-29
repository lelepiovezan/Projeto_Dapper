using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {

        public static void Load()
        {

            Console.Clear();
            Console.Write("Exluir Tags");
            Console.WriteLine("--------");

            Console.WriteLine("Qual o Id da Tag que deseja Excluir?");
            var id = Console.ReadLine();



            Delete(int.Parse(id));

            Console.ReadKey();
            MenutagScreen.Load();
        }


        public static void Delete(int id)
        {

            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);

                Console.WriteLine("Tag Excluida com sucesso!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi excluir a TAG");
                Console.WriteLine(ex.Message);
            }
        }

    }
}