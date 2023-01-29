using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Atualizando Perfis");
            Console.WriteLine();

            Console.WriteLine("Digite o Id do Perfil a ser Deletado");
            var id = Console.ReadLine();


            Delete(int.Parse(id));

        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Perfil Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao Deletar um pefil");
                Console.WriteLine(ex.Message);
            }
        }

    }

}