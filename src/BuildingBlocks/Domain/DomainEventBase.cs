using System;
using System.Collections.Generic;
using System.Text;

namespace YunStorm.MoCRM.BuildingBlocks.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public DomainEventBase()
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
