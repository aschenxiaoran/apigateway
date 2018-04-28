namespace Hxf.Infrastructure{
    public interface IStorageDetailRoot : ISaleAggregateRoot{

        string StorageKey { get; set; }

        /// <summary>
        ///商品Id
        /// </summary>
        int ProductId { get; set; }

        /// <summary>
        ///货品Id
        /// </summary>
        int GoodsId { get; set; }

        /// <summary>
        ///仓库Id
        /// </summary>
        int StorageId { get; set; }

        /// <summary>
        ///仓库编号
        /// </summary>
        string StorageCode { get; set; }

        /// <summary>
        ///库存
        /// </summary>
        decimal Quanlity { get; set; }

        /// <summary>
        ///期初数量
        /// </summary>
        decimal BeginCount { get; set; }

        /// <summary>
        ///商品单位Id
        /// </summary>
        int ProductUnitId { get; set; }

        /// <summary>
        ///单位名称
        /// </summary>
        string UnitName { get; set; }

        /// <summary>
        ///单位成本
        /// </summary>
        decimal UnitCost { get; set; }

        /// <summary>
        /// 成本总额
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        ///期初总额
        /// </summary>
        decimal? InitialTotalAmount { get; set; }

        /// <summary>
        ///库存下限报警数
        /// </summary>
        decimal? StorageLowerAlarmCount { get; set; }

        /// <summary>
        ///库存上限报警数
        /// </summary>
        decimal? StorageUpAlarmCount { get; set; }
    }
}