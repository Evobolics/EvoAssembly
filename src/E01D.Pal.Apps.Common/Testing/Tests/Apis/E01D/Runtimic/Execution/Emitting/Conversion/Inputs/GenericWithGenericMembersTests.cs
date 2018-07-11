using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Attributes.E01D;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
    public class GenericWithGenericMembersTests
    {
        [Test]
        public void Execute()
        {
            AppDomain myDomain = AppDomain.CurrentDomain;
            AssemblyName myAsmName = new AssemblyName("GenericEmitExample1");
            AssemblyBuilder myAssembly = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndCollect);

            ModuleBuilder myModule = myAssembly.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");

            // --Build Type : GenericWithGenericMembers<T>

            TypeBuilder gwgmClass = myModule.DefineType("GenericWithGenericMembers`1", TypeAttributes.Public);

            string[] gwgmParamNames = { "T"};

            GenericTypeParameterBuilder[] gwgmParams = gwgmClass.DefineGenericParameters(gwgmParamNames);

            var gwgmT = gwgmParams[0];

            // --Build Type : GenericWithGenericMembers<T>

            TypeBuilder sgcClass = myModule.DefineType("SimpleGenericClass`1", TypeAttributes.Public);

            string[] sgcParamNames = { "T"};

            var sgcTypeParams = sgcClass.DefineGenericParameters(sgcParamNames);

            var sgcT = sgcTypeParams[0];

            sgcClass.CreateType();

            var method = gwgmClass.DefineMethod("Howdy", MethodAttributes.Public, typeof(void), Type.EmptyTypes);

            var generator = method.GetILGenerator();

            generator.Emit(OpCodes.Ret);

            gwgmClass.CreateType();

            
            

        }
    }
}
