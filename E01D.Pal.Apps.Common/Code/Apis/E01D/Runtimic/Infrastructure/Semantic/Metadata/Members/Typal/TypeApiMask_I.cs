using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface TypeApiMask_I
    {
        AdditionApiMask_I Addition { get; }

        CreationApiMask_I Creation { get; }

        EnsuringApiMask_I Ensuring { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

		GettingApiMask_I Getting { get; }

        InformationApiMask_I Information { get; }

        NamingApiMask_I Naming { get; }
    }
}
