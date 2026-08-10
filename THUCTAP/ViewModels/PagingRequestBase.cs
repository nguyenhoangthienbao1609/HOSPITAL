namespace THUCTAP.ViewModels
{
    public class PagingRequestBase
    {
        public int pageIndex { get; set; } = 1;

        // Mặc định 1 trang có tối đa 10 dòng
        public int pageSize { get; set; } = 10;
    }
}