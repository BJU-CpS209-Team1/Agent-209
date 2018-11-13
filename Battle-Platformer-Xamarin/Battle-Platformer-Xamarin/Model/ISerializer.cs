namespace Royale_Platformer.Model
{
    public interface ISerializer
    {
        string Serialize();
        ISerializer Deserialize(string serialized);
    }
}
