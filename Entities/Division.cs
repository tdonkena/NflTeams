using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
    public class Division
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Team[] Teams { get; set; }
    }
}
