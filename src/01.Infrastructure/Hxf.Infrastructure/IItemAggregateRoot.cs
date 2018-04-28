namespace Hxf.Infrastructure
{
    public interface IItemAggregateRoot:ISaleAggregateRoot
    {
        object GetKey();

        int GetParentId();

        void SetParentId(int parentId);
    }
}