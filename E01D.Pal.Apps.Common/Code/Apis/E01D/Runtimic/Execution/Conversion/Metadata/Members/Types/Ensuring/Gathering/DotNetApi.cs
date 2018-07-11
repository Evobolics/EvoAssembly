using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering
{
    public class DotNetApi<TContainer> : ConversionApiNode<TContainer>, DotNetApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        //public AssignmentApi<TContainer> Assignment { get; set; }

        //AssignmentApiMask_I DotNetApiMask_I.Assignment => Assignment;

        public DotNet.GatheringApi<TContainer> Gathering { get; set; }

        

        DotNet.GatheringApiMask_I DotNetApiMask_I.Gathering => Gathering;

        // <summary>
        /// Ensures the semantic type is added to the model.
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="input"></param>
        /// <returns>Returns a bound type.  A bound type is required due to the need for the underlying type. </returns>
        public BoundTypeDefinitionMask_I EnsureType(ILConversion conversion, System.Type input)
        {
            

            throw new System.NotImplementedException();


            //// Create the type instance
            //var createdType = Types.Creation.CreateType(conversion.Model, moduleEntry, input);

            //// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
            //Types.Addition.Add(conversion, moduleEntry, createdType);

            //if (createdType.Name == "SimpleGenericClassWithInterface1`1")
            //{

            //}

            //var baseType = Gathering.GetBaseType(conversion, input);

            //var interfaces = Gathering.GetInterfaces(conversion, input);

            //var typeArguments = Gathering.GetTypeArguments(conversion, input);

            //var typeParameters = Gathering.GetTypeParameters(conversion, input);

            //var nestedTypes = Gathering.GetNestedTypes(conversion, input, createdType);

            //var genericBlueprint = Gathering.GetGenericBlueprint(conversion, input);

            //Types.Ensuring.Assignment.AssignBaseType(createdType, baseType);

            //Types.Ensuring.Assignment.AssignInterfaces(createdType, interfaces);

            //Types.Ensuring.Assignment.AssignTypeArguments(createdType, typeArguments);

            //Types.Ensuring.Assignment.AssignTypeParameters(conversion, createdType, typeParameters);

            //Types.Ensuring.Assignment.AssignNestedTypes(createdType, nestedTypes);

            //Types.Ensuring.Assignment.AssignGenericBlueprint(createdType, genericBlueprint);

            //EnsureMembers(conversion, createdType);

            //// return the type
            //return createdType;

        }

        private void EnsureMembers(ILConversion conversion, ConvertedTypeDefinition input)
        {
            if (input.SourceTypeReference == null && input is SemanticGenericTypeDefinition_I genericTypeDefinition && genericTypeDefinition.GenericTypeDefinition != null) return;

            Fields.TypeScanning.EnsureTypes(conversion, input);

            Properties.TypeScanning.EnsureTypes(conversion, input);

            Events.TypeScanning.EnsureTypes(conversion, input);

            Methods.TypeScanning.EnsureTypes(conversion, input);
        }
    }
}
