using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Assemblies
{
    public class StreamApi<TContainer> : BindingApiNode<TContainer>, StreamApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

		//public ILConversionResult Convert(ILConversion conversion, Stream[] streams)
		//{
		//	// Step 1: Add all of the assemblies that are dynamic to the model.  
		//	//         Any future assemblies added will not be dynamic and will come from static sources.
		//	Conversion.Assemblies.Creation.CreateDynamicAssemblies(conversion, streams);

		//	AddDynamicAssemblyReferences(conversion);

		//	List<BoundAssemblyMask_I> assemblyList = conversion.Model.Assemblies.ByResolutionName.Values.ToList();

		//	this.Sorting.Quick.Sort(assemblyList, (x, y) => x.Assemblies.Referenced.Count - y.Assemblies.Referenced.Count);

		//	conversion.Model.Assemblies.InDependencyOrder = assemblyList;

		//	foreach (var boundAssembly in assemblyList)
		//	{
		//		foreach (var module in boundAssembly.Modules.Values)
		//		{
		//			Conversion.Modules.DeclareAndDefine(module);
		//		}
		//	}

		//	List<AssemblyBuilder> builders = new List<AssemblyBuilder>();

		//	foreach (var assemblyEntry in assemblyList)
		//	{
		//		if (assemblyEntry.IsConverted() && (assemblyEntry is ConvertedAssembly convertedAssembly))
		//		{
		//			builders.Add(convertedAssembly.AssemblyBuilder);
		//		}
		//	}

		//	conversion.Result.Assemblies = builders;

		//	return conversion.Result;
		//}

		

  //      public void AddDynamicAssemblyReferences(ILConversion conversion)
  //      {
  //          var assemblies = conversion.Model.Assemblies.ByResolutionName.Values.ToList();

  //          foreach (var assemblyEntry in assemblies)
  //          {
  //              AddAssemblyReferences(conversion, assemblyEntry);
  //          }
  //      }

        

        

        

  //      public void AddAssemblyReferences(ILConversion conversion, BoundAssemblyMask_I assemblyEntry)
  //      {
  //          var semanticModel = conversion.Model;

  //          foreach (var moduleDefinition in assemblyEntry.AssemblyDefinition.Modules)
  //          {
  //              foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
  //              {
  //                  var fullAssemblyName = assemblyNameReference.FullName;

  //                  BoundAssemblyMask_I referencedEntry = null;

  //                  if (semanticModel.Assemblies.ByResolutionName.TryGetValue(fullAssemblyName, out BoundAssemblyMask_I referenceAssemblyEntry))
  //                  {
  //                      referencedEntry = referenceAssemblyEntry;
  //                  }
  //                  else
  //                  {
  //                      var loadedAssembly = this.Metadata.Assemblies.FindAssemblyInAppDomain(fullAssemblyName);

  //                      if (loadedAssembly != null && !loadedAssembly.IsDynamic)
  //                      {
  //                          referencedEntry = Conversion.Assemblies.Creation.CreateAssemblyEntry(conversion, loadedAssembly, false);

  //                          AddAssemblyReferences(conversion, referencedEntry);
  //                      }
  //                      else
  //                      {
  //                          throw new Exception("Assembly not resolved.  Need to add secondary resolving logic.");
  //                      }
  //                  }

  //                  assemblyEntry.Assemblies.Referenced.Add(referencedEntry.ResolutionName(), referencedEntry);

  //                  referencedEntry.Assemblies.Referencing.Add(assemblyEntry.ResolutionName(), assemblyEntry);
  //              }
  //          }
  //      }
    }
}
