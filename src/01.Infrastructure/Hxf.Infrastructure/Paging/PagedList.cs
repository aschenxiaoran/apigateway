using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Paging {
    public class PagedList<T> {
        private readonly List<T> _items;

        public PagedList(IEnumerable<T> items = null) {
            Paged = new Paged();
            _items = items != null ? new List<T>(items) : new List<T>();
        }

        public Paged Paged { get; set; }

        public IReadOnlyList<T> Items {
            get { return _items; }
        }

        public PagedList<TNew> Transform<TNew>(Func<T, TNew> transform) {
            var result = new PagedList<TNew>();
            result.Paged = Paged;

            foreach(var item in Items) {
                result._items.Add(transform(item));
            }

            return result;
        }
    }
}