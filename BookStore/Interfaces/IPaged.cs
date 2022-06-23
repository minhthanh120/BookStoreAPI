namespace BookStore.Interfaces
{
    public class IPaged<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PageNum { get; set; }
        public List<T> Result { get; set; }
    }
}
