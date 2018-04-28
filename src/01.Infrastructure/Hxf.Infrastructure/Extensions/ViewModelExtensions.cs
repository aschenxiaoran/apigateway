using System.Collections.Generic;
using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Extensions
{
    public static class ViewModelExtensions
    {

        public static IList<TModel> AddDefaultChioceToList<TModel>(this IList<TModel> modelList)
            where TModel : class, IDropDownViewModel, new()
        {
            var resultList = new List<TModel>();
            resultList.Add(new TModel() { Id = 0, Name = "请选择" });
            if (modelList.IsValid())
            {
                resultList.AddRange(modelList);
            }
            modelList= resultList;
            return resultList;
        }
    }
}
