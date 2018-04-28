namespace Hxf.Infrastructure.Paging {
    public class PagingInfo {
        public PagingInfo(int pageIndex, int? pageSize = null) {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int? PageSize { get; set; }
    }

}