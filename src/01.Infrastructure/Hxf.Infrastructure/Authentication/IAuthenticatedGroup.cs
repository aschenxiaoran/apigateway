namespace Hxf.Infrastructure.Authentication {
    public interface IAuthenticatedGroup {
        long Id { get; }
        string DisplayName { get; }
        string Description { get; }
    }
}