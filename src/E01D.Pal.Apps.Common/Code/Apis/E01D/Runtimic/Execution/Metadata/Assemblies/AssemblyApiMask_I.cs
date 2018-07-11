using System;
using System.Reflection;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies
{
    public interface AssemblyApiMask_I
    {
        Assembly FindAssemblyInAppDomain(string fullAssemblyName);

        Type GetTypeInAssembly(Assembly assembly, Type type);

        Type GetTypeInAssembly(Type[] types, string fullName);
    }
}
