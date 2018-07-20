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

        public void BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            // Done on purpose to find errors
            var typeDefinition = (TypeDefinition)input.SourceTypeReference;

            if (!typeDefinition.HasMethods) return;

            if (input.SourceTypeReference.Name == "PublicClass_I")
            {

            }

            if (input is ConvertedTypeDefinitionWithConstructors_I convertedTypeWithConstructors)
            {
                BuildConstructorInstructions(conversion, input, convertedTypeWithConstructors.Constructors);
            }

           


            if (input is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods)
            {
                BuildMethodInstructions(conversion, input, convertedTypeWithMethods.Methods);
            }

            
        }

        private void BuildConstructorInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionConstructors constructors)
        {
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

                convertedConstructor.IlGenerator = convertedConstructor.ConstructorBuilder.GetILGenerator();

                IL.GenerateIL(conversion, input, convertedConstructor);
            }
        }

        private void BuildMethodInstructions(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedTypeDefinitionMethods methods)
        {
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

                    if (convertedMethod.DeclaringType.IsInterface())
                    {

                    }

	                var methodBuilder = convertedMethod.MethodBuilder;

					convertedMethod.IlGenerator = methodBuilder.GetILGenerator();

                    IL.GenerateIL(conversion, input, convertedMethod);
                }

            }
        }
    }
}
