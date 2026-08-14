namespace THUCTAP.Models
{
    public class CustomerMaster : BaseModel
    {
       
        public string customerName { get; set; }

        public int categoryId { get; set; }
        public CustomerCategory Category { get; set; }

    }
}