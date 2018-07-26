using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
        

	    public WithILGeneratorApi_I<TContainer> WithILGenerator { get; set; }

	    WithILGeneratorApiMask_I BuildingApiMask_I.WithILGenerator => WithILGenerator;

	    public WithoutILGeneratorApi_I<TContainer> WithoutILGenerator { get; set; }

	    WithoutILGeneratorApiMask_I BuildingApiMask_I.WithoutILGenerator => WithoutILGenerator;

		public bool BuildInstructions(ILConversion conversion, ConvertedTypeDefinition_I convertedType)
        {
	        var noDependenciesFound = true;

	        if (conversion.Configuration.UseILGenerator)
	        {
		        // Done on purpose to find errors
		        var typeDefinition = (TypeDefinition)convertedType.SourceTypeReference;

		        if (!typeDefinition.HasMethods) return true;

		        if (convertedType is ConvertedTypeDefinitionWithConstructors_I convertedTypeWithConstructors)
		        {
			        noDependenciesFound &= BuildConstructorInstructions(conversion, convertedType, convertedTypeWithConstructors.Constructors);
		        }

		        if (convertedType is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods)
		        {
			        noDependenciesFound &= BuildMethodInstructions(conversion, convertedType, convertedTypeWithMethods.Methods);
		        }
	        }
	        else
	        {
		        if (convertedType is ConvertedTypeDefinitionWithConstructors_I convertedTypeWithConstructors)
		        {
					foreach (var constructorEntry in convertedTypeWithConstructors.Constructors.All)
					{
						if (!(constructorEntry is ConvertedEmittedConstructor convertedConstructor))
						{
							throw new Exception("Expected a converted constructor to build.");
						}

						var methodReference = constructorEntry.MethodReference;

						if (!methodReference.IsDefinition) continue;

						var methodDefinition = (MethodDefinition)methodReference;

						if (methodDefinition.Body == null) continue;

						

						WithoutILGenerator.BuildBody(conversion, convertedType, convertedConstructor);

						

						//noDependenciesFound &= IL.WithILGenerator.GenerateIL(conversion, input, convertedConstructor);
					}
				}



				
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

	            noDependenciesFound &= WithILGenerator.GenerateIL(conversion, input, convertedConstructor);
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

	                noDependenciesFound &= WithILGenerator.GenerateIL(conversion, input, convertedMethod);
                }

            }

	        return noDependenciesFound;

        }
    }
}
