using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hxf.Infrastructure.Paging{
    public  class SampleQueryDto : QueryDto {

        public SampleQueryDto() {
            EntityIdList=new List<int>();
        }
        public IList<int> EntityIdList { get; set; }
    }

    public static class SampleQueryDtoExtesions {
        public static Expression<Func<TEntity, bool>> GetExpression<TEntity>(this SampleQueryDto queryDto) where TEntity:IAggregateRoot{
            var productIdList = queryDto.EntityIdList;
            Expression<Func<TEntity, bool>> productExpression = m => m.Status == queryDto.MemId;
            return productExpression;
        }
    }
}