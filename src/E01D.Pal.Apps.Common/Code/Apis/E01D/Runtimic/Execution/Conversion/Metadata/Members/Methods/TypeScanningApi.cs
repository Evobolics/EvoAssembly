using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// Ensures that all of the types that the method uses have been created so that when the methods is actually converted,
        /// no types have to be created.
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="boundTypeMask"></param>
        public void EnsureTypes(ILConversion conversion, SemanticTypeMask_I boundTypeMask)
        {
            if (!boundTypeMask.IsDefinition())
            {
                return;
            }

            var typeDefinitionMask = (BoundTypeDefinitionMask_I)boundTypeMask;

            var typeReference = typeDefinitionMask.SourceTypeReference;

            // Done on purpose to find errors
            var typeDefinition = Cecil.GetFundamentalTypeDefinition(typeReference);

            var methods = typeDefinition.Methods;

            for (int i = 0; i < methods.Count; i++)
            {
                var method = methods[i];
                EnsureTypes(conversion, method, typeReference);
            }
        }

        public void EnsureTypes(ILConversion conversion, MethodDefinition method, TypeReference genericArgumentSource)
        {
            EnsureReturnType(conversion, method, genericArgumentSource);

            EnsureParameterTypes(conversion, method, genericArgumentSource);

            EnsureGenericParameters(conversion, method, genericArgumentSource);

            if (method.Body == null) return; // can be null if it is a delegate
            
            EnsureVariableTypes(conversion, method, genericArgumentSource);

            Instructions.TypeScanning.EnsureTypes(conversion, method.Body.Instructions);
            
        }

        private void EnsureVariableTypes(ILConversion conversion, MethodDefinition method, TypeReference genericArgumentSource)
        {
            if (method.Body.HasVariables)
            {
                foreach (var variable in method.Body.Variables)
                {
                    var resolvedVariableTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, variable.VariableType);

                    Types.Scanning.EnsureType(conversion, resolvedVariableTypeReference);
                }
            }
        }

        private void EnsureGenericParameters(ILConversion conversion, MethodDefinition method, TypeReference genericArgumentSource)
        {
            var genericParameters = method.GenericParameters;

            for (int i = 0; i < genericParameters.Count; i++)
            {
                var genericParameter = genericParameters[i];

                var genericParameterConstraints = genericParameter.Constraints;

                for (int j = 0; j < genericParameterConstraints.Count; j++)
                {
                    var resolvedConstraintTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, genericParameterConstraints[j]);

                    Types.Scanning.EnsureType(conversion, resolvedConstraintTypeReference);
                }
            }
        }

        private void EnsureParameterTypes(ILConversion conversion, MethodDefinition method, TypeReference genericArgumentSource)
        {
            var parameters = method.Parameters;

            for (int i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];

                var parameterType = parameter.ParameterType;

                if (parameterType.IsGenericParameter) continue;

                var resolvedParameterTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, parameterType);

                Types.Scanning.EnsureType(conversion, resolvedParameterTypeReference);
            }
        }

        private void EnsureReturnType(ILConversion conversion, MethodDefinition method, TypeReference genericArgumentSource)
        {
            var returnType = method.ReturnType;

            // If generic, go ahead and skip.  It will get resolved.
            if (returnType.IsGenericParameter) return;

            var resolvedReturnTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, returnType);

            Types.Scanning.EnsureType(conversion, resolvedReturnTypeReference);
        }

    }

    
}
