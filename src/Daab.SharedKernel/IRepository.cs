using System.Linq.Expressions;

namespace Daab.SharedKernel;

public interface IRepository<TEntity>
{
    ValueTask InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        CancellationToken cancellationToken = default
    );
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
