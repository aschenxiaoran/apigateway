using System;
using Hxf.Infrastructure;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Extensions;
using Hxf.Infrastructure.Utilities;

namespace Hx.CShop.Domain.Products
{
    public class Menu : AdminAggregateRoot {
        public string ModuleCode { get; set; }

        /// <summary>
        ///父类编号
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        ///层级
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        ///排序索引
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        ///权限值
        /// </summary>
        public long PermissionValue { get; set; }

        /// <summary>
        ///链接地址
        /// </summary>
        public string LinkUrl { get; set; }

       

        /// <summary>
        ///备注
        /// </summary>
        public string Remark { get; set; }
    }

    public abstract class AdminAggregateRoot : IAggregateRoot {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
        public DateTime ModifyTime { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }



        /// <summary>
        ///备注
        /// </summary>
        public string Remark { get; set; }

        public virtual void Create(ILoginUser loginUser, bool initCode = true) {
            CompanyId = loginUser.CompanyId;
            CreateUserId = loginUser.UserId;
            CreateUserName = loginUser.Name;
            CreateTime = DateTime.Now;
            Status = (int)1;
            Code = Code.IsNullOrWhiteSpace() && initCode ? CodeUtility.RanCode : Code;
            ModifyTime = DateTime.Now;
            ModifyUserId = loginUser.UserId;
            ModifyUserName = loginUser.Name;
        }
    }
}
