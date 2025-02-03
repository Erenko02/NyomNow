namespace NyomNow.NyomNow.Api.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
