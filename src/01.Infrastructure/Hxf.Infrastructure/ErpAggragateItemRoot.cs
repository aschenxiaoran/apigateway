using Hxf.Infrastructure.Entities;

namespace Hxf.Infrastructure
{

    /// <summary>
    /// ��ϸ�ۺϸ�
    /// </summary>
    public abstract class ErpAggragateItemRoot : IErpAggragateItemRoot
    {
        public int SortIndex { get; set; }
        public int MemId { get; set; }
        public int Status { get; set; }

        public virtual void Init(ILoginUser loginUser) {

            Status = StatusConstants.Valid;

           

            MemId = loginUser.MemId;
        }

        public virtual void Modify(ILoginUser loginUser) {
           
            MemId = loginUser.MemId;

        }

        public int Id { get; set; }
    }

    public interface IErpAggragateItemRoot : IEntity {
        /// <summary>
        /// �������
        /// </summary>
        int SortIndex { get; set; }


        /// <summary>
        /// ����˾Id
        /// </summary>
        int MemId { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        int Status { get; set; }

        void Init(ILoginUser loginUser);

        void Modify(ILoginUser loginUser);
    }
}