using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismEventAggregatorDemo.Core.Events
{
    public class MessageSentEvent : PubSubEvent<string>
    {
    }
}
