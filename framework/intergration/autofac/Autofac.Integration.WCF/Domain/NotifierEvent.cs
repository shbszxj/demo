using Autofac.Integration.WCF.Service.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Integration.WCF.Service.Domain
{
    [DataContract]
    public class NotifierEvent : ApplicationEvent
    {
        public NotifierEvent()
        {
            Id = Guid.NewGuid();
            Name = $"Notifier Event {Id}";
        }

        [DataMember]
        public string Name { get; set; }
    }
}
