using System.Collections.Generic;

namespace Hxf.Infrastructure.Authentication {
    public class BackendAuthenticatedIdentity : IAuthenticatedIdentity {
        public string Name { get { return "System"; } }

        public string AuthenticationType { get { return "BuiltIn"; } }
        public bool IsAuthenticated { get { return true; } }
        public long UserId { get { return 0; } }
        public string Email { get { return ""; } }
        public IList<IAuthenticatedGroup> Rules { get { return new IAuthenticatedGroup[] { new AuthenticatedGroup(0, "System") }; } }
        public bool HasPermissions(string permissionName) {
            return true;
        }

        public ICollection<string> Permissions { get { return new List<string>(); } }
    }
}