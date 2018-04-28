namespace Hxf.Infrastructure{
    public interface ISaleAggregateRoot : IAggregateRoot,IPinYinRoot {
        /// <summary>
        ///Db���
        /// </summary>
        string DbCode { get; set; }

        /// <summary>
        ///��ע
        /// </summary>
        string Remark { get; set; }
    }

    public abstract class SaleAggregateRoot : AggregateRoot,ISaleAggregateRoot {
        public string DbCode { get; set; }

        public int SortIndex { get; set; }

        /// <summary>
        ///��ע
        /// </summary>
        public string Remark { get; set; }
    }
}