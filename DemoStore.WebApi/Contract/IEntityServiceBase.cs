using DemoStore.WebApi;

namespace DemoStore.WebApi
{
    public interface IEntityServiceBase<TDto, TEntity, TKey> where TEntity : class where TDto : class
    {
        Task<bool> AddAsync(TDto dto, CancellationToken cancellationToken = default);

        Task<bool> AddRangeAsync(
            IEnumerable<TDto> dtos, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(TKey key, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(TDto dto, CancellationToken cancellationToken = default);

        Task<bool> UpdateRangeAsync(
            IEnumerable<TDto> dtos, CancellationToken cancellationToken = default);

        Task<TDto?> GetAsync(TKey key, CancellationToken cancellationToken = default);

        Task<IEnumerable<TDto>> GetListAsync(CancellationToken cancellationToken = default);

        Task<PagedResult<TDto>> GetPageAsync(
            PageParameter parameter, CancellationToken cancellationToken = default);

        Task<int> CountAsync(CancellationToken cancellationToken = default);
    }
}
