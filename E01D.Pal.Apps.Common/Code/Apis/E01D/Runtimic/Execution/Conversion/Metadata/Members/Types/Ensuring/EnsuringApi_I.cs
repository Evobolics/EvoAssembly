using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
	public interface EnsuringApi_I<TContainer> : EnsuringApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new ArrayApi_I<TContainer> Arrays { get; set; }

        

        new EnumApi_I<TContainer> Enums { get; set; }

        new GenericApi_I<TContainer> Generic { get; set; }

        new GenericParameterApi_I<TContainer> GenericParameters { get; set; }

        new NonGenericInstanceApi_I<TContainer> NonGenericInstances { get; set; }
    }
}
