namespace Hxf.Infrastructure.Extensions {
    public static class AssemblyExtension {
        //public static Assembly GetEntryAssembly() {
        //    var context = HttpContext.Current;
        //    if (context == null) {
        //        return Assembly.GetEntryAssembly();
        //    }

        //    var baseType = context.ApplicationInstance.GetType().BaseType;
        //    if (baseType == null) {
        //        return Assembly.GetExecutingAssembly();
        //    }

        //    return baseType.Assembly;
        //}

        //public static string GetCurrentDirectory() {
        //    var assembly = GetEntryAssembly();
        //    var localPath = new Uri(assembly.CodeBase).LocalPath;

        //    return Path.GetDirectoryName(localPath);
        //}
    }
}