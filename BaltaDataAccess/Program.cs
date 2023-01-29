using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;


public class Program
{
    private static void Main(string[] args)
    {
        const string connectionString = @"Server=LAPTOP-25EIIGT2\SQLEXPRESS;Database=baltanewcourse;User ID=sa;Password=2915;Trusted_Connection=False; TrustServerCertificate=True;";


        //Otimizando o código abaixo usando o using dessa forma já é aberta(open) e fechada(close) a conexão.
        using (var connection = new SqlConnection(connectionString))
        {
            //ExecuteProcedure(connection);
            //DeleteCategory(connection);
            //UpdateCategory(connection);
            //CreateManyCategory(connection);
            //ListCategories(connection);
            //CreateCategory(connection);
            //ExecuteReadProcedure(connection);
            // ExecuteScalar(connection);
            //ReadView(connection);
            //OneToOne(connection);
            //OneToMany(connection);
            //QueryMultipe(connection);
            //SelectIn(connection);
            Like(connection, "api");

        }

        static void ListCategories(SqlConnection connection)

        {

            var categories = connection.Query<Category>("SELECT [ID],[Title] FROM Category");

            foreach (var item in categories)
            {

                Console.WriteLine($"{item.ID} - {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {

            //Alimentando as propriedades do objeto para fazer o insert
            var category = new Category();
            category.ID = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Sumary = "AWS Cloud";
            category.Featured = false;

            //SQL Injection 
            var insertSql = @"INSERT INTO 
                [Category] 
                VALUES(
                    @Id,
                    @Title
                    ,@Url
                    ,@Sumary
                    , @Order
                    , @Description
                    , @Featured)";

            var rows = connection.Execute(insertSql, new
            {

                category.ID,
                category.Title,
                category.Url,
                category.Sumary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} Linhas inseridas");

        }

        static void CreateManyCategory(SqlConnection connection)
        {

            //Alimentando as propriedades do objeto para fazer o insert
            var category = new Category();
            category.ID = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Sumary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.ID = Guid.NewGuid();
            category2.Title = "Nova categoria";
            category2.Url = "amazon";
            category2.Description = "Categoria Nova";
            category2.Order = 9;
            category2.Sumary = "New";
            category2.Featured = true;

            //SQL Injection 
            var insertSql = @"INSERT INTO 
                [Category] 
                VALUES(
                    @Id,
                    @Title
                    ,@Url
                    ,@Sumary
                    , @Order
                    , @Description
                    , @Featured)";

            var rows = connection.Execute(insertSql, new[]{
        new
        {
        category.ID,
        category.Title,
        category.Url,
        category.Sumary,
        category.Order,
        category.Description,
        category.Featured
        },
        new
         {
        category2.ID,
        category2.Title,
        category2.Url,
        category2.Sumary,
        category2.Order,
        category2.Description,
        category2.Featured
        }
    });

            Console.WriteLine($"{rows} Linhas inseridas");

        }

        static void UpdateCategory(SqlConnection connection)
        {

            var updateQuery = "UPDATE [category] SET [title]=@title WHERE [ID]=@id";

            var row = connection.Execute(updateQuery, new
            {
                id = new Guid("AF3407AA-11AE-4621-A2EF-2028B85507C4"),
                Title = "FrontEnd 2022"
            });

            Console.WriteLine($"{row} Linhas atualizadas");


        }

        static void DeleteCategory(SqlConnection connection)
        {

            var deleteQuery = "DELETE [category] WHERE [ID]=@id";

            var row = connection.Execute(deleteQuery, new
            {
                id = new Guid("B4C5AF73-7E02-4FF7-951C-F69EE1729CAC")
            });
        }

        static void ExecuteProcedure(SqlConnection connection)
        {

            var sqlProcedure = "spDeleteStudent";
            var pars = new { StudentId = "2128D39C-AFFA-4522-B28A-CB51423D0C77" };
            //Comando para executar uma Proc do banco. comando SQL, Parametros e o Type.
            var affecterows = connection.Execute(sqlProcedure,
                        pars,
                        commandType: System.Data.CommandType.StoredProcedure);

            Console.WriteLine($"{affecterows} - Afetadas");
        }

        //Lendo uma procedure que executa um select
        static void ExecuteReadProcedure(SqlConnection connection)
        {

            var sqlProcedure = "spCoursesByCategory";
            var pars = new { CategoryId = "09CE0B7B-CFCA-497B-92C0-3290AD9D5142" };
            //Comando para executar uma Proc do banco. comando SQL, Parametros e o Type.
            var courses = connection.Query(sqlProcedure,
                        pars,
                        commandType: System.Data.CommandType.StoredProcedure);

            foreach (var item in courses)
            {
                Console.WriteLine(item.Id);

            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {

            //Alimentando as propriedades do objeto para fazer o insert
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços AWS";
            category.Order = 8;
            category.Sumary = "AWS Cloud";
            category.Featured = false;

            //SQL Injection 
            var insertSql = @"INSERT INTO 
                [Category] 
                OUTPUT inserted.[Id]
                VALUES(
                   NewId(),
                    @Title
                    ,@Url
                    ,@Sumary
                    , @Order
                    , @Description
                    , @Featured)
                    ";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Sumary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"A Categoria Inserida foi: {id}");


        }


        static void ReadView(SqlConnection connection)
        {

            var sql = "SELECT * FROM vwcourses";

            var courses = connection.Query(sql);

            foreach (var item in courses)
            {

                Console.WriteLine($"{item.ID} - {item.Title}");
            }
        }


        static void OneToOne(SqlConnection connection)
        {

            var sql = @"
            SELECT
	            *
            FROM
	            CareerItem 
            INNER JOIN
	            Course on CareerItem.CourseId=Course.id";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) =>
                {
                    careerItem.Course = course;
                    return careerItem;
                }, splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} -  {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {

            var sql = @"select
                            Career.Id,
                            Career.Title,
                            CareerItem.CareerId,
                            CareerItem.Title
                        from 
	                        Career
                        inner join	
	                        CareerItem on CareerItem.CareerId=Career.id
                        order by 
	                        Career.title";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else
                    {
                        car.Items.Add(item);
                    }

                    return career;
                }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {career.Title}");
                }
            }
        }


        static void QueryMultipe(SqlConnection connection)
        {
            var query = "SELECT * FROM Category; SELECT * FROM Course";
            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine(item.Title);
                }
                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {

            var sql = @"select *
                            from career
                            where id
                             in @Id";

            var items = connection.Query<Career>(sql, new
            {
                Id = new[] {
                    "01AE8A85-B4E8-4194-A0F1-1C6190AF54CB",
                    "92D7E864-BEA5-4812-80CC-C2F4E94DB1AF"
                 }

            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }



        static void Like(SqlConnection connection, string term)
        {
            //var term = "api";
            var sql = @"select *
                            from Course
                            where [Title]
                             like @exp";

            var items = connection.Query<Course>(sql, new
            {
                exp = $"%{term}%"

            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}