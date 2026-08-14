namespace THUCTAP.ViewModels
{
    public class FormFieldFilterRequest : PagingRequestBase
    {
        public string? label { get; set; }
        public string? fieldKey { get; set; }
        public string? entityName { get; set; }
        public string? type { get; set; } 
    }
}