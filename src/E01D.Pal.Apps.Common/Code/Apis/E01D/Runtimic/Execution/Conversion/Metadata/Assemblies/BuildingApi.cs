using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public void Build(ILConversion conversion)
	    {
		    var assemblies = conversion.MetadataModel.Assemblies.ById.Values.ToList();

			for (int i = 0; i < assemblies.Count; i++)
			{
				var assemblyNode = assemblies[i];

				assemblyNode.ConvertedAssembly = Assemblies.Creation.CreateConvertedAssembly(conversion, assemblyNode.FullName, assemblyNode);

            }
		}

	  //  private ConvertedAssembly Build(ILConversion conversion, ConvertedAssemblyNode assemblyNode)
	  //  {
		 //   //var assemblyDefinition = ;

		 //   //assemblyNode.Guid = Guid.NewGuid();

			////var name = Assemblies.Naming.GetAssemblyName(conversion, assemblyNode.Name.FullName, assemblyNode.Guid);

		 //   var convertedAssembly 

		    

   //         //   assemblyNode.Semantic = convertedAssembly;

   //         //   for (int i = 0; i < assemblyNode.ModuleNodes.Count; i++)
   //         //   {
   //         //    var moduleNode = assemblyNode.ModuleNodes[i];

   //         //    var convertedModule = Modules.Building.BuildOut(conversion, moduleNode);

   //         //    convertedAssembly.Modules.Add(convertedModule.Name, convertedModule);
   //         //}

   //         //return convertedAssembly;

   //         throw new Exception("not fixed yet");

	  //  }

	    //public SemanticAssemblyMask_I BuildOut(ILConversion conversion, AssemblyNameReference nameReference)
		//{
		//    var assemblyEntry = Assemblies.Ensure(conversion, nameReference);

		//    BuildOut(conversion, assemblyEntry);

		//    return assemblyEntry;
		//}

		//public void BuildOut(ILConversion conversion, SemanticAssemblyMask_I semanticAssembly)
		//{
		//    if (semanticAssembly.IsBuiltOut)
		//    {
		//        return;
		//    }

		//    if (!semanticAssembly.IsConverted())
		//    {
		//        // Push it down stream
		//        Binding.Metadata.Assemblies.Building.BuildOut(conversion.Model, semanticAssembly);

		//        return;
		//    }

		//    if (!(semanticAssembly is ConvertedAssembly_I converted))
		//    {
		//        throw new System.Exception("Not Converted.");
		//    }

		//    converted.IsBuiltOut = true;

		//    // SHOULD NOT NEED
		//    //if (!conversion.Model.Assemblies.Definitions.TryGetValue(nameReference.FullName,
		//    //    out AssemblyDefinition existingDefinition))
		//    //{
		//    //    var boundAssembly = Binding.Metadata.Assemblies.Creation.CreateAssemblyEntry(conversion.Model, nameReference);

		//    //    existingDefinition = boundAssembly.AssemblyDefinition;
		//    //}

		//    var semanticModules = semanticAssembly.Modules.Values.ToList();

		//    for (int i = 0; i < semanticModules.Count; i++)
		//    {
		//        var module = semanticModules[i];

		//        Modules.Building.BuildOut(conversion, module);
		//    }
		//}

	}
}
