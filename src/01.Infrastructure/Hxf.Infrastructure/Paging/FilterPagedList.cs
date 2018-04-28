using System.Collections.Generic;

namespace Hxf.Infrastructure.Paging {
	public class FilterPagedList<TItem, TFilter> : PagedList<TItem> {
		public FilterPagedList() {

		}

		public FilterPagedList(IEnumerable<TItem> items = null): base(items) {

		}

        public FilterPagedList(PagedList<TItem> list, TFilter filters = default(TFilter)): this(list.Items) {
			Paged.Initialize(list.Paged.TotalCount, list.Paged.PageIndex, list.Paged.PageSize);
            Filters = filters;
		}


		public TFilter Filters { get; private set; }
	}

	public static class FilterablePaginatedListExtensions {
		public static FilterPagedList<TItem, TFilter> ToFilterableList<TItem, TFilter>(this PagedList<TItem> pagedList, TFilter filter = default(TFilter)) {
			var result = new FilterPagedList<TItem, TFilter>(pagedList, filter);

			return result;
		} 



	}
}