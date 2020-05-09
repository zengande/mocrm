using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YunStorm.MoCRM.BuildingBlocks.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
