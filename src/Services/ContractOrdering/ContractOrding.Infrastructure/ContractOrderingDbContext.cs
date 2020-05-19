using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YunStorm.MoCRM.BuildingBlocks.Domain;
using YunStorm.MoCRM.BuildingBlocks.Infrastructure;
using YunStorm.MoCRM.ContractOrdering.Domain.Entities;

namespace YunStorm.MoCRM.ContractOrding.Infrastructure
{
    public class ContractOrderingDbContext
        : DbContext, IUnitOfWork
    {

        public DbSet<ContractOrder> ContractOrders { get; set; }
        public DbSet<ContractProduct> ContractProducts { get; set; }
        public DbSet<ContractToDo> ContractToDoList { get; set; }
        public DbSet<ContractStatus> ContractStatus { get; set; }
        public DbSet<PaymentMethod> Payments { get; set; }

        private IMediator _mediator;
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public ContractOrderingDbContext(DbContextOptions<ContractOrderingDbContext> options) : base(options) { }
        public ContractOrderingDbContext(DbContextOptions<ContractOrderingDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(cancellationToken);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
