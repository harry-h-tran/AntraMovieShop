namespace ApplicationCore.Model
{
    public class PagedResultSet<T> where T : class
    {
        public IEnumerable<T> results { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

    }
}
