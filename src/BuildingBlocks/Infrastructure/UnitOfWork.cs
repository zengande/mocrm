using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YunStorm.MoCRM.BuildingBlocks.Domain;

namespace YunStorm.MoCRM.BuildingBlocks.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public abstract void Dispose();

        public abstract Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(_dbContext);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
