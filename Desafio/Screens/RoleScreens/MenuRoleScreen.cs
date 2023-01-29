namespace Desafio.Screens.RoleScreens
{

    public static class MenuRoleScreen
    {

        public static void Load()
        {
            Console.Clear();
            Console.Write("Gestão de usuários");
            Console.WriteLine("-------------");

            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Lista Perfis");
            Console.WriteLine("2- Criar Perfis");
            Console.WriteLine("3- Atualizar Perfis:");
            Console.WriteLine("4- Deletar Perfil:");
            var res = short.Parse(Console.ReadLine()!);


            switch (res)
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                default: Load(); break;

            }


        }

    }
}