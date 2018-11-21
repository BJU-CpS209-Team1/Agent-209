namespace Royale_Platformer.Model
{
    public interface ISerializer
    {
        string Serialize();

        // Credit Taylor Schuler for Interface inheritance idea
        ISerializer Deserialize(string serialized);
    }
}
