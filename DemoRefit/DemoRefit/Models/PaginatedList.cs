namespace DemoRefit.Models
{
    public class PaginatedList<T>
    {
        public List<T> List { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

       
    }
}
