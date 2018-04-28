using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Paging {
    public abstract class ViewModel : IViewModel {
        protected ViewModel() {
            Pagination = new DefaultPagination();
        }

        public Pagination Pagination { get; set; }
        public object DataList { get; set; }
    }

    public abstract class ViewResponse : ViewModel {

    }

    public interface IViewModel { }

    public interface IDropDownViewModel : IViewModel {

        /// <summary>
        /// 主键
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        string Code { get; set; }
    }

    public interface IViewResponse : IViewModel { }

}