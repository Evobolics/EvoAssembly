using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound
{
    public class BindingApi<TContainer> : ExecutionApiNode<TContainer>, BindingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public MetadataApi_I<TContainer> Metadata { get; set; }
        public ModelApi_I<TContainer> Models { get; set; }
        ModelApiMask_I BindingApiMask_I.Models => Models;

        MetadataApiMask_I BindingApiMask_I.Metadata => Metadata;

	    public System.Type MakeGenericType(BoundTypeDefinitionMask_I boundType, Type[] typeParameters)
	    {
		    return XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.MakeGenericType(boundType.UnderlyingType, typeParameters);
	    }
	}
}
