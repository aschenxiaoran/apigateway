// using System;
// using System.Runtime.CompilerServices;
// using System.Threading.Tasks;

// namespace Hxf.Infrastructure.Data {

// 	/// <summary>
// 	/// 工作单元
// 	/// </summary>
// 	public interface IUnitOfWork : IDisposable {

// 		//bool Committed { get; }

// 		void Commit([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
// 		Task CommitAsync([CallerMemberName] string memberName = "");

// 		void Rollback([CallerMemberName] string memberName = "");

// 	}
// }
