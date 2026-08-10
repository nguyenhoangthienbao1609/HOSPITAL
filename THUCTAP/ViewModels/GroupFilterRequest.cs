namespace THUCTAP.ViewModels
{
    public class GroupFilterRequest : PagingRequestBase
    {
        public string? groupName { get; set; }
        public string? groupCode { get; set; }
    }
}