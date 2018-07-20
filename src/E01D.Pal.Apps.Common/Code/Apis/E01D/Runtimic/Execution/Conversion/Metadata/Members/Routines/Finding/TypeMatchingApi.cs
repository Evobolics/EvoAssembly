using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public class TypeMatchingApi<TContainer> : ConversionApiNode<TContainer>, TypeMatchingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public bool VerifyTypeMatch(ILConversion conversion, TypeReference methodDefType, TypeReference methodSpecType, GenericArgumentEntryMap map)
        {
            if (methodDefType.IsGenericParameter || (methodDefType.IsByReference && methodDefType.GetElementType().IsGenericParameter))
            {
                int genericMethodDefTypeParameterPosition = GetGenericParameterPosition(methodDefType);

                int genericMethodSpecTypeParameterPosition = GetGenericParameterPosition(methodSpecType);

                return genericMethodDefTypeParameterPosition == genericMethodSpecTypeParameterPosition;
            }

            Type cecilType = null;

            if (methodSpecType is GenericParameter genericParameter)
            {
                if (genericParameter.Type == GenericParameterType.Method)
                {
                    if (!map.Method.TryGetValue(genericParameter.Position, out GenericArgumentEntry genericArgumentEntry))
                    {
                        return false;
                    }

                    cecilType = genericArgumentEntry.Type;
                }
                else
                {
                    if (!map.Type.TryGetValue(genericParameter.Position, out GenericArgumentEntry genericArgumentEntry))
                    {
                        return false;
                    }

                    cecilType = genericArgumentEntry.Type;
                }

                if (cecilType == null) throw new NotSupportedException("Not expected.");

                if (cecilType.FullName != methodDefType.FullName) return false;


            }
            else if (methodSpecType is GenericInstanceType genericInstanceType)
            {
                var arguments = genericInstanceType.GenericArguments;

                var types = new BoundTypeMask_I[arguments.Count];

                int i = 0;

                foreach (var argument in arguments)
                {

                    if (argument is GenericParameter genericParameter1)
                    {
                        if (genericParameter1.Type == GenericParameterType.Method)
                        {
                            if (!map.Method.TryGetValue(genericParameter1.Position, out GenericArgumentEntry genericArgumentEntry))
                            {
                                return false;
                            }

                            cecilType = genericArgumentEntry.Type;
                        }
                        else
                        {
                            if (!map.Type.TryGetValue(genericParameter1.Position, out GenericArgumentEntry genericArgumentEntry))
                            {
                                return false;
                            }

                            cecilType = genericArgumentEntry.Type;
                        }

                        var argumentTypeDefinitionEntry = Execution.Types.Ensuring.EnsureBound(conversion, argument);

                        types[i++] = argumentTypeDefinitionEntry ?? throw new NotSupportedException("Not expected.");
                    }
                }

                throw new System.NotImplementedException("");
                //var type = Models.Types.ResolveToType(conversion.Model, cecilReturnType, types);

                //if (runtimeReturnType != type) return false;
            }
            else
            {
                var type1 = Execution.Types.Ensuring.EnsureBound(conversion, methodSpecType);

                var type2 = Execution.Types.Ensuring.EnsureBound(conversion, methodDefType);

                return type1 == type2;
            }




            return true;
        }

        private int GetGenericParameterPosition(TypeReference methodDefType)
        {
            if ((methodDefType is TypeSpecification parameterTypeSpecification)
                && parameterTypeSpecification.GenericParameters.Count > 0
                && (parameterTypeSpecification.ElementType is GenericParameter cecilGenericParameter))
            {
                return cecilGenericParameter.Position;
            }
            else if (methodDefType is GenericParameter cecilGenericParameter1)
            {
                return cecilGenericParameter1.Position;
            }
            else
            {
                throw new NotSupportedException("Not supported yet.");
            }
        }
    }
}
