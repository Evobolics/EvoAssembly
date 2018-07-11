using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public class ReferenceApi<TContainer> : ConversionApiNode<TContainer>, ReferenceApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public BoundType_I Create(ILConversion conversion, TypeReference input)
		{
            // WHERE THE bound assembly gets created, it creates the bound modules.  Where the bound modules get created, it needs to create bound types for
            // each of types that is in the module.  It just needs the entry and the type definition.  
            

			throw new NotImplementedException();
		}
	}
}
