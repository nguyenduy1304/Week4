using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Contract.Constant
{
    public class PaginatedList<T>
    {
        public List<T> List { get; set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(int count, int pageIndex, int pageSize, List<T> list)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            List = list;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(count, pageIndex, pageSize, items);
        }
    }
}
