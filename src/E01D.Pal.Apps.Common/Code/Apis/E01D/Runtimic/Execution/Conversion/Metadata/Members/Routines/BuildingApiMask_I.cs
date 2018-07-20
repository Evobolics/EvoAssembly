using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines
{
    public interface BuildingApiMask_I
    {
        void BuildRoutines(ILConversion conversion, ConvertedTypeDefinitionMask_I input);

        void BuildRoutine(ILConversion conversion, ConvertedTypeDefinitionMask_I input, MethodDefinition method);

        /// <summary>
        /// Used by the constructor and method builders to build out the common portions of the routine.  This generally includes the return type and 
        /// parameter types.
        /// </summary>
        /// <param name="conversion"></param>
        /// <param name="input"></param>
        /// <param name="routine"></param>
        void BuildRoutine(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedRoutine routine);

        void CreateParameterBuilders(ILConversion conversion, ConvertedRoutine routine);
    }
}
