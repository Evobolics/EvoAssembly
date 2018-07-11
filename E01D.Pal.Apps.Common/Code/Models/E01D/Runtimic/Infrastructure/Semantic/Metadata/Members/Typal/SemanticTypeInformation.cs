using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class SemanticTypeInformation
    {
        

        public bool IsArray { get; set; }

        public bool IsClass { get; set; }

        public bool IsClosedGeneric { get; set; }

        public bool IsDelegate { get; set; }

        public bool IsEnum { get; set; }

        

        public bool IsGeneric { get; set; }

        public bool IsGlobal { get; set; }

        public bool IsInterface { get; set; }

        public bool IsNested { get; set; }

        public bool IsOpenGeneric { get; set; }

        public bool IsValueType { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public TypeReference TypeReference { get; set; }

        public GenericInstanceType GenericInstanceType { get; set; }

        public System.Reflection.Emit.PackingSize PackingSize { get; set; }
        public SemanticTypeInformation[] TypeArguments { get; set; }
        public GenericTypeKind GenericKind { get; set; }
        public TypeReference GenericTypeDefinition { get; set; }
        public bool IsAnonymousType { get; set; }
	    public bool IsPointer { get; set; }
	    public bool IsRequiredModifier { get; set; }


	    //public TypeReference[] Arguments { get; set; }
        //public TypeReference BaseType { get; set; }
        //public List<TypeReference> Interfaces { get; set; }
        //public List<TypeReference> NestedTypes { get; set; }
        //public TypeDefinition[] GenericArguments { get; set; }
        //public TypeDefinition GenericBlueprint { get; set; }
    }
}
