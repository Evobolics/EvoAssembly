using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class TypeApi<TContainer> : ConversionApiNode<TContainer>, TypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		/// <summary>
		/// Converts the specified types to a collectible assembly.  All dependent types should be included.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="inputTypes"></param>
		public ILConversionResult Convert(ILConversion conversion, TypeDefinition[] inputTypes)
		{
           

            // Assembly Creation Process Notes
            // -----
            // When creating assemblies based on a type list, do not create all the associated assemblies from the start as what assemblies that are going to be
            // needed is not known till base types, interfaces, nested types, parameters, custom attributes, code type usages are read.

            // Create the converted assembly.  This will contain the dynamic assembly.
			var convertedAssembly = Conversion.Metadata.Assemblies.Creation.CreateConvertedAssembly(conversion);

            // Add the entry.  This has to be called explictly as the creation process does not add.  Only an ensure process adds.
            Conversion.Metadata.Assemblies.Addition.AddAssemblyEntry(conversion, convertedAssembly);

            // Add all the conversion entires so that they refer to this assembly.  Any time a type needs to be created, from one of these assemblies,
            // it should be placed into the this convereted assembly.

            // Add TypeDefinitions / Type References
            // C:\Dev\e01d\EvolvingGit\src\E01D.Pal.Apps.Common\Code\Apis\E01D\Runtimic\Execution\Binding\ModelApi.cs - AddAssemblyDefinitionType
            AddAssemblyDefinitionAssociations(conversion, conversion.Configuration.ConvertedAssemblies, convertedAssembly);

		    AddReferencedAssembliesToModel(conversion.Model, convertedAssembly);

		    AddCorlibIfReferenced(conversion.Model, convertedAssembly);
            // Create mscorlib entry if it is referenced.		    

            //Modules.Ensuring.EnsureModuleEntries(convertedAssembly);

            var convertedModule = convertedAssembly.Modules.Values.SingleOrDefault() as ConvertedModule;

            // Make it available for future lookups.
            conversion.TypeSetModule = convertedModule ?? throw new Exception("Expected single converted module.");

			// Convert the input types.  Specify the convereted module that will be used to house the types.
			// Conver the input types to typeInfos.  This will make sure theres is a standard input format.
			for (int i = 0; i < inputTypes.Length; i++)
			{
				var inputType = inputTypes[i];

				//Types.Ensuring.Ensure(convertedModule.Conversion, convertedModule, inputType);
				throw new Exception("Not impelmented yet.");
			}

			return conversion.Result;
		}

        

        private void AddCorlibIfReferenced(ILConversionRuntimicModel conversionModel, ConvertedAssembly convertedAssembly)
        {
            var list = convertedAssembly.ReferencedAssemblyDefinitions.Values.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (Assemblies.Query.IsCorlib(item.Name))
                {
                    Bound.Metadata.Assemblies.Building.BuildOut(conversionModel, item);
                }
            }
        }

        private void AddReferencedAssembliesToModel(ILConversionRuntimicModel model, ConvertedAssembly convertedAssembly)
        {
            convertedAssembly.ReferencedAssemblyDefinitions = AddReferences(model, convertedAssembly.AssemblyDefinition, convertedAssembly);

            var associated = convertedAssembly.AssociatedAssemblyDefinitions.Values.ToList();

            for (int i = 0; i < associated.Count; i++)
            {
                AddReferences(model, associated[i], convertedAssembly);
            }
        }

        private Dictionary<string, AssemblyDefinition> AddReferences(ILConversionRuntimicModel conversionModel, AssemblyDefinition assemblyDefinition, ConvertedAssembly convertedAssembly)
        {
	        throw new Exception("Debug");

			//if (assemblyDefinition == null) return new Dictionary<string, AssemblyDefinition>();

			//Dictionary<string, AssemblyDefinition> consumed = convertedAssembly.ReferencedAssemblyDefinitions;

			//consumed.Add(assemblyDefinition.FullName, assemblyDefinition);

			//List<AssemblyDefinition> queue;

			//List<AssemblyDefinition> nextQueue = new List<AssemblyDefinition>();

			//nextQueue.Add(assemblyDefinition);

			//while (nextQueue.Count > 0)
			//{
			//    queue = nextQueue;

			//    nextQueue = new List<AssemblyDefinition>();

			//    for (int k = 0; k < queue.Count; k++)
			//    {
			//        assemblyDefinition = queue[k];

			//        for (int i = 0; i < assemblyDefinition.Modules.Count; i++)
			//        {
			//            var module = assemblyDefinition.Modules[i];

			//            for (int j = 0; j < module.AssemblyReferences.Count; j++)
			//            {
			//                var assemblyReference = module.AssemblyReferences[j];

			//                var fullName = assemblyReference.FullName;

			//                var referencedAssembly = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensuring.Ensure(conversionModel, fullName);

			//             Infrastructure.Models.Structural.AddAssemblyDefinition(conversionModel, referencedAssembly);

			//                if (consumed.ContainsKey(referencedAssembly.FullName)) continue;

			//                consumed.Add(referencedAssembly.FullName, referencedAssembly);

			//                queue.Add(referencedAssembly);
			//            }
			//        }
			//    }
			//}

			//return consumed;
		}

        public void AddAssemblyDefinitionAssociations(ILConversion conversion, Dictionary<string, Assembly> convertedAssemblies, ConvertedAssembly convertedAssembly)
        {
            foreach (var assembly in convertedAssemblies.Values)
            {
                var definition = Assemblies.Getting.GetAssemblyDefinition(conversion, assembly);

                Conversion.Metadata.Assemblies.Addition.AddAssociatedDefinition(conversion, convertedAssembly, definition);

                
            }
        }
    }
}
