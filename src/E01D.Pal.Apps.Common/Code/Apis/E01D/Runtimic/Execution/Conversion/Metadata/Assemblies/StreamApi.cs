using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class StreamApi<TContainer> : ConversionApiNode<TContainer>, StreamApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

		public ILConversionResult Convert(ILConversion conversion, Stream[] streams)
		{
			// Step 1: Add all of the assemblies that are dynamic to the model.  
			//         Any future assemblies added will not be dynamic and will come from static sources.

			// TODO: MAKE SURE ALL THESE ASSEMBLIES ARE ADDED TO HTE CONVERTED LIST
			Conversion.Metadata.Assemblies.Ensuring.Ensure(conversion, streams);

			AddDynamicAssemblyReferences(conversion);

			List<SemanticAssemblyMask_I> assemblyList = conversion.Model.Semantic.Assemblies.ByResolutionName.Values.ToList();

			this.Sorting.Quick.Sort(assemblyList, (x, y) => x.Assemblies.Referenced.Count - y.Assemblies.Referenced.Count);

			conversion.Model.Semantic.Assemblies.InDependencyOrder = assemblyList;

			foreach (var boundAssembly in assemblyList)
			{
				foreach (var module in boundAssembly.Modules.Values)
				{
					Conversion.Metadata.Modules.DeclareAndDefine(module);
				}
			}

			List<AssemblyBuilder> builders = new List<AssemblyBuilder>();

			foreach (var assemblyEntry in assemblyList)
			{
				if (assemblyEntry.IsConverted() && (assemblyEntry is ConvertedAssembly convertedAssembly))
				{
					builders.Add(convertedAssembly.AssemblyBuilder);
				}
			}

			//conversion.Result.Assemblies = builders;

			return conversion.Result;
		}

		

        public void AddDynamicAssemblyReferences(ILConversion conversion)
        {
            var assemblies = conversion.Model.Semantic.Assemblies.ByResolutionName.Values.ToList();

            foreach (var assemblyEntry in assemblies)
            {
                AddAssemblyReferences(conversion, assemblyEntry);
            }
        }

        

        

        

        public void AddAssemblyReferences(ILConversion conversion, SemanticAssemblyMask_I assemblyEntry)
        {
            var semanticModel = conversion.Model;

            //foreach (var moduleDefinition in assemblyEntry.AssemblyDefinition.Modules)
            //{
            //    foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
            //    {
            //        var fullAssemblyName = assemblyNameReference.FullName;

            //        SemanticAssemblyMask_I referencedEntry = null;

            //        if (semanticModel.Semantic.Assemblies.ByResolutionName.TryGetValue(fullAssemblyName, out SemanticAssemblyMask_I referenceAssemblyEntry))
            //        {
            //            referencedEntry = referenceAssemblyEntry;
            //        }
            //        else
            //        {
            //            var loadedAssembly = this.Metadata.Assemblies.FindAssemblyInAppDomain(fullAssemblyName);

            //            if (loadedAssembly != null && !loadedAssembly.IsDynamic)
            //            {
            //                //referencedEntry = Conversion.Metadata.Assemblies.Creation.CreateAssemblyEntry(conversion, loadedAssembly);

            //                AddAssemblyReferences(conversion, referencedEntry);
            //            }
            //            else
            //            {
            //                throw new Exception("Assembly not resolved.  Need to add secondary resolving logic.");
            //            }
            //        }

            //        //assemblyEntry.Assemblies.Referenced.Add(referencedEntry.ResolutionName(), referencedEntry);

            //        //referencedEntry.Assemblies.Referencing.Add(assemblyEntry.ResolutionName(), assemblyEntry);
            //    }
            //}
        }
    }
}
