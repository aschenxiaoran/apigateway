using System.Collections.Generic;
using System.Security.Principal;

namespace Hxf.Infrastructure.Authentication {
    public interface IAuthenticatedIdentity : IIdentity {
        long UserId { get; }
        string Email { get; }
        IList<IAuthenticatedGroup> Rules { get; }

        bool HasPermissions(string permissionName);
        ICollection<string> Permissions { get; }
    }
}
