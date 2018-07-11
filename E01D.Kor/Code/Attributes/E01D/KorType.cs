namespace Root.Code.Attributes.E01D
{
    /// <summary>
    /// Used just to indicate and affirm that the developer knows that this type should be included into any 
    /// boot image if one is created and as such, should generally aim to only expose static functionality if at all possible to keep
    /// the kor image compilation as simple as possible.
    /// </summary>
    public class KorTypeAttribute:System.Attribute
    {

    }
}
