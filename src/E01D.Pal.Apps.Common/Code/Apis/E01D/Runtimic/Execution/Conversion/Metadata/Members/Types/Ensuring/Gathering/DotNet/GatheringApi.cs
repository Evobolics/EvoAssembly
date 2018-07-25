using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using GenericParameterAttributes = System.Reflection.GenericParameterAttributes;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.DotNet
{
    public class GatheringApi<TContainer> : ConversionApiNode<TContainer>, GatheringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BoundTypeMask_I GetGenericBlueprint(ILConversion conversion, Type input)
        {
            if (input.GenericTypeArguments.Length > 0)
            {
                var genericTypeDefinitionType = input.GetGenericTypeDefinition();

                return Types.Ensuring.DotNet.EnsureType(conversion, genericTypeDefinitionType);
            }

            return null;

            
        }

        public BoundTypeMask_I GetBaseType(ILConversion conversion, Type input)
        {
            if (input.BaseType == null) return null;

            var result = Types.Ensuring.DotNet.EnsureType(conversion, input.BaseType);

            if (!result.IsBound())
            {
                throw new Exception("When creating a conversion model, the base type needs to be a bound type.");
            }

            return result;
        }

        public List<SemanticTypeMask_I> GetInterfaces(ILConversion conversion, Type input)
        {
            List<SemanticTypeMask_I> interfaces = new List<SemanticTypeMask_I>();

            var interfaceTypes = input.GetInterfaces();

            for (int i = 0; i < interfaceTypes.Length; i++)
            {
                var interfaceType = interfaceTypes[i];

                interfaces.Add(Types.Ensuring.DotNet.EnsureType(conversion, interfaceType));
            }

            return interfaces;
        }

        public Dictionary<string, SemanticTypeMask_I> GetNestedTypes(ILConversion conversion, Type input, ConvertedTypeDefinition declaringType)
        {
            var nestedTypesList = new Dictionary<string, SemanticTypeMask_I>();

            var nestedTypes = input.GetNestedTypes();

            for (int i = 0; i < nestedTypes.Length; i++)
            {
                var nestedType = nestedTypes[i];

                var boundNestedType = Types.Ensuring.DotNet.EnsureType(conversion, nestedType);

                var x = (ConvertedMemberWithDeclaringType_I) boundNestedType;

                x.DeclaringType = declaringType;

	            var resolutionName = Types.Naming.GetResolutionName(boundNestedType);

				nestedTypesList.Add(resolutionName, boundNestedType);
            }

            return nestedTypesList;
        }

        public List<BoundTypeMask_I> GetTypeArguments(ILConversion conversion, Type inputType)
        {
            var list = new List<BoundTypeMask_I>();

            if (inputType.GenericTypeArguments.Length <= 0) return list;

            for (var i = 0; i < inputType.GenericTypeArguments.Length; i++)
            {
                var genericArgument = inputType.GenericTypeArguments[i];

                var semanticType = Types.Ensuring.DotNet.EnsureType(conversion, genericArgument);

                list.Add(Models.Types.GetBoundTypeOrThrow(semanticType, false));   
            }

            return list;
        }

        public List<ConvertedGenericParameterTypeDefinition> GetTypeParameters(ILConversion conversion, Type inputType)
        {
            if (!inputType.ContainsGenericParameters) return new List<ConvertedGenericParameterTypeDefinition>();

            var parameters = inputType.GetGenericArguments();

            var list = new List<ConvertedGenericParameterTypeDefinition>();

            for (var i = 0; i < parameters.Length; i++)
            {
                var typeParameter = GetTypeParameter(conversion, inputType, parameters[i]);

                list.Add(typeParameter);
            }

            return list;
        }

        public ConvertedGenericParameterTypeDefinition GetTypeParameter(ILConversion conversion, Type inputType, Type typeParamterType)
        {
            var typeParameter = new ConvertedGenericParameterTypeDefinition
            {
                Attributes = GetTypeParameterConstraints(typeParamterType),
                Name = typeParamterType.Name,
                FullName = typeParamterType.FullName,
                Position = typeParamterType.GenericParameterPosition,
                TypeParameterKind = TypeParameterKind.Type,
                ConstructorMethod = 3
            };

            var constraints = typeParamterType.GetGenericParameterConstraints();
            
            //var semanticConstraints = new BoundGenericParameterTypeDefinitionConstraintMask_I[constraints.Length];

            for (int i = 0; i < constraints.Length; i++)
            {
                var constraint = constraints[i];

                ConvertedTypeParameterConstraint semanticConstraint;

                if (constraint.IsClass)
                {
                    var x = new ConvertedClassTypeParameterConstraint()
                    {
                        Attributes = GetTypeParameterConstraints(constraint),
                        Class = Types.Ensuring.DotNet.EnsureType(conversion, constraint)
                    };

                    typeParameter.BaseTypeConstraint = x;

                    //semanticConstraint = x;
                }
                else
                {
                    var x = new ConvertedInterfaceTypeParameterConstraint()
                    {
                        Attributes = GetTypeParameterConstraints(constraint),
                        Interface = Types.Ensuring.DotNet.EnsureType(conversion, constraint)
                    };

                    //semanticConstraint = x;

                    typeParameter.InterfaceTypeConstraints.Add(x);
                }

                //semanticConstraints[i] = semanticConstraint;
            }

            return typeParameter;
        }

        public TypeParameterConstraintKind GetTypeParameterConstraints(Type constraint)
        {
            var attributes = default(TypeParameterConstraintKind);

            if (!constraint.IsGenericParameter) return attributes;

            var gpa = constraint.GenericParameterAttributes;

            if ((gpa & GenericParameterAttributes.None) == GenericParameterAttributes.None)
            {
                attributes |= TypeParameterConstraintKind.None;
            }

            if ((gpa & GenericParameterAttributes.Covariant) == GenericParameterAttributes.Covariant)
            {
                attributes |= TypeParameterConstraintKind.Covariant;
            }
            if ((gpa & GenericParameterAttributes.Contravariant) == GenericParameterAttributes.Contravariant)
            {
                attributes |= TypeParameterConstraintKind.Contravariant;
            }
            if ((gpa & GenericParameterAttributes.VarianceMask) == GenericParameterAttributes.VarianceMask)
            {
                attributes |= TypeParameterConstraintKind.VarianceMask;
            }
            if ((gpa & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint)
            {
                attributes |= TypeParameterConstraintKind.ReferenceTypeConstraint;
            }
            if ((gpa & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint)
            {
                attributes |= TypeParameterConstraintKind.NotNullableValueTypeConstraint;
            }
            if ((gpa & GenericParameterAttributes.DefaultConstructorConstraint) == GenericParameterAttributes.DefaultConstructorConstraint)
            {
                attributes |= TypeParameterConstraintKind.DefaultConstructorConstraint;
            }

            return attributes;
        }
    }
}
