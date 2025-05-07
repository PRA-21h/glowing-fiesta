namespace ProductWebApi
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public int OnStorage { get; set; }

        public string Description { get; set; }
    }
}
