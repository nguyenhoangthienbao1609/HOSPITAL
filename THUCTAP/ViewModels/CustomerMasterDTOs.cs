namespace THUCTAP.ViewModels
{
    public class CustomerMasterFilterRequest : PagingRequestBase
    {
        public string? customerName { get; set; }
        public int? categoryId { get; set; }
    }

    public class CustomerMasterRequest
    {
        public string customerName { get; set; }
        public int categoryId { get; set; }
    }

    public class CustomerMasterResponseDto
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}