namespace ProductWebApi
{
    public class ProductCreateDto
    {
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
        public int OnStorage { get; set; }
        public string Description { get; set; }
    }
}

