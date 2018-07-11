using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public interface PalMemberApi_I
    {
        PalTypeApi_I Types { get; }
        PalPropertyApi_I Properties { get;  }
        PalMethodApi_I Methods { get; set; }
    }
}
