using AutoMapper;
namespace Hxf.Infrastructure.Extensions
{
	/// <summary>
	/// 自动映射扩展方法
	/// </summary>
	public static class AutoMapperExtension
	{
		// public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
		// {
		// 	CreateMap<TSource, TDestination>();
		// 	return Mapper.Map<TSource, TDestination>(source);
		// }

		//public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination,
		//	Expression<Func<TSource, object>> sourceMember,Action<ISourceMemberConfigurationExpression<TSource>> memberOptions) {

		//	Mapper.CreateMap<TSource, TDestination>().ForSourceMember(sourceMember, memberOptions);
		//	return Mapper.Map(source,destination);
		//}

  //      public static TDestination Map<TSource, TDestination, TSourceItem, TDestinationItem>(this TSource source)
  //      {
  //          Mapper.CreateMap<TSource, TDestination>();
  //          Mapper.CreateMap<TSourceItem, TDestinationItem>();
  //          return Mapper.Map<TSource, TDestination>(source);
  //      }

  //      public static TDestination Map<TSource, TDestination>(this TSource source) {
  //          Mapper.CreateMap<TSource, TDestination>();
  //          return Mapper.Map<TSource, TDestination>(source);
  //      }

  //      [Obsolete]
  //      public static IList<TDestination> MapToIList<TSource, TDestination>(this TSource[] sources) where TSource : class
		//{
		//	Mapper.CreateMap<TSource, TDestination>();
		//	return Mapper.Map<TSource[], IList<TDestination>>(sources);
		//}

  //      [Obsolete]
  //      public static List<TDestination> MapToList<TSource, TDestination>(this TSource[] sources) where TSource : class
		//{
		//	Mapper.CreateMap<TSource, TDestination>();
		//	return Mapper.Map<TSource[], List<TDestination>>(sources);
		//}

       

  //      public static TDestination[] MapToArray<TSource, TDestination>(this TSource[] sources) where TSource : class
		//{
		//	Mapper.CreateMap<TSource, TDestination>();
		//	return Mapper.Map<TSource[], TDestination[]>(sources);
		//}

		//public static ICollection<TDestination> MapToICollection<TSource, TDestination>(this TSource[] sources) where TSource : class
		//{
		//	Mapper.CreateMap<TSource, TDestination>();
		//	return Mapper.Map<TSource[], ICollection<TDestination>>(sources);
		//}

  //      public static IQueryable<TDestination> ToProject<TSource,TDestination>(this IQueryable source) {
  //          Mapper.CreateMap<TSource, TDestination>();
  //          return AutoMapper.QueryableExtensions.Extensions.ProjectTo<TDestination>(source, Mapper.Engine);
  //      }
    }
}
