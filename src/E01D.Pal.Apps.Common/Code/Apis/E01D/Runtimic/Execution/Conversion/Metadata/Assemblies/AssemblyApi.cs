using System;
using System.IO;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : ConversionApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

	    
	    public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
	    public CreationApi_I<TContainer> Creation { get; set; }

	    
	    public EnsuringApi_I<TContainer> Ensuring { get; set; }

	    
	    public GettingApi_I<TContainer> Getting { get; set; }

	    
	    public LoadingApi_I<TContainer> Loading { get; set; }

		
		public NamingApi_I<TContainer> Naming { get; set; }

	    
	    public QueryApi_I<TContainer> Query { get; set; }

		
		public StreamApi_I<TContainer> Streams { get; set; }

	    
	    public new TypeApi_I<TContainer> Types { get; set; }
	    

	    AdditionApiMask_I AssemblyApiMask_I.Addition => Addition;

        BuildingApiMask_I AssemblyApiMask_I.Building => Building;

        CreationApiMask_I AssemblyApiMask_I.Creation => Creation;

	    EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

	    GettingApiMask_I AssemblyApiMask_I.Getting => Getting;

	    LoadingApiMask_I AssemblyApiMask_I.Loading => Loading;

		NamingApiMask_I AssemblyApiMask_I.Naming => Naming;

	    QueryApiMask_I AssemblyApiMask_I.Query => Query;

		StreamApiMask_I AssemblyApiMask_I.Streams => Streams;

	    Assemblies.TypeApiMask_I AssemblyApiMask_I.Types => Types;

		#endregion

	    public ConvertedAssemblyNode EnsureNode(ILConversion conversion, Assembly assembly)
	    {
		    var assemblyNode = Structural.Metadata.Assemblies.Ensuring.Ensure(conversion.RuntimicSystem, assembly);

		    return EnsureNode(conversion, assemblyNode);
	    }

	    public ConvertedAssemblyNode EnsureNode(ILConversion conversion, Stream stream)
	    {
		    var assemblyNode = Infrastructure.Structural.Metadata.Assemblies.Ensuring.Ensure(conversion.RuntimicSystem, stream);

		    return EnsureNode(conversion, assemblyNode);
	    }

		public ConvertedAssemblyNode EnsureNode(ILConversion conversion, StructuralAssemblyNode inputStructuralNode)
	    {
		    if (conversion.MetadataModel.Assemblies.ByMetadataId.TryGetValue(inputStructuralNode.MetadataId, out ConvertedAssemblyNode convertedAssemblyNode))
		    {
			    return convertedAssemblyNode;
		    }

		    var guid = Guid.NewGuid();

		    var fullName = Assemblies.Naming.GetAssemblyName(conversion, inputStructuralNode.FullName, guid);

			convertedAssemblyNode = new ConvertedAssemblyNode()
		    {
				Guid = guid,
				Id = Runtimic.Identification.IssueId(conversion.RuntimicSystem),
				InputStructuralNode = inputStructuralNode,
			    MetadataId = inputStructuralNode.MetadataId,
                InputFullName = inputStructuralNode.FullName,
				FullName = fullName
			};

		    conversion.MetadataModel.Assemblies.ById.Add(convertedAssemblyNode.Id, convertedAssemblyNode);
		    conversion.MetadataModel.Assemblies.ByMetadataId.Add(inputStructuralNode.MetadataId, convertedAssemblyNode);
		    conversion.MetadataModel.Assemblies.ByName.Add(convertedAssemblyNode.FullName, convertedAssemblyNode);
		    conversion.MetadataModel.Assemblies.BySourceName.Add(convertedAssemblyNode.InputFullName, convertedAssemblyNode);

			convertedAssemblyNode.ConvertedAssembly = Assemblies.Creation.CreateConvertedAssembly(conversion, convertedAssemblyNode.FullName, convertedAssemblyNode);

			return convertedAssemblyNode;
	    }
	}
}
