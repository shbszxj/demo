using CQRSlite.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service.Events
{
    [DataContract]
    public class ApplicationEvent : IEvent
    {
        [JsonIgnore]
        [DataMember]
        public Guid Id { get; set; }

        [JsonIgnore]
        [DataMember]
        public int Version { get; set; }

        [DataMember]
        public DateTimeOffset TimeStamp { get; set; }

        public ApplicationEvent()
        {
            TimeStamp = DateTimeOffset.UtcNow;
        }
    }
}
