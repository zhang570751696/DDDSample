using System.Xml.Serialization;

namespace Rick.DataAccess.Config
{
    public class DataConnection
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string ConnectionString { get; set; }
    }
}