namespace Royale_Platformer.Model
{
    interface Serializer : Serializer
    {
        public string Serialize();
        public object Deserialize(string serialized);
    }
}
