namespace Royale_Platformer.Model
{
    interface ISerializer
    {
        string Serialize();
        ISerializer Deserialize(string serialized);
    }
}
