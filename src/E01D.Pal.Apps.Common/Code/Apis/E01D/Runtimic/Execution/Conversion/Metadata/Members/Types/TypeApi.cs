using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Baking;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class TypeApi<TContainer> : ConversionApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		
		public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BakingApi_I<TContainer> Baking { get; set; }

        
	    public BaseTypeApi_I<TContainer> BaseTypes { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
		public CreationApi_I<TContainer> Creation { get; set; }

		
		public DependencyApi_I<TContainer> Dependencies { get; set; }

		
		public EnsuringApi_I<TContainer> Ensuring { get; set; }


	    public Generics.GenericApi_I<TContainer> Generic { get; set; }

		public GettingApi_I<TContainer> Getting { get; set; }

	    
	    public InterfaceApi_I<TContainer> Interfaces { get; set; }

        
        public NamingApi_I<TContainer> Naming { get; set; }

        
        public TypeScanningApi_I<TContainer> Scanning { get; set; }

        
        public TypeParameterApi_I<TContainer> TypeParameters { get; set; }


        AdditionApiMask_I TypeApiMask_I.Addition => Addition;

        BakingApiMask_I TypeApiMask_I.Baking => Baking;

        BaseTypeApiMask_I TypeApiMask_I.BaseTypes => BaseTypes;

        BuildingApiMask_I TypeApiMask_I.Building => Building;

        CreationApiMask_I TypeApiMask_I.Creation
        {
            // ReSharper disable once ArrangeAccessorOwnerBody
            get { return this.Creation; }
        }

        DependencyApiMask_I TypeApiMask_I.Dependencies => Dependencies;

        EnsuringApiMask_I TypeApiMask_I.Ensuring => Ensuring;

        GettingApiMask_I TypeApiMask_I.Getting => Getting;

	    Generics.GenericApiMask_I TypeApiMask_I.Generic => Generic;

		InterfaceApiMask_I TypeApiMask_I.Interfaces => Interfaces;

        NamingApiMask_I TypeApiMask_I.Naming => Naming;

        TypeScanningApiMask_I TypeApiMask_I.Scanning => Scanning;

        TypeParameterApiMask_I TypeApiMask_I.TypeParameters => TypeParameters;

        

        

		

        public bool IsCorlibType(TypeReference typeReference)
        {
            var scope = typeReference.Scope;

            return Modules.IsCorlib(scope);
        }

        public bool IsCorlibType(System.Type type)
        {
            return Modules.IsCorlib(type.Module);
        }

	    public ConversionTypeNode EnsureTypeNode(ILConversion conversion, ConvertedModuleNode convertedModuleNode, Type type)
	    {
		    // By passing in the module node, the cecil system does not have to start from scratch looking for the type.  It just needs to look at this module
		    // for the type.
		    //var structuralTypeNode = Cecil.Metadata.Members.Types.Ensuring.EnsureTypeNode(conversion.RuntimicSystem, convertedModuleNode.StructuralNode, type);

		    var structuralTypeNode = Structural.Types.Ensure(conversion.RuntimicSystem, type);

		    return EnsureTypeNode(conversion, convertedModuleNode, structuralTypeNode);


		}

	    public ConversionTypeNode EnsureTypeNode(ILConversion conversion, StructuralTypeNode structuralTypeNode)
	    {
			// By passing in the module node, the cecil system does not have to start from scratch looking for the type.  It just needs to look at this module
			// for the type.
			//var structuralTypeNode = Cecil.Metadata.Members.Types.Ensuring.EnsureTypeNode(conversion.RuntimicSystem, convertedModuleNode.StructuralNode, type);

		    //ConvertedModuleNode convertedModuleNode = Modules.Ensure(conversion, structuralTypeNode.Module);

			throw new System.NotImplementedException();
	    }

		public ConversionTypeNode EnsureTypeNode(ILConversion conversion, ConvertedModuleNode convertedModuleNode, StructuralTypeNode structuralTypeNode)
	    {
		    // By passing in the module node, the cecil system does not have to start from scratch looking for the type.  It just needs to look at this module
		    // for the type.
		    //var structuralTypeNode = Cecil.Metadata.Members.Types.Ensuring.EnsureTypeNode(conversion.RuntimicSystem, convertedModuleNode.StructuralNode, type);

			

		    //if (!structuralTypeNode.IsDerived)
		    //{
			   // ConvertedTypeTable table;

			   // var tableId = (int) (structuralTypeNode.MetadataToken & 0xFF000000);

			   // if (!convertedModuleNode.Tables.TryGetValue(tableId, out table))
			   // {
				  //  table = new ConvertedTypeTable();

				  //  convertedModuleNode.Tables.Add(tableId, table);
			   // }

			   // var rowId = structuralTypeNode.MetadataToken & 0x00FFFFFF;

			   // if (rowId > 0 && table.ByRow.TryGetValue(rowId, out ConversionTypeNode node))
			   // {
				  //  return node;
			   // }
		    //}

		    //node = new ConversionTypeNode()
		    //{
			   // StemType = structuralTypeNode.StemType != null ? EnsureTypeNode(conversion, convertedModuleNode, structuralTypeNode.StemType) : null,
			   // InputStructuralNode = structuralTypeNode,
			   // IsDerived = structuralTypeNode.IsDerived
		    //};

		    //if (rowId > 0)
		    //{
			   // table.ByRow.Add(rowId, node);
		    //}


		    //return node;

			throw new System.NotImplementedException();
		
	    }

	   

	    
    }
}
