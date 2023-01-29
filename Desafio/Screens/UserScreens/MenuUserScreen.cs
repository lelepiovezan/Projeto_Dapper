namespace Desafio.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("Gestão de Usuários");
            Console.WriteLine("------------------");
            Console.WriteLine("Oque Deseja Fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Listar usuários");
            Console.WriteLine("2- Criar usuários");
            Console.WriteLine("3- Atualizar usuários");
            Console.WriteLine("4- Deletar usuários");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;


            }

        }
    }

}