namespace Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types
{
	/// <summary>
	/// Represents a type node that is the basis for other nodes to be generated.  
	/// The node is not a "type specification."  I.e. not an array, not an generic instance. 
	/// </summary>
	/// <notes>
	/// Represents a "runtime instance type" / "type specification".  The names definition and specification are very confusing as they are 
	/// quite synomous.  A definition means "a statement of the exact meaning of a word, especially in a dictionary."  A specification means
	/// "an act of describing or identifying something precisely; stating a precise requirement; a detailed description." The words precisely and detailed imply
	/// the concept of 'definition' which is supposed to precisely and detailed.  Thus new words were found to better describe the relationship.  Currently
	/// those words are primary and secondary. 
    /// 
    /// A primary node is permenatly represented / associated with a module / assembly.  Thus, it has a assembly node and a module node associated with it.
	/// </notes>
	public abstract class UnifiedTypePrimaryNode:UnifiedTypeNode
	{
		public UnifiedAssemblyNode AssemblyNode { get; set; }

		public UnifiedModuleNode ModuleNode { get; set; }

		

		//public UnifiedTypeNode BlueprintNode { get; set; }

		

		//public SemanticTypeDefinitionMask_I SemanticType { get; set; }

		//public SemanticTypeDefinitionMask_I PointerType { get; set; }

		//public SemanticTypeDefinitionMask_I ByReferenceType { get; set; }
		//public UnifiedTypeNode Next { get; set; }
	}
}
