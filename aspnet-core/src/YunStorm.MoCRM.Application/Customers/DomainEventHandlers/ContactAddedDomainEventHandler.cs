using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus;
using YunStorm.MoCRM.Customers.Events;

namespace YunStorm.MoCRM.Customers.DomainEventHandlers
{
    public class ContactAddedDomainEventHandler : ILocalEventHandler<ContactAddedDomainEvent>
    {
        private readonly ILogger<ContactAddedDomainEventHandler> _logger;
        public ContactAddedDomainEventHandler(ILogger<ContactAddedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleEventAsync(ContactAddedDomainEvent eventData)
        {

            _logger.LogDebug("domain event ContactAdded triggered!");
            return Task.CompletedTask;
        }
    }
}
