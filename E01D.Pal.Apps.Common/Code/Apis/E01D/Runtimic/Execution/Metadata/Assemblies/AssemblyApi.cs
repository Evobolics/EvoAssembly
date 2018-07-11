using System;
using System.Reflection;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies
{
    public class AssemblyApi<TContainer>: ExecutionApiNode<TContainer, AssemblyDomainApi>, AssemblyApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        [Task("Make it able to return a PAL assembly.")]
        [Task("Make app domain access a PAL method call.")]
        public Assembly FindAssemblyInAppDomain(string fullAssemblyName)
        {
            return Underlying.FindAssemblyInAppDomain(fullAssemblyName);
        }

        public Type GetTypeInAssembly(Assembly assembly, Type type)
        {
            return Underlying.GetTypeInAssembly(assembly, type);
        }

        public Type GetTypeInAssembly(Type[] types, string fullName)
        {
            return Underlying.GetTypeInAssembly(types, fullName);
        }
    }

   
}
