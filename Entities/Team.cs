using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
    public class Team
    {
        [DataMember]
        public string Name { get; set; }
    }
}
