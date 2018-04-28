using System.Collections.Generic;

namespace Hxf.Infrastructure.Authentication {
    public class WebAuthenticatedIdentity : IAuthenticatedIdentity {
        public WebAuthenticatedIdentity(long userId, string email, string displayName, IList<IAuthenticatedGroup> rules, ICollection<string> permissions, string authenticationType = "SSO") {
            Name = displayName;
            Email = email;
            UserId = userId;
            AuthenticationType = authenticationType;

            Rules = rules;
            Permissions = permissions;

            IsAuthenticated = true;

        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public long UserId { get; private set; }
        public string Email { get; private set; }
        public IList<IAuthenticatedGroup> Rules { get; private set; }
        public bool HasPermissions(string permissionName) {
            return Permissions.Contains(permissionName);
        }

        public ICollection<string> Permissions { get; private set; }
    }
}