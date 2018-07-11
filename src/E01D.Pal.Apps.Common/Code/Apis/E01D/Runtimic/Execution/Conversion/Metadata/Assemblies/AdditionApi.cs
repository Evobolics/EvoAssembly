using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class AdditionApi<TContainer> : ConversionApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public void AddAssemblyEntry(ILConversion conversion, SemanticAssemblyMask_I entry)
		{
			var semanticModel = conversion.Model;

			if (entry.IsConverted() && entry is ConvertedAssembly_I convertedAssembly)
			{
				semanticModel.Semantic.Assemblies.Collectible.Add(entry.ResolutionName(), convertedAssembly);

			    conversion.Result.Assemblies.Add(convertedAssembly.AssemblyBuilder);
            }

            Binding.Metadata.Assemblies.Addition.AddAssemblyEntry(conversion.Model, entry);	
		}

        public void AddAssociatedDefinition(ILConversion conversion, ConvertedAssembly convertedAssembly,
            AssemblyDefinitionAndStream adas)
        {
            var definition = adas.AssemblyDefinition;

            convertedAssembly.AssociatedAssemblyDefinitions.Add(definition.Name.FullName, definition);

            conversion.Model.Semantic.Assemblies.Collectible.Add(definition.Name.FullName, convertedAssembly);
            conversion.Model.Semantic.Assemblies.ByResolutionName.Add(definition.Name.FullName, convertedAssembly);
            

	        Infrastructure.Models.Structural.AddAssemblyDefinition(conversion.Model, definition);


        }

       
    }
}
