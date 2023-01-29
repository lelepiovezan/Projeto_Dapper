using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;

namespace Desafio.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.Write("Criando usuários");
            Console.WriteLine("--------------");

            Console.WriteLine("Digite o nome do usuário");
            var name = Console.ReadLine();

            Console.WriteLine("Digite o nome do usuário");
            var email = Console.ReadLine();

            Console.Write("Senha");
            var passwordHash = Console.ReadLine();

            Console.Write("Bio");
            var bio = Console.ReadLine();

            Console.Write("Imagem ");
            var slug = Console.ReadLine();

            Console.WriteLine("Digite o caminho da imagem");
            var imagem = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Image = imagem,
                Bio = bio,
                Slug = slug


            });

            Console.ReadKey();
            MenutagScreen.Load();

        }


        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário Cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o usuário");
                Console.WriteLine(ex.Message);
            }

        }
    }

}