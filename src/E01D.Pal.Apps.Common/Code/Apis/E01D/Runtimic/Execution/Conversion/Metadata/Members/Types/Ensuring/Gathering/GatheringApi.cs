using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering
{
    public class GatheringApi<TContainer> : ConversionApiNode<TContainer>, GatheringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public new CecilApi_I<TContainer> Cecil { get; set; }

        CecilApiMask_I GatheringApiMask_I.Cecil => Cecil;

        

        

        public BoundTypeDefinitionMask_I EnsureBaseType(ILConversion conversion, ConvertedTypeDefinition_I converted)
        {
            var baseTypeReference = Infrastructure.Structural.Cecil.GetBaseType(converted.SourceTypeReference);

            BoundTypeDefinitionMask_I boundBaseType = null;

            if (baseTypeReference != null)
            {
                var result = Execution.Types.Ensuring.Ensure(conversion.Model, baseTypeReference, null, converted);

                if (!(result is BoundTypeDefinitionMask_I boundBaseType1))
                {
                    throw new Exception("When creating a conversion model, the base type needs to be a bound type.");
                }

                boundBaseType = boundBaseType1;

                converted.BaseType = boundBaseType;

                if (converted.BaseType != null)
                {
                    Types.Dependencies.Add(converted, converted.BaseType);
                }
            }

            System.Type baseType;

            if (converted.IsStruct())
            {
                baseType = boundBaseType?.UnderlyingType ?? GetValueType(conversion);
            }
            else
            {
                baseType = boundBaseType?.UnderlyingType ?? (converted.IsClassType() ? GetObjectType(conversion) : null);
            }

            if (baseType == null && (converted.IsClassType() || converted.IsStruct()))
            {
                throw new Exception("The bound's undelrying type cannot be null.  The converted type is a class or struct, and in either case requires a base class of either System.Object or System.ValueType.");
            }

            converted.TypeBuilder.SetParent(baseType);

            return boundBaseType;
        }

        private System.Type GetObjectType(ILConversion conversion)
        {
            return Binding.Models.Types.GetObjectType(conversion.Model);
        }

        

        private System.Type GetValueType(ILConversion conversion)
        {
            return Binding.Models.Types.GetValueType(conversion.Model);
        }

        public void EnsureInterfaces(ILConversion conversion, ConvertedTypeDefinition_I converted)
        {
            if (!(converted.SupportsInterfaceTypeList() && converted is SemanticTypeWithInterfaceTypeList_I tewii))
            {
                return;
            }

            var typeDefinition = (TypeDefinition)converted.SourceTypeReference;

            var interfaceTypes = typeDefinition.Interfaces;

            for (int i = 0; i < interfaceTypes.Count; i++)
            {
                var interfaceImplementation = interfaceTypes[i];

                var interfaceType = interfaceImplementation.InterfaceType;

                var item = Execution.Types.Ensuring.Ensure(conversion.Model, interfaceType, null, null);

                if (!(item is BoundTypeDefinitionMask_I boundInterface))
                {
                    throw new Exception("When creating a conversion model, the base type needs to be a bound type.");
                }

                converted.TypeBuilder.AddInterfaceImplementation(boundInterface.UnderlyingType);

	            var resolutionName = Types.Naming.GetResolutionName(item);

				tewii.Interfaces.ByResolutionName.Add(resolutionName, (SemanticInterfaceTypeMask_I)item);

                Types.Dependencies.Add(converted, item);
            }
        }

        public void  GetNestedTypes(ILConversion conversion, ConvertedTypeDefinition_I declaringType)
        {
            declaringType.NestedTypes = new Dictionary<string, SemanticTypeMask_I>();

            var typeDefinition = (TypeDefinition)declaringType.SourceTypeReference;

            var nestedTypes = typeDefinition.NestedTypes;

            for (int i = 0; i < nestedTypes.Count; i++)
            {
                var nestedType = nestedTypes[i];

                var boundNestedType = Execution.Types.Ensuring.Ensure(conversion.Model, nestedType, null, declaringType);

                declaringType.NestedTypes.Add(boundNestedType.FullName, boundNestedType);
            }
        }

        



        

        

        private void DefineTypeParameterBuildersIfPresent(ILConversion conversion, ConvertedTypeDefinition_I convertedType)
        {
            if (!convertedType.IsGeneric()) return;

            var gtd = (ConvertedGenericTypeDefinition_I)convertedType;

            if (!gtd.HasTypeParameters()) return;

            var ctwtb = (ConvertedTypeDefinitionWithTypeBuilder_I)convertedType;

            var tpList = gtd.TypeParameters.All;

            var names = Types.TypeParameters.GetNames(conversion, gtd);

            var genericParameters = convertedType.TypeBuilder.DefineGenericParameters(names);

            gtd.TypeParameters.Builders = genericParameters;

            for (var i = 0; i < tpList.Count; i++)
            {
                var tp = (ConvertedGenericParameterTypeDefinition)tpList[i];

                tp.Builder = genericParameters[i];

                tp.UnderlyingType = genericParameters[i];

                
            }
        }

        

        

        

       
    }
}
