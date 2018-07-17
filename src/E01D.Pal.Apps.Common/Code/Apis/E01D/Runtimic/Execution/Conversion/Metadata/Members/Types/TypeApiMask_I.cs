using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Baking;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface TypeApiMask_I
    {


        AdditionApiMask_I Addition { get; }

        BakingApiMask_I Baking { get; }

        BaseTypeApiMask_I BaseTypes { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

        DependencyApiMask_I Dependencies { get; }

        EnsuringApiMask_I Ensuring { get; }

	    Generics.GenericApiMask_I Generic { get; }

		GettingApiMask_I Getting { get; }

        InterfaceApiMask_I Interfaces { get; }

        NamingApiMask_I Naming { get; }

        TypeScanningApiMask_I Scanning { get; }

        TypeParameterApiMask_I TypeParameters { get;  }


	    




		bool IsCorlibType(TypeReference typeReference);

        bool IsCorlibType(System.Type type);
        
    }
}
