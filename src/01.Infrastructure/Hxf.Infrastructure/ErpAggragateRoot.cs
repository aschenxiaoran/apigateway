using System;
using Hxf.Infrastructure.Entities;

namespace Hxf.Infrastructure {
    public abstract class ErpAggragateRoot : IErpAggragateRoot,IOperateRecord {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
        public DateTime ModifyTime { get; set; }
        public int MemId { get; set; }
        public int Status { get; set; }
        public int SortIndex { get; set; }

        public virtual void Init(ILoginUser loginUser) {

            Status = StatusConstants.Valid;

            CreateUserId = loginUser.UserId;
            CreateUserName = loginUser.Name;
            CreateTime = DateTime.Now;

            ModifyUserId = loginUser.UserId;
            ModifyUserName = loginUser.Name;
            ModifyTime = DateTime.Now;

            MemId = loginUser.MemId;
        }

        public virtual void Modify(ILoginUser loginUser){

            ModifyUserId = loginUser.UserId;
            ModifyUserName = loginUser.Name;
            ModifyTime = DateTime.Now;

            MemId = loginUser.MemId;

        }
    }

    public interface IErpAggragateRoot : IEntity {

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