using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
    public class AssemblyApi<TContainer> : SemanticApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
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

	    

		/// <summary>
		/// // Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		public AssemblyDefinition Ensure(InfrastructureModelMask_I model, TypeReference typeReference)
	    {
		    return Ensure(model, typeReference.Scope);
	    }

	    public AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, Assembly assembly)
	    {
			string fullName = GetAssemblyName(assembly);

		    if (semanticModel.Structural.Assemblies.Definitions.TryGetValue(fullName, out AssemblyDefinition assemblyDefinition))
		    {
			    return assemblyDefinition;
		    }

		    return Ensure_Assembly(semanticModel, assembly);
	    }

	    
	    public AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, IMetadataScope scope)
		{
			string fullName = GetAssemblyName(scope);

			return Ensure(semanticModel, fullName);
		}

		public AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, string fullName)
		{
			if (semanticModel.Structural.Assemblies.Definitions.TryGetValue(fullName, out AssemblyDefinition assemblyDefinition))
			{
				return assemblyDefinition;
			}

			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			Assembly assembly = null;

			for (int i = 0; i < assemblies.Length; i++)
			{
				var currentAssembly = assemblies[i];

				if (currentAssembly.FullName == fullName)
				{
					assembly = currentAssembly;
				}
			}

			if (assembly == null)
			{
				try
				{
					// Attempt to load from GAC
					assembly = Assembly.Load(fullName);

					// an assembly was asked for that another assembly already provides.
					if (assembly.FullName != fullName)
					{
						return Ensure(semanticModel, assembly.FullName);
					}
				}
				catch (Exception)
				{


				}
			}

			if (assembly == null)
			{
				throw new NotSupportedException($"Could not resolve assembly reference '{fullName}'.");
			}

			return Ensure_Assembly(semanticModel, assembly);
		}

		public AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, Stream stream)
	    {
		    var assemblyDefinition = Create(semanticModel, stream);

		    string fullName = GetAssemblyName(assemblyDefinition);

		    if (semanticModel.Structural.Assemblies.Definitions.TryGetValue(fullName, out AssemblyDefinition existingAssemblyDefinition))
		    {
			    return existingAssemblyDefinition;
		    }

		    return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition);
	    }

		private AssemblyDefinition Ensure_Assembly(InfrastructureModelMask_I semanticModel, Assembly assembly)
	    {
		    var assemblyDefinition = Create(semanticModel, assembly);

		    return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition);
	    }

	    private AssemblyDefinition Ensure_AssemblyDefinition(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
	    {
		    semanticModel.Structural.Assemblies.Definitions.Add(assemblyDefinition.FullName, assemblyDefinition);

		    Infrastructure.Structural.Cecil.Metadata.Modules.Load(semanticModel, assemblyDefinition);

		    return assemblyDefinition;
	    }
		/// <summary>
		/// Creates an assembly definition from an assembly.  It reads all of its bytes and creates a stream, which is then read.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public AssemblyDefinition Create(InfrastructureModelMask_I semanticModel, Assembly assembly)
	    {
		    byte[] bytes = File.ReadAllBytes(assembly.Location);

		    MemoryStream stream = new MemoryStream(bytes);

		    semanticModel.Structural.Streams.Add(stream);

			


			return Create(semanticModel, stream);
	    }

		/// <summary>
		/// Creates an assembly definition from a stream.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="stream"></param>
		/// <returns></returns>
	    public AssemblyDefinition Create(InfrastructureModelMask_I semanticModel, Stream stream)
	    {
		    return AssemblyDefinition.ReadAssembly(stream);
	    }

		public void AddAssemblyReferences(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			foreach (var moduleDefinition in assemblyDefinition.Modules)
			{
				foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
				{
					var fullAssemblyName = assemblyNameReference.FullName;

					if (!semanticModel.Structural.Assemblies.Definitions.TryGetValue(fullAssemblyName, out AssemblyDefinition referenceAssemblyEntry))
					{ 
						var referencedAssemblyDefinition = Ensure(semanticModel, assemblyNameReference);

						AddAssemblyReferences(semanticModel, referencedAssemblyDefinition);
					}
				}
			}
		}

	}
}
