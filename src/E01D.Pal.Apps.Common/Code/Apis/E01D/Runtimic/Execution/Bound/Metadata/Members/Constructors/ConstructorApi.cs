using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Metadata;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors
{
	public class ConstructorApi<TContainer> : BoundApiNode<TContainer>, ConstructorApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I ConstructorApiMask_I.Building => Building;

		public ConstructorInfo GetConstructorInfo(RuntimicSystemModel conversionModel, MemberReference memberReference)
        {
            var declaringBound = Members.GetDeclaringType(conversionModel, memberReference);

            return (ConstructorInfo)FindConstructorBySignature(conversionModel, declaringBound, memberReference);
        }

        public MemberInfo FindConstructorBySignature(RuntimicSystemModel conversionModel, BoundTypeDefinitionMask_I typeEntry, MemberReference memberReference)
        {
            switch (memberReference.MetadataToken.TokenType)
            {
                case TokenType.Method:
                case TokenType.MemberRef:
                {
                    return FindConstructorBySignature(conversionModel, typeEntry, (MethodReference)memberReference);

                }
                case TokenType.MethodSpec:
                {
                    throw new System.Exception("Not handled");
                }
                default:
                {
                    throw new System.Exception("Not handled");
                }
            }
        }

        public ConstructorInfo FindConstructorBySignature(RuntimicSystemModel boundModel, 
            BoundTypeDefinitionMask_I methodReferenceDeclaringType, MethodReference methodReference)
        {
            // NOTE - This version of the method cannot access constructor builders, which are neccessary when building
            //        constructor calls for a converted classes instructions.

            var parameterTypes = Parameters.GetSystemParameterTypes(boundModel, methodReferenceDeclaringType.SourceTypeReference, methodReference);

            //if (methodReferenceDeclaringType.SourceTypeReference.IsGenericInstance)
            //{
            //    GenericInstanceType genericInstance = (GenericInstanceType)methodReferenceDeclaringType.SourceTypeReference;

            //    if (Execution.Types.IsConverted(boundModel, methodReference.DeclaringType) && Cecil.Types.ContainsGenericMethodParameters(genericInstance))
            //    {
            //        var dictionaryType = methodReferenceDeclaringType.UnderlyingType.GetGenericTypeDefinition();
            //        var x = dictionaryType.GetConstructor(parameterTypes);
            //        var y = TypeBuilder.GetConstructor(methodReferenceDeclaringType.UnderlyingType, x);

            //        return y;
            //    }
            //}

            //if (declaringType.FullName == "System.Collections.Generic.Dictionary`2<System.String,T1>")
            //{
            //    var generic = declaringType.UnderlyingType.GetGenericTypeDefinition();

            //    var x1 = (TypeBuilder) declaringType.UnderlyingType;

            //    var x = generic.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //    var y = generic.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //    var result = TypeBuilder.GetConstructor(generic, x[0]);
            //}

			// Using the BindingFlags.Instance is important as certain constructors (like System.Attribute) will not show up without it.
            var constructor = methodReferenceDeclaringType.UnderlyingType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, parameterTypes, null); 

            if (constructor == null)
            {
                throw new System.Exception("Could not find constructor.");
            }

            return constructor;
        }
    }
}
