using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural
{
    public class AssemblyDefinitionAndStream
    {
        public AssemblyDefinition AssemblyDefinition { get; set; }

        public System.IO.Stream Stream { get; set; }
    }
}
