using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
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
                Methods.Building.Emitted.BuildMethod(conversion, (ConvertedTypeWithMethods_I)input, method);
            }
        }

        public Type[] CreateParameters(ILConversion conversion, ConvertedRoutine routine)
        {
            var methodDefinition = routine.MethodReference;

            if (!methodDefinition.HasParameters) return new Type[0];

            var systemParameterTypes = new Type[methodDefinition.Parameters.Count];

            for (int i = 0; i < methodDefinition.Parameters.Count; i++)
            {
                var parameterDefinition = methodDefinition.Parameters[i];

                var bound = Execution.Types.Ensuring.EnsureBound(conversion, parameterDefinition.ParameterType);

                var convertedParameter = new ConvertedRoutineParameter()
                {
                    ParameterDefinition = parameterDefinition,
                    Position = parameterDefinition.Sequence,
                    Name = parameterDefinition.Name,
                    ParameterType = bound
                };

                // Make sure the 0th "this" parameter is not being overridden
                //if (
                //    //!methodDefinition.IsStatic && 
                //    convertedParameter.Position == 0)
                //{
                //    throw new Exception("Parameter position is zero which should be reserved for the 'return' argument.");
                //}

                routine.Parameters.All.Add(convertedParameter);

                systemParameterTypes[i] = bound.UnderlyingType;
            }

            return systemParameterTypes;
        }

        public Type SetReturnType(ILConversion conversion, ConvertedRoutine routine)
        {
            var methodDefinition = routine.MethodReference;

            if (methodDefinition.ReturnType == null) return null;

            var bound = Execution.Types.Ensuring.EnsureBound(conversion, methodDefinition.ReturnType);

            routine.ReturnType = bound;

            return bound.UnderlyingType;
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
                    var parameterType = Execution.Types.Ensuring.EnsureBound(conversion, parameterDefinition.ParameterType);

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
                var parameter = (ConvertedRoutineParameter)routine.Parameters.All[i];

                parameter.Builder = CreateParameterBuilder(conversion, routine, parameter);
            }
        }

        public ParameterBuilder CreateParameterBuilder(ILConversion conversion, ConvertedRoutine routine, ConvertedRoutineParameter parameter)
        {
            ParameterBuilder builder = null;

            var attributes = GetParameterAttributes(parameter.ParameterDefinition);


            if (routine.IsConstructor())
            {
                var constructor = (ConvertedEmittedConstructor) routine;

                builder = constructor.ConstructorBuilder.DefineParameter(parameter.Position, attributes, parameter.Name);
            }
            else
            {
                var method = (ConvertedBuiltMethod) routine;

                builder = method.MethodBuilder.DefineParameter(parameter.Position, attributes, parameter.Name);
            }

            if ((attributes & ParameterAttributes.HasDefault) > 0)
            {
                builder.SetConstant(parameter.ParameterDefinition.Constant);
            }

            CustomAttributes.BuildCustomAttributes(conversion, parameter);

            return builder;
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
