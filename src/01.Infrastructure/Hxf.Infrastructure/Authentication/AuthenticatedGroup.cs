namespace Hxf.Infrastructure.Authentication {
    public class AuthenticatedGroup : IAuthenticatedGroup {
        public AuthenticatedGroup(long id, string displayName, string description = null) {
            Id = id;
            DisplayName = displayName;

            Description = description;
        }

        public long Id { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
    }
}