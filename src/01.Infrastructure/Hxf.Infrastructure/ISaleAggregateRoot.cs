namespace Hxf.Infrastructure{
    public interface ISaleAggregateRoot : IAggregateRoot,IPinYinRoot {
        /// <summary>
        ///Db±àºÅ
        /// </summary>
        string DbCode { get; set; }

        /// <summary>
        ///±¸×¢
        /// </summary>
        string Remark { get; set; }
    }

    public abstract class SaleAggregateRoot : AggregateRoot,ISaleAggregateRoot {
        public string DbCode { get; set; }

        public int SortIndex { get; set; }

        /// <summary>
        ///±¸×¢
        /// </summary>
        public string Remark { get; set; }
    }
}