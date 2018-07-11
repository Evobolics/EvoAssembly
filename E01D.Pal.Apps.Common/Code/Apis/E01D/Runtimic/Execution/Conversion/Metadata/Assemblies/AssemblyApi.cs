using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : ConversionApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

	    [ValueSetDynamically]
	    public AdditionApi_I<TContainer> Addition { get; set; }

        [ValueSetDynamically]
        public BuildingApi_I<TContainer> Building { get; set; }

        [ValueSetDynamically]
	    public CreationApi_I<TContainer> Creation { get; set; }

	    [ValueSetDynamically]
	    public EnsuringApi_I<TContainer> Ensuring { get; set; }

		[ValueSetDynamically]
		public NamingApi_I<TContainer> Naming { get; set; }

	    [ValueSetDynamically]
		public StreamApi_I<TContainer> Streams { get; set; }

	    [ValueSetDynamically]
	    public new TypeApi_I<TContainer> Types { get; set; }

		AdditionApiMask_I AssemblyApiMask_I.Addition => Addition;

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        CreationApiMask_I AssemblyApiMask_I.Creation => Creation;

	    EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

		NamingApiMask_I AssemblyApiMask_I.Naming => Naming;

	    StreamApiMask_I AssemblyApiMask_I.Streams => Streams;

	    Assemblies.TypeApiMask_I AssemblyApiMask_I.Types => Types;

		#endregion

		#region Methods

		public ILConversionResult Convert(ILConversion conversion, Stream[] streams)
		{
			return Streams.Convert(conversion, streams);
		}

        /// <summary>
        /// Converts the specified types to a collectible assembly.  All dependent types should be included.
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="inputTypes"></param>
        public ILConversionResult Convert(ILConversion conversion, Type[] inputTypes)
        {
	        return Types.Convert(conversion, inputTypes);
        }

	    public SemanticAssemblyMask_I GetAssembly(ILConversion conversion, AssemblyDefinition assemblyDefinition)
	    {
		    return GetAssembly(conversion.Model, assemblyDefinition);
	    }

	    public SemanticAssemblyMask_I GetAssembly(ILConversion conversion, Assembly assembly)
	    {
	        return GetAssembly(conversion.Model, assembly.FullName);
        }

        public SemanticAssemblyMask_I GetAssembly(InfrastructureModelMask_I model, AssemblyNameReference assemblyDefinition)
        {
            return GetAssembly(model, assemblyDefinition.FullName);
        }

        public SemanticAssemblyMask_I GetAssembly(InfrastructureModelMask_I model, AssemblyDefinition assemblyDefinition)
        {
            return GetAssembly(model, assemblyDefinition.FullName);
        }

        public SemanticAssemblyMask_I GetAssembly(InfrastructureModelMask_I model, string fullName)
        {
            if (!model.Semantic.Assemblies.ByResolutionName.TryGetValue(fullName, out SemanticAssemblyMask_I assemblyEntry))
            {
                return null;
            }

            return assemblyEntry;
        }

        public SemanticAssemblyMask_I GetAssembly(ILConversionExecutionModel model, AssemblyDefinition assemblyDefinition)
        {
            return GetAssembly(model, assemblyDefinition.FullName);
        }

       

        public AssemblyDefinitionAndStream GetAssemblyDefinition(ILConversion conversion, Assembly assembly)
        {
            AssemblyDefinitionAndStream adas = new AssemblyDefinitionAndStream();

            adas.AssemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, assembly);

            return adas;

        }

        public bool IsCorlib(IMetadataScope scope)
        {
            if (scope is AssemblyNameReference assemblyNameReference)
            {
                return IsCorlib(assemblyNameReference.FullName);
            }

            return IsCorlib(scope.Name);
        }

        public bool IsCorlib(string name)
        {
            return name.StartsWith("mscorlib");
        }

        public bool IsConverted(ILConversion conversion, IMetadataScope scope)
        {
            if (scope is AssemblyNameReference assemblyNameReference)
            {
                return IsConverted(conversion, assemblyNameReference.FullName);
            }

            return IsConverted(conversion, scope.Name);
        }

        public bool IsConverted(ILConversion conversion, string name)
        {
            if (conversion.Configuration.ConvertedAssemblies.ContainsKey(name))
            {
                return true;
            }

            if (Assemblies.IsCorlib(name) && conversion.Configuration.DoNotConvertCorlib)
            {
                return false;
            }

            return !conversion.Configuration.IsConvertingTypeSet;

        }

        

        public bool TryGet(ILConversion conversion, string fullName, out SemanticAssemblyMask_I semanticAssemblyMask)
        {
            return conversion.Model.Semantic.Assemblies.ByResolutionName.TryGetValue(fullName, out semanticAssemblyMask); 
        }

        #endregion
    }
}
