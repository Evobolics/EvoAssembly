using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public interface ConstructorApiMask_I
    {
        BuildingApiMask_I Building { get; }

	    GettingApiMask_I Getting { get; }



		



    }
}
