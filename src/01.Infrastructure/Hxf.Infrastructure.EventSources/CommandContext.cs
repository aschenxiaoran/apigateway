using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Web.Security;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hxf.Infrastructure.EventSources {
    public sealed class CommandContext {

        public CommandContext() {
            CurrentUser = LoginUser.CreateEmpty();
        }
        public ILoginUser CurrentUser { get; set; }
        public ICommand Command { get; set; }
        //用于返回数据给jsonresponse
        public object DataList { get; set; }
    }
}