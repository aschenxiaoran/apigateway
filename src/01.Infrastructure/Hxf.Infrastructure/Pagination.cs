using System;

namespace Hxf.Infrastructure {

    
	public class Pagination {

        
		public int PageIndex { get; protected set; }

		public int PageSize { get; protected set; }

		public int TotalCount { get; set; }

		public int FirstPageIndex {
			get {
				return 1;
			}
		}

		public int PageCount {
			get { return TotalCount / PageSize + (TotalCount % PageSize == 0 ? 0 : 1); }
		}

		public int SkipCount {
			get { return (PageIndex - 1) * PageSize; }
		}

		public Pagination(int pageIndex = 1, int pageSize = 10, int totalCount = 0) {
			PageIndex = pageIndex;
			PageSize = pageSize;
			TotalCount = totalCount;
		}

	}

	public class DefaultPagination : Pagination {
		public DefaultPagination()
			: base(PaginationValueConstant.PageIndex, PaginationValueConstant.PageSize) {

		}

		public DefaultPagination(int pageIndex, int pageSize, int totalCount = 0)
			: base(pageIndex, pageSize, totalCount) {
		}
	}

    public class DefaultMaxPagination : Pagination {
		public DefaultMaxPagination()
			: base(PaginationValueConstant.PageIndex, PaginationValueConstant.PageMaxSize) {

		}

		public DefaultMaxPagination(int pageIndex, int pageSize, int totalCount = 0)
			: base(pageIndex, pageSize, totalCount) {
		}
	}

	public class PaginationKeyConstant {

		public const string PageIndex = "Page";

		public const string PageSize = "pagesize";

	}

	public class PaginationValueConstant {
		public const int PageIndex = 1;

		public const int PageSize = 10;

	    public const int PageMaxSize = 100;

	    public const int MaxPageSize = Int32.MaxValue;
	}
}
