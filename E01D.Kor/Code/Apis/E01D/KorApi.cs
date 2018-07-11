namespace Root.Code.Apis.E01D
{
    public class KorApi:Api, KorApi_I
    {
        public DebugApi_I Debug { get; set; } = new DebugApi();
        
    }
}
