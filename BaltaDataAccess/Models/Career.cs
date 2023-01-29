namespace BaltaDataAccess.Models
{


    public class Career
    {

        public Career()
        {
            Items = new List<CareerItem>();
        }
        public Guid Id { get; set; }

        public String? Title { get; set; }

        public List<CareerItem> Items { get; set; }

    }
}