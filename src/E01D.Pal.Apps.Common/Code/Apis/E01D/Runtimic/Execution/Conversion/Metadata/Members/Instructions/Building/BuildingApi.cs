using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
        public ILApi_I<TContainer> IL { get; set; }

        ILApiMask_I BuildingApiMask_I.IL => IL;

        public bool BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            // Done on purpose to find errors
            var typeDefinition = (TypeDefinition)input.SourceTypeReference;

            if (!typeDefinition.HasMethods) return true;

	        bool noDependenciesFound = true;

			if (input is ConvertedTypeDefinitionWithConstructors_I convertedTypeWithConstructors)
            {
	            noDependenciesFound &= BuildConstructorInstructions(conversion, input, convertedTypeWithConstructors.Constructors);
            }

            if (input is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods)
            {
	            noDependenciesFound &= BuildMethodInstructions(conversion, input, convertedTypeWithMethods.Methods);
            }

	        return noDependenciesFound;

        }

        private bool BuildConstructorInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionConstructors constructors)
        {
	        bool noDependenciesFound = true;

			foreach (var constructorEntry in constructors.All)
            {
                if (!(constructorEntry is ConvertedEmittedConstructor convertedConstructor))
                {
                    throw new Exception("Expected a converted constructor to build.");
                }

                var methodReference = constructorEntry.MethodReference;

	            if (!methodReference.IsDefinition) continue;

	            var methodDefinition = (MethodDefinition) methodReference;

                if (methodDefinition.Body == null) continue;

	            if (convertedConstructor.IlGenerator == null) // can be null if this is tried a second time.
	            {
					convertedConstructor.IlGenerator = convertedConstructor.ConstructorBuilder.GetILGenerator();
				}

	            noDependenciesFound &= IL.GenerateIL(conversion, input, convertedConstructor);
            }

	        return noDependenciesFound;
        }

        private bool BuildMethodInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionMethods methods)
        {
	        bool noDependenciesFound = true;

            foreach (var methodList in methods.ByName.Values)
            {
                foreach (var methodEntry in methodList)
                {
                    if (!(methodEntry is ConvertedBuiltMethod convertedMethod))
                    {
                        throw new Exception("Expected a converted method to build.");
                    }

	                var methodReference = methodEntry.MethodReference;

					if (!methodReference.IsDefinition) continue;

	                var methodDefinition = (MethodDefinition)methodReference;
					
                    if (methodDefinition.Body == null) continue;

	                var methodBuilder = convertedMethod.MethodBuilder;

	                if (convertedMethod.IlGenerator == null) // can be null if this is tried a second time.
	                {
		                convertedMethod.IlGenerator = methodBuilder.GetILGenerator();
	                }

	                noDependenciesFound &= IL.GenerateIL(conversion, input, convertedMethod);
                }

            }

	        return noDependenciesFound;

        }
    }
}
