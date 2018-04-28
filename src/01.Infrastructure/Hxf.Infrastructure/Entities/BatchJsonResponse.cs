using System.Collections.Generic;
using Hxf.Infrastructure.Validation;

namespace Hxf.Infrastructure.Entities
{
    public class BatchJsonResponse: JsonResponse
    {
        public IList<int> EntityIdList { get; set; }
    }
}
