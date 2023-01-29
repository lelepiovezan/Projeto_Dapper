using Dapper.Contrib.Extensions;

namespace Blog.Models
{

    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slag { get; set; }

        public List<Post> Posts { get; set; }

    }


}