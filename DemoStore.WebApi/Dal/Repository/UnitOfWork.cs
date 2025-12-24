using DemoStore.WebApi;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoStore.WebApi
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DemoStoreDbDataContext _context;
        private readonly IServiceProvider _provider;

        public UnitOfWork(DemoStoreDbDataContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _provider.GetRequiredService<IRepository<TEntity>>();
        }

        public async Task<IUnitOfTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            return new UnitOfTransaction(transaction);
        }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}