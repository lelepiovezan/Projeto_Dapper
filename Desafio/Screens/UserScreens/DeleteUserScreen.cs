using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Deletando usuários");
            Console.WriteLine("--------------");

            Console.WriteLine("Digite o Id do usuário que deseja Excluir?");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();

        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário Deletado com sucesso");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }

}