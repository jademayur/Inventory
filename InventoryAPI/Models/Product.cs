namespace InventoryAPI.Models
{
    public class Product
    {
        public int Id  { get; set; }
        public string ProductName { get; set; }
        public int GroupId { get; set; }
        public string ProjectImage { get; set; }
        public int  Price { get; set; }
        public int Stock { get; set; }

    }
}
