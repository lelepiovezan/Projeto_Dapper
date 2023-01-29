using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class Program
{
    private const string CONNECTION_STRING = @"Server=LAPTOP-25EIIGT2\SQLEXPRESS;Database=blog;User ID=sa;Password=2915;Trusted_Connection=False; TrustServerCertificate=True;";

    static void Main(string[] args)
    {

        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        ReadUsers(connection);
        //ReadRoles(connection);
        //ReadTags(connection);
        //ReadCategory(connection);
        //CreateUser(connection);
        //ReadUser(connection);
        //DeleteUser(connection);
        //UpdateUser(connection);

        connection.Close();
    }
    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var items = repository.ReadWithRole();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
            foreach (var role in item.Roles)
            {
                Console.WriteLine(role.Name);
            }
        }

    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.Get();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }

    }

    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var items = repository.Get();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }


    }

    public static void ReadCategory(SqlConnection connection)
    {
        var repository = new Repository<Category>(connection);
        var items = repository.Get();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }

    }

    public static void ReadUser(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.Get(1);


        Console.WriteLine(items.Name);
    }

    public static void CreateUser(SqlConnection connection)
    {
        var user = new User()
        {
            Name = "Teste",
            Email = "Teste",
            PasswordHash = "Hash",
            Bio = "Teste",
            Image = "Teste",
            Slug = "Teste"
        };

        var repository = new Repository<User>(connection);
        repository.Create(user);
        Console.WriteLine("Cadastro Realizado com sucesso");
    }

    public static void DeleteUser(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        repository.Delete(5);


        Console.WriteLine("Deleção Feita OK!!");
    }

    public static void UpdateUser(SqlConnection connection)
    {
        var user = new User()
        {
            Id = 1,
            Name = "André Baltieri",
            Email = "andre@email.com",
            PasswordHash = "HashTag",
            Bio = "8x MVP",
            Image = "https://",
            Slug = "andre-balta"

        };

        var repository = new Repository<User>(connection);
        repository.Update(user);
        Console.WriteLine("Dados Atualizados com sucesso");
    }


}



