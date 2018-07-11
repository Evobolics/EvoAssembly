using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
    public class TypeParameterApi<TContainer> : BindingApiNode<TContainer>, TypeParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I TypeParameterApiMask_I.Building => Building;

		public void Add(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, SemanticGenericParameterTypeDefinitionMask_I typeParameter)
        {
            if (typeParameter.TypeParameterKind == TypeParameterKind.Unknown)
            {
                throw new Exception("Type parameter kind is set to unknown");
            }

            if (typeParameter.Position < 0)
            {
                throw new Exception("Position cannot be a negative number.  Make sure it is set to value greater than or equal to zero when creating the parameter.");
            }

            definitions.ByName.Add(typeParameter.Name, typeParameter);

            definitions.ByPosition.Add(typeParameter.Position, typeParameter);

            definitions.All.Add(typeParameter);
        }

        public void Create()
        {
            
        }

        public void Add(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, List<SemanticGenericParameterTypeDefinitionMask_I> inputList)
        {
            for (int i =0; i< inputList.Count; i++)
            {
                Add(conversion, definitions, inputList[i]);
            }
        }

        public void Clear(ILConversion conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions)
        {
            definitions.ByName.Clear();

            definitions.ByPosition.Clear();

            definitions.All.Clear();
        }

        public SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, string name)
        {
            if (definitions.ByName.TryGetValue(name, out SemanticGenericParameterTypeDefinitionMask_I typeParameter))
            {
                return typeParameter;
            }
            
            return null;
        }

        public SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, int position)
        {
            if (definitions.ByPosition.TryGetValue(position, out SemanticGenericParameterTypeDefinitionMask_I typeParameter))
            {
                return typeParameter;
            }

            return null;
        }

        public string[] GetNames(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions)
        {
            var all = definitions.All;

            string[] nameList = new string[all.Count];

            for (int i = 0; i < all.Count; i++)
            {
                var tp = all[i];

                nameList[i] = tp.Name;
            }

            return nameList;
        }

        public SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, string name)
        {
            var result = Get(conversion, definitions, name);

            if (result == null)
            {
                throw new Exception($"Could not find type parameter with name {name}");
            }

            return result;
        }

        public SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions, int position)
        {
            var result = Get(conversion, definitions, position);

            if (result == null)
            {
                throw new Exception($"Could not find type parameter with position {position}");
            }

            return result;
        }

        public BoundTypeDefinitionMask_I Resolve(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I declaringType,GenericParameter parameter)
        {
            if (!declaringType.IsGeneric())
            {
                throw new Exception("Expected the resolved semantic type to be a generic type.");
            }

            SemanticGenericTypeDefinitionMask_I generic = (SemanticGenericTypeDefinitionMask_I)declaringType;

            if (!generic.TypeParameters.ByName.TryGetValue(parameter.Name, out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
            {
                throw new Exception($"Expected the generic type to have a type parameter named {parameter.Name}.");
            }

            if (!semanticTypeParameter.IsBound())
            {
                throw new Exception("Expected the generic parameter type to be a bound type.");
            }

            return (BoundTypeDefinitionMask_I)semanticTypeParameter;
        }

        public BoundTypeDefinitionMask_I Resolve(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
            MethodDefinition methodDefinition, GenericParameter parameter)
        {
            if (!(declaringType is BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods))
            {
                throw new Exception("Trying to add a method to a type that does not support methods.");
            }

            var method = Methods.FindMethodByDefinition(model, boundTypeWithMethods, methodDefinition);

            if (!method.TypeParameters.ByName.TryGetValue(parameter.Name,out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
            {
                throw new Exception(
                    $"Expected the generic method to have a type parameter named {parameter.Name}.");
            }

            if (!semanticTypeParameter.IsBound())
            {
                throw new Exception("Expected the generic parameter type to be a bound type.");
            }

            return (BoundTypeDefinitionMask_I)semanticTypeParameter;
        }
    }
}
