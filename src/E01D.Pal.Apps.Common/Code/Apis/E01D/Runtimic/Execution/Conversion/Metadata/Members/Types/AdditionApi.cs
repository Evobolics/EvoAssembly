using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class AdditionApi<TContainer> : ConversionApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public T Add<T>(Dictionary<string, T> dictionary, T entry)
            where T: TypeMask_I
		{
		    return Infrastructure.Semantic.Metadata.Members.Types.Addition.Add(dictionary, entry);
        }

		public Dictionary<string, T> Add<T>(Dictionary<string, T> results, Dictionary<string, T> dependencies)
            where T: BoundTypeMask_I
        {
            return Infrastructure.Semantic.Metadata.Members.Types.Addition.Add(results, dependencies);
		}

        /// <summary>
        /// Adds the type to the  module
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
		public SemanticTypeMask_I Add(ILConversion conversion, ConvertedModuleMask_I module, ConvertedTypeDefinition_I entry)
		{
		    

            // 1) Do what needs to be done in this class
		    Add(module.Types.ConvertedByResolutionName, entry);

            // 2) Call base class
            Semantic.Metadata.Members.Types.Addition.Add(conversion.Model, module, entry);

			
			

           

           

            return entry;

		    
        }
    }
}
