using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtalk.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SpargelTracker.Core.Helpers
    {
        public class Pagination<T> where T : class
        {
            private IEnumerable<T> _items;
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int Count { get; set; }

            public Pagination(IEnumerable<T>? items, int pageIndex, int count, int pageSize = 5)
            {
                _items = items;
                PageIndex = pageIndex;
                PageSize = pageSize;
                Count = count;
            }

            public IEnumerable<T> Items
            {
                get
                {
                    if (PageIndex == -1)
                    {
                        return _items;
                    }
                    return _items.Skip((PageIndex - 1) * PageSize).Take(PageSize);
                }
                set
                {
                    _items = value;
                }
            }

            public int TotalPages
            {
                get
                {
                    return (int)Math.Ceiling(decimal.Divide(_items.Count(), PageSize));
                }
            }
        }
    }

}
