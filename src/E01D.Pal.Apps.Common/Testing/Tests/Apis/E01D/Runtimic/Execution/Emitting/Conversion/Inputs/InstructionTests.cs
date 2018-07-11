using System.Reflection.Emit;
using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{

    public class InstructionTests
    {
        [Test]
        public void Insturction_Support_For_Add()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Add), "Execute");

            Assert.AreEqual(4, (int)result);
        }

        [Test]
        public void Instruction_Support_For_AddOvf()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_AddOvf), "Execute");

            Assert.AreEqual(4, (int)result);
        }

        [Test]
        public void Instruction_Support_For_AddOvfUn()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_AddOvfUn), "Execute");

            Assert.AreEqual(4, (uint)result);
        }

        [Test]
        public void Instruction_Support_For_And()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_And), "Execute1");

            Assert.AreEqual(true, (bool)result);

            result = test.Api.ConvertCreateCall(typeof(InstructionTest_And), "Execute2");

            Assert.AreEqual(false, (bool)result);

            result = test.Api.ConvertCreateCall(typeof(InstructionTest_And), "Execute3");

            Assert.AreEqual(false, (bool)result);

            result = test.Api.ConvertCreateCall(typeof(InstructionTest_And), "Execute4");

            Assert.AreEqual(false, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Beq()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Beq, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool) result);
        }

        

        [Test]
        public void Instruction_Support_For_Beqs()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Beq_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bge()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bge, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bge_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bge_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bge_Un()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bge_Un, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bge_Un_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bge_Un_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bgt()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 2);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bgt, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bgt_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 2);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bgt_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bgt_Un()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 2);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bgt_Un, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Bgt_Un_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 2);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Bgt_Un_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Ble()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ble, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Ble_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ble_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Ble_Un()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ble_Un, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Ble_Un_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Ble_Un_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Blt()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Blt, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Blt_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Blt_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Blt_Un()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Blt_Un, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Blt_Un_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Blt_Un_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Br()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Brfalse()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Brfalse, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Brfalse_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Brfalse_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Brtrue()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Brtrue, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Brtrue_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Brtrue_S, success);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Br, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Br_S()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            var result = test.Api.CreateTypeAndExecute((il) =>
            {
                Label endOfMthd = il.DefineLabel();
                Label success = il.DefineLabel();

                il.Emit(OpCodes.Ldc_I4_S, 1);
                il.Emit(OpCodes.Brtrue_S, success);
                il.Emit(OpCodes.Ldc_I4_S, 0);
                il.Emit(OpCodes.Br_S, endOfMthd);
                il.MarkLabel(success);
                il.Emit(OpCodes.Ldc_I4_1);
                il.MarkLabel(endOfMthd);
                il.Emit(OpCodes.Ret);
            });

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Call_Simple()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Call_Simple), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Call_Simple_Args()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Call_Simple_Args), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Call_Simple_Args_Multiple()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Call_Simple_Args_Multiple), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Call_Simple_TwoTypes()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Call_TwoTypes), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Call_Simple_Generic()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Call_Simple_Generic), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_CastClass()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_CastClass), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

        [Test]
        public void Instruction_Support_For_Ceq()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Ceq), "Execute");

            Assert.AreEqual(true, (bool)result);
        }

	    [Test]
	    public void Instruction_Support_For_Switch()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(InstructionTest_Switch), "Execute");

		    Assert.AreEqual(55, (int)result);
	    }
	}
}
