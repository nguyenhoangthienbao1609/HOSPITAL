namespace THUCTAP.Models
{
    public class CustomerMaster
    {
        public int id { get; set; }
        public string customerName { get; set; }

        public int categoryId { get; set; }
        public CustomerCategory Category { get; set; }

    }
}