using ASP.NET.Core.Service.RabbitMQBus.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Core.Service.RabbitMQBus.CustomEvent
{
    public class NinjaKilledChangedEvent:IntegrationEvent
    {
        public int NinjaId { get; private set; }

        public int NewKilled { get; private set; }

        public int OldKilled { get; private set; }

        public NinjaKilledChangedEvent(int ninjaId, int newKilled, int oldKilled)
        {
            NinjaId = ninjaId;
            NewKilled = newKilled;
            OldKilled = oldKilled;
        }
    }
}
