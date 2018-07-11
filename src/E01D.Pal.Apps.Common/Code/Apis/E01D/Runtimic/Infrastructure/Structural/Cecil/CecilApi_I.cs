using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil
{
    public interface CecilApi_I<TContainer> : CecilApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    
		new MetadataApi_I<TContainer> Metadata { get; set; }
	}
}
