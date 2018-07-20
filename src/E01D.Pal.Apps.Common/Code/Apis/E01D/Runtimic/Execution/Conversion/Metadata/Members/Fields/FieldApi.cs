using System;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Getting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields
{
    public class FieldApi<TContainer> : ConversionApiNode<TContainer>, FieldApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I FieldApiMask_I.Building => Building;

	    public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I FieldApiMask_I.Getting => Getting;

		public TypeScanningApi_I<TContainer> TypeScanning { get; set; }
        

        TypeScanningApiMask_I FieldApiMask_I.TypeScanning => TypeScanning;

        public FieldInfo GetFieldInfo(ILConversion conversion, SemanticTypeDefinitionMask_I declaringType, string fieldReferenceName)
        {
            // There is nothing that is conversion specific.  Shoot the call downstream.
            return Binding.Metadata.Members.Fields.GetFieldInfo(conversion.Model, declaringType, fieldReferenceName);   
        }

        public FieldInfo GetFieldInfo(ILConversion conversion, Type declaringType, FieldReference fieldReference)
        {
            return declaringType.GetField(fieldReference.Name);
        }

		
	}
}
