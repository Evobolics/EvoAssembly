namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionTypeNode_I: ExecutionTypeNodeMask_I
	{
		
		new ExecutionTypeNode_I PointerType { get; set; }

		new ExecutionTypeNode_I ByReferenceType { get; set; }
		ExecutionTypeNodeMask_I[] Arrays { get; set; }
		ExecutionGenericInstanceTypeNode[] Generics { get; set; }
	}
}
