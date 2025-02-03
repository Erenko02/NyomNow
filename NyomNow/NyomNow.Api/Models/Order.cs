namespace NyomNow.NyomNow.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RestaurantId { get; set; }
        public List<string> MenuItems { get; set; }
        public double TotalAmount { get; set; }
    }
}
