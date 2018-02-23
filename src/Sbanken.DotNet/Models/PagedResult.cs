using System.Collections.Generic;

namespace Sbanken.DotNet.Models
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int AvailableItems { get; }

        public PagedResult(IReadOnlyList<T> items, int availableItems)
        {
            Items = items;
            AvailableItems = availableItems;
        }
    }
}