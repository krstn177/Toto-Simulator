using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toto_Simulator.Models
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int itemsCount, int pageIndex, int pageSize) 
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling((float)itemsCount / pageSize);

            this.AddRange(items);
        }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int itemsCount =  source.Count();
            List<T> items =  source.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            return new PaginatedList<T>(items, itemsCount, pageIndex, pageSize);
        }
    }
}
