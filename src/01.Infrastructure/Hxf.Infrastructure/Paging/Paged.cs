using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Paging {
    public class Paged {

        public static readonly int DefaultPageSize = 20;
        public const int FecthAllItems = -1;

        public Paged() {

        }

        public Paged(int totalCount, int pageIndex, int? pageSize = null) {
            Initialize(totalCount, pageIndex, pageSize);
        }

        public int PageCount { get; private set; }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public int LastPageIndex {
            get { return PageCount - 1; }
        }

        public int PreviousPageIndex {
            get {
                if(IsPreviousPageAvailable) {
                    return PageIndex - 1;
                }
                return -1;
            }
        }

        public int NextPageIndex {
            get {
                if(IsNextPageAvailable) {
                    return PageIndex + 1;
                }
                return -1;
            }
        }

        public bool IsFirstPage {
            get { return PageIndex == 0; }
        }

        public bool IsLastPage {
            get { return PageIndex == LastPageIndex; }
        }

        public bool IsMiddlePage {
            get { return !IsFirstPage && !IsLastPage; }
        }

        public bool IsNextPageAvailable {
            get { return PageIndex + 1 <= LastPageIndex; }
        }

        public bool IsPreviousPageAvailable {
            get { return PageIndex - 1 >= 0; }
        }

        public int[] GetContiguousPageIndexs(int count = 3) {
            var lastIndex = LastPageIndex > PageIndex + count ? PageIndex + count : LastPageIndex;

            var pages = new List<int>();

            var firstIndex = PageIndex - count;
            for(var currentIndex = firstIndex; currentIndex <= lastIndex; currentIndex++) {
                if(currentIndex >= 0) {
                    pages.Add(currentIndex);
                }
            }

            return pages.ToArray();
        }

        public void Initialize(int totalCount, int pageIndex, int? pageSize = null) {
            if(pageIndex < 0) {
                pageIndex = 0;
            }

            if(pageSize == null || pageSize.Value < 1) {
                pageSize = DefaultPageSize;
            }

            var size = pageSize.Value;

            PageSize = size;
            PageIndex = pageIndex;
            TotalCount = totalCount;

            PageCount = (int) Math.Ceiling(totalCount/(decimal) size);
        }
    }
}