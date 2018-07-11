namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class GenericWithGenericMembersRecurisve<T>
    {
        public GenericClassWithMembersThatTakeInGenericClassParameters<T> RecursiveField;
    }
}
