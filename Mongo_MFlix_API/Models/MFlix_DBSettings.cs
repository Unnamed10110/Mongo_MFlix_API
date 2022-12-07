namespace Mongo_MFlix_API.Models
{
    public interface IMFlix_DBSettings
    {
        string Server { get; set; }

        string Database { get; set; }

        string Collection { get; set; }
    }

    public class MFlix_DBSettings:IMFlix_DBSettings
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }
    }
}
