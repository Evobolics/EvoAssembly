using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Getting;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields
{
    public interface FieldApiMask_I
    {
        BuildingApiMask_I Building { get; }

	    GettingApiMask_I Getting { get; }

		TypeScanningApiMask_I TypeScanning { get; }

        FieldInfo GetFieldInfo(ILConversion conversion, SemanticTypeDefinitionMask_I declaringType, string fieldReferenceName);

        FieldInfo GetFieldInfo(ILConversion conversion, System.Type declaringType, FieldReference fieldReference);
	 
    }
}
