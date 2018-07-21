using System;
using System.Collections.Generic;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using ParameterAttributes = System.Reflection.ParameterAttributes;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void BuildRoutines(ILConversion conversion, ConvertedTypeDefinitionMask_I input)
        {
	        if (input.SourceTypeReference is GenericInstanceType genericInstance)
	        {
		        Methods.Building.RuntimeCreated.BuildMethods(conversion, (ConvertedGenericTypeDefinition_I)input);

		        Constructors.Building.RuntimeCreated.BuildConstructors(conversion, (ConvertedGenericTypeDefinition_I)input);
			}
			else
	        {
		        // Done on purpose to find errors
		        var typeDefinition = (TypeDefinition)input.SourceTypeReference;

		        if (!typeDefinition.HasMethods) return;

		        for (int i = 0; i < typeDefinition.Methods.Count; i++)
		        {
			        var method = typeDefinition.Methods[i];

			        BuildRoutine(conversion, input, method);
		        }
			}
            
        }

        public void BuildRoutine(ILConversion conversion, ConvertedTypeDefinitionMask_I input, MethodDefinition method)
        {
            // TODO: remove filter and enable the generic methods to have methods and constructors.
            if (input.IsGeneric() && input is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType())
            {
                return;
            }

            if (method.Name == ConstructorInfo.ConstructorName || method.Name == ConstructorInfo.TypeConstructorName)
            {
                // access container
                Constructors.Building.Emitted.BuildConstructor(conversion, input, method);
            }
            else
            {
                Methods.Building.Emitted.BuildMethod(conversion, (ConvertedTypeDefinitionWithMethods_I)input, method);
            }
        }

	    

		/// <summary>
		/// Used by the constructor and method builders to build out the common portions of the routine.  This generally includes the return type and 
		/// parameter types.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="input"></param>
		/// <param name="routine"></param>
		public void BuildRoutine(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedRoutine routine)
        {
            CreateParameters(conversion, routine);

            routine.ReturnType = GetReturnType(conversion, routine);
        }

        private void CreateParameters(ILConversion conversion, ConvertedRoutine routine)
        {
			var methodDefinition = Cecil.Metadata.Members.Methods.ResolveReferenceToNonSignatureDefinition(conversion.Model, routine.MethodReference);

            if (!methodDefinition.HasParameters) return;

            foreach (var parameterDefinition in methodDefinition.Parameters)
            {
                var convertedParameter = new ConvertedMethodParameter()
                {
                    ParameterDefinition = parameterDefinition,
                    Position = parameterDefinition.Sequence,
                    Name = parameterDefinition.Name,
                    Builder = null,
                    ParameterType = Execution.Types.Ensuring.EnsureBound(conversion.Model, parameterDefinition.ParameterType)
                };

				// Make sure the 0th "this" parameter is not being overridden
                if (!methodDefinition.IsStatic && convertedParameter.Position == 0)
                {
                    throw new Exception("Parameter position is zero which should be reserved for the 'this' argument.");
                }

                routine.Parameters.ByName.Add(convertedParameter.Name, convertedParameter);

                routine.Parameters.All.Add(convertedParameter);

	            
			}
        }

        public BoundTypeDefinitionMask_I GetReturnType(ILConversion conversion, ConvertedRoutine routine)
        {
            var methodDefinition = routine.MethodReference;

            if (methodDefinition.ReturnType == null) return null;

            return Execution.Types.Ensuring.EnsureBound(conversion.Model, methodDefinition.ReturnType);
        }

        [Obsolete] //?
        public BoundTypeMask_I[] GetParameterTypes(ILConversion conversion, ConvertedBuiltMethod methodEntry)
        {
            var methodDefinition = methodEntry.MethodReference;

            if (methodDefinition.HasParameters)
            {
                List<BoundTypeMask_I> parameterTypeList = new List<BoundTypeMask_I>();

                foreach (var parameterDefinition in methodDefinition.Parameters)
                {
                    var parameterType = Execution.Types.Ensuring.EnsureBound(conversion.Model, parameterDefinition.ParameterType);

                    parameterTypeList.Add(parameterType);
                }

                return parameterTypeList.ToArray();
            }

            return new BoundTypeMask_I[0];
        }

        public void CreateParameterBuilders(ILConversion conversion, ConvertedRoutine routine)
        {
            for (int i = 0; i < routine.Parameters.All.Count; i++)
            {
                var parameter = (ConvertedMethodParameter)routine.Parameters.All[i];

                var attributes = GetParameterAttributes(parameter.ParameterDefinition);

	            


				if (routine.IsConstructor())
                {
                    var constructor = (ConvertedEmittedConstructor) routine;

                    parameter.Builder = constructor.ConstructorBuilder.DefineParameter(parameter.Position, attributes, parameter.Name);
                }
                else
                {
                    var method = (ConvertedBuiltMethod)routine;

                    parameter.Builder = method.MethodBuilder.DefineParameter(parameter.Position, attributes, parameter.Name);
                }

                if ((attributes & ParameterAttributes.HasDefault) > 0)
                {
                    parameter.Builder.SetConstant(parameter.ParameterDefinition.Constant);
                }

	            CustomAttributes.BuildCustomAttributes(conversion, parameter);

			}
        }

        private ParameterAttributes GetParameterAttributes(ParameterDefinition definition)
        {
            ParameterAttributes result = ParameterAttributes.None;

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.HasDefault) == Libs.Mono.Cecil.ParameterAttributes.HasDefault)
            {
                result |= ParameterAttributes.HasDefault;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.HasFieldMarshal) == Libs.Mono.Cecil.ParameterAttributes.HasFieldMarshal)
            {
                result |= ParameterAttributes.HasFieldMarshal;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.In) == Libs.Mono.Cecil.ParameterAttributes.In)
            {
                result |= ParameterAttributes.In;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.Lcid) == Libs.Mono.Cecil.ParameterAttributes.Lcid)
            {
                result |= ParameterAttributes.Lcid;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.Optional) == Libs.Mono.Cecil.ParameterAttributes.Optional)
            {
                result |= ParameterAttributes.Optional;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.Out) == Libs.Mono.Cecil.ParameterAttributes.Out)
            {
                result |= ParameterAttributes.Out;
            }

            if ((definition.Attributes & Libs.Mono.Cecil.ParameterAttributes.Retval) == Libs.Mono.Cecil.ParameterAttributes.Retval)
            {
                result |= ParameterAttributes.Retval;
            }

            return result;
        }

    }
}
