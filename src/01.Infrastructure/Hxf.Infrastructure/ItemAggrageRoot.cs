namespace Hxf.Infrastructure
{
    public abstract class ItemAggrageRoot : SaleAggregateRoot, IItemAggregateRoot
    {
        public abstract object GetKey();

        public abstract int GetParentId();
        public abstract void SetParentId(int parentId);
    }
}