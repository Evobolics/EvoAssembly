using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public class SimpleApi<TContainer>: BindingApiNode<TContainer>, SimpleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public bool IsSimpleType(string fullName)
        {
            switch (fullName)
            {
                case "System.Boolean":
                case "System.Byte":
                case "System.Char":
                case "System.Decimal":
                case "System.Double":
                case "System.Single":
                case "System.SByte":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                case "System.String":
                case "System.Object":
                    return true;
                default:
                    return false;
            }
        }
    }
}
