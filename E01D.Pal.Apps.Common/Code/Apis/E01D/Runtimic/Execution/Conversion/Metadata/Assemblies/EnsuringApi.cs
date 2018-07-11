using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class EnsuringApi<TContainer> : ConversionApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Ensure(ILConversion conversion, Stream[] streams)
		{
			foreach (var stream in streams)
			{
				Ensure(conversion, stream);
			}
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, Assembly assembly)
		{
			var assemblyDefiniton = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, assembly);

			var semanticAssembly = Ensure(conversion, assemblyDefiniton);

			if (semanticAssembly is ConvertedAssembly_I converted)
			{
				converted.Assembly = assembly;
			}
			if (semanticAssembly is BoundAssembly_I bound)
			{
				bound.Assembly = assembly;
			}

			return semanticAssembly;
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, Stream stream)
		{
			AssemblyDefinition assemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, stream);

			return Ensure(conversion, assemblyDefinition);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, IMetadataScope assemblyNameReference)
		{
			var assemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, assemblyNameReference);

			return Ensure(conversion, assemblyDefinition);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, string typeReferenceFullName)
		{
			var typeReference = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(conversion.Model, typeReferenceFullName);

			if (typeReference == null)
			{
				throw new Exception($"Could not locate a type in the model named '{typeReferenceFullName}'");
			}

			return Ensure(conversion, typeReference);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, TypeReference typeReference)
		{
			var assemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, typeReference);

			return Ensure(conversion, assemblyDefinition);
		}

		

		/// <summary>
		/// Creates a bound or converted assembly depending if isonvered is set to true.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyDefinition"></param>
		/// <returns></returns>
		public SemanticAssemblyMask_I Ensure(ILConversion conversion, AssemblyDefinition assemblyDefinition)
		{
			var name = Assemblies.Naming.GetAssemblyName(conversion, assemblyDefinition.Name.FullName);

			if (!Assemblies.IsConverted(conversion, name))
			{
				return Binding.Metadata.Assemblies.Ensuring.Ensure(conversion.Model, assemblyDefinition);
			}

			var convertedAssembly = Assemblies.Creation.CreateConvertedAssembly(conversion, name, assemblyDefinition);

			// Ensure all the module entries are added.
			Modules.Ensuring.EnsureModuleEntries(convertedAssembly);

			return convertedAssembly;
		}








		





		
	}
}
