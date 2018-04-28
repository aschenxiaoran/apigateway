using System;
using System.Collections.Generic;
using System.Linq;

namespace Hxf.Infrastructure.Extensions {
    public static class ListExtension {
        public static List<List<T>> Split<T>(this IList<T> source, int childListSize) {
            var splitedList = new List<List<T>>();

            if (source != null && source.Any()) {
                int totalPageNum = (source.Count + childListSize - 1) / childListSize;
                for (int curPage = 1; curPage <= totalPageNum; curPage++) {
                    splitedList.Add(source.Skip((curPage - 1) * childListSize).Take(childListSize).ToList());
                }
            }

            return splitedList;
        }

        public static IList<int?> ToNullList(this IList<int> sourceList)
        {
            if (sourceList.IsInValid())
            {
                return new List<int?>();
            }
            var resultList=new List<int?>();
            foreach (var source in sourceList)
            {
                resultList.Add(source);
            }
            return resultList;
        }

        public static bool IsValid<T>(this IList<T> source) {
            return source != null && source.Count > 0;
        }
        public static bool IsInValid<T>(this IEnumerable<T> source) {
            return source == null || !source.Any();
        }

        public static T Random<T>(this IList<T> sourceList) where T:class 
        {
            if (sourceList == null || sourceList.Count==0) {
                return default(T);
            }
            if (sourceList.Count == 1)
            {
                return sourceList[0];
            }
            var listCount = sourceList.Count;
            var random=new Random();
            return sourceList[random.Next(listCount-1)];
        }
    }
}
