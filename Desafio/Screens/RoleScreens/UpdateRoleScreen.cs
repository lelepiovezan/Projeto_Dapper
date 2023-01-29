using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.RoleScreens
{

    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Atualizando Perfis");
            Console.WriteLine();

            Console.WriteLine("Digite o Id do Perfil a ser atulizado");
            var id = Console.ReadLine();

            Console.WriteLine("Digite o nome do perfil");
            var name = Console.ReadLine();

            Console.WriteLine("Digite o nome do Slug");
            var slug = Console.ReadLine();

            Update(new Role
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });

        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine("Perfil Atualizado com Sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar um pefil");
                Console.WriteLine(ex.Message);
            }
        }


    }

}