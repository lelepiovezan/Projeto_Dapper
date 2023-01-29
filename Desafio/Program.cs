using Blog;
using Blog.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using Desafio.Screens.CategoryScreens;
using Desafio.Screens.RoleScreens;
using Desafio.Screens.UserScreens;
using Microsoft.Data.SqlClient;

public class Program
{
    private const string CONNECTION_STRING = @"Server=LAPTOP-25EIIGT2\SQLEXPRESS;Database=blog;User ID=sa;Password=2915;Trusted_Connection=False; TrustServerCertificate=True;";

    static void Main(string[] args)
    {

        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();

        Load();


        Console.ReadKey();
        Database.Connection.Close();
    }

    private static void Load()
    {

        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("-----------------");
        Console.WriteLine("Oque deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1- Gestão de usuários");
        Console.WriteLine("2- Gestão de Perfil");
        Console.WriteLine("3- Gestão de categoria");
        Console.WriteLine("4- Gestão de Tag");
        Console.WriteLine("5- Vincular Perfil/Usuário");
        Console.WriteLine("6- Vincular Post/Tag");
        Console.WriteLine("7- Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                MenuUserScreen.Load();
                break;
            case 2:
                MenuRoleScreen.Load();
                break;
            case 3:
                MenuCategoryScreen.Load();
                break;
            case 4:
                MenutagScreen.Load();
                break;
            default: Load(); break;

        }

    }


}



