namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionTypeNodeMask_I
	{
		ExecutionTypeDefinitionMask_I Type { get;  }
		ExecutionTypeNode_I PointerType { get;  }

		ExecutionTypeNode_I ByReferenceType { get; }
		int Rank { get; set; }
	}
}
