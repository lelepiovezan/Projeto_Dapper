using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Cadastro de Perfis");
            Console.WriteLine();

            Console.WriteLine("Digite o nome do perfil");
            var name = Console.ReadLine();

            Console.WriteLine("Digite o nome do Slug");
            var slug = Console.ReadLine();

            Create(new Role
            {
                Name = name,
                Slug = slug
            });
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Perfil Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar um pefil");
                Console.WriteLine(ex.Message);
            }

        }

    }

}