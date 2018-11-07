namespace Royale_Platformer.Model
{
    interface Serializer
    {
        string Serialize();
        Serializer Deserialize(string serialized);
    }
}
