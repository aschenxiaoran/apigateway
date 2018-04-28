using System.Collections.Generic;
using Hxf.Infrastructure.Constants;
using Hxf.Infrastructure.Paging;

namespace Hxf.Infrastructure.Utilities {

    public  class DropDownListUtility {

        public static IList<TDropDownModel> AddDefaultChioce<TDropDownModel>( IList<TDropDownModel> sourceList)
            where TDropDownModel : class, IDropDownViewModel, new() {
            var dropwDownList = new List<TDropDownModel> {
                new TDropDownModel {
                    Code = SelectItemConstants.EmptyName,
                    Name = SelectItemConstants.EmptyName,
                    Id = SelectItemConstants.EmptyId
                }
            };

            dropwDownList.AddRange(sourceList);
            return dropwDownList;
        }
    }
}
