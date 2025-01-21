using System.Reflection;

namespace PaddleBilling.Core.Extensions;

public static class AssemblyExtensions
{
    public static string GetFlexibleSemVersion(this Assembly assembly)
    {
        return assembly == null
            ? null
            : assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+')[0];
    }
}