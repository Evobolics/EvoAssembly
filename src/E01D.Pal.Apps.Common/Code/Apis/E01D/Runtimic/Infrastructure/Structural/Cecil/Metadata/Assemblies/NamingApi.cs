using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class NamingApi<TContainer> : CecilApiNode<TContainer>, NamingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public string GetAssemblyName(Assembly assembly)
		{
			return assembly.FullName;
		}

		public string GetAssemblyName(AssemblyDefinition assemblyDefinition)
		{
			return assemblyDefinition.FullName;
		}

		public string GetAssemblyName(TypeReference typeReference)
		{
			if (typeReference.IsDefinition)
			{
				return ((TypeDefinition)typeReference).Module.Assembly.FullName;
			}

			return GetAssemblyName(typeReference.Scope);
		}

		public string GetAssemblyName(IMetadataScope scope)
		{
			if (scope is ModuleDefinition scopeModule)
			{
				return scopeModule.Assembly.FullName;
			}
			if (scope is AssemblyNameReference assemblyNameReference)
			{
				return assemblyNameReference.FullName;
			}
			else
			{
				throw new Exception($"Assembly ensure does not support scope '{scope.GetType().FullName}'");
			}
		}
	}
}
