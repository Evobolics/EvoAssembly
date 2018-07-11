using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
	public class ModelApi<TContainer> : ConversionApiNode<TContainer>, ModelApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public new ModelAssembliesApi_I<TContainer> Assemblies { get; set; }

        public new ModelFieldsApi_I<TContainer> Fields { get; set; }

        public new ModelModulesApi_I<TContainer> Modules { get; set; }

        public new ModelTypesApi_I<TContainer> Types { get; set; }

        ModelAssembliesApiMask_I ModelApiMask_I.Assemblies => Assemblies;

		
        ModelFieldsApiMask_I ModelApiMask_I.Fields => Fields;

        ModelModulesApiMask_I ModelApiMask_I.Modules => Modules;

        ModelTypesApiMask_I ModelApiMask_I.Types => Types;

        

        

        public bool IsConverted(ILConversion conversion, TypeReference input)
        {
            string assemlbyName = Cecil.Metadata.Assemblies.GetAssemblyName(input);

            return conversion.ConvertibleAssemblies.ContainsKey(assemlbyName);
        }

        

        public bool IsConverted(ILConversion conversion, Type input)
        {
            return conversion.ConvertibleAssemblies.ContainsKey(input.Assembly.FullName);
        }

        
        
    }
}
