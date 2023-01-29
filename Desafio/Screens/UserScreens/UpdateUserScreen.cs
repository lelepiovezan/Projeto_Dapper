using Blog;
using Blog.Models;
using Blog.Repositories;

namespace Desafio.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.Write("Atualizando usuários");
            Console.WriteLine("--------------");

            Console.WriteLine("ID");
            var id = Console.ReadLine();

            Console.Write("Nome ");
            var name = Console.ReadLine();

            Console.Write("Email ");
            var email = Console.ReadLine();

            Console.Write("Senha");
            var passwordHash = Console.ReadLine();

            Console.Write("Bio");
            var bio = Console.ReadLine();

            Console.Write("Imagem ");
            var slug = Console.ReadLine();

            Console.WriteLine("Digite o caminho da imagem");
            var imagem = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id),
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Image = imagem,
                Bio = bio,
                Slug = slug
            }
            );
            Console.ReadKey();
            MenuUserScreen.Load();

        }


        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não Foi possível atualizar esse usuário");
                Console.WriteLine(ex.Message);
            }
        }


    }

}