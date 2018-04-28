using System.Collections.Generic;
using AutoMapper;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Extensions
{
    public static class BatchJsonResponseExtensions
    {
        public static BatchJsonResponse ToBatchAddResponse(this JsonResponse addResponse, List<int> entityIdList)
        {
            var batchAddResponse = new BatchJsonResponse();
            //Mapper.CreateMap<JsonResponse, BatchJsonResponse>();
            batchAddResponse = Mapper.Map(addResponse, batchAddResponse);
            batchAddResponse.EntityIdList = entityIdList;
            return batchAddResponse;
        }
    }
}
