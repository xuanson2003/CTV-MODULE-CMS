using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Models
{
    public class Paged<T>
    {
        public dynamic Items { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int SkipRows { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; } = 1;

        public Paged(int countItems, int currentPage, int pageSize)
        {
            TotalRows = pageSize >= countItems ? countItems : pageSize;
            TotalPages = CalculateTotalPages(TotalRows, pageSize);
            CurrentPage = currentPage;
            PageSize = pageSize;
            SkipRows = pageSize >= countItems ? 0 : (currentPage - 1) * pageSize;
        }
        private int CalculateTotalPages(int totalItems, int pageSize)
        {
            int totalPages = totalItems / pageSize;

            if (totalItems % pageSize != 0)
            {
                totalPages++;
            }
            return totalPages;
        }
    }
}
