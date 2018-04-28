using System;

namespace Hxf.Infrastructure.Entities
{
	/// <summary>
	/// 集合根基类
	/// </summary>
	[Serializable]
	public abstract class AggregateRoot : Entity,IAggregateRoot
	{
	    public string Name { get; set; }
	    public string Code { get; set; }
	    public string PinYin { get; set; }
	    public string FirstWord { get; set; }
	    public int CreateUserId { get; set; }
	    public string CreateUserName { get; set; }
	    public DateTime CreateTime { get; set; }
	    public int ModifyUserId { get; set; }
	    public string ModifyUserName { get; set; }
	    public DateTime ModifyTime { get; set; }

	    public int CompanyId { get; set; }
	    public int Status { get; set; }
	}
}