namespace MVC_Demo_Guitars.Models
{
    public class Guitars
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        
    }
}
