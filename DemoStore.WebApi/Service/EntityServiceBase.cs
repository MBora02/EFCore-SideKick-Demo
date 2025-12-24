using DemoStore.WebApi;

using AutoMapper;
namespace DemoStore.WebApi
{
    public abstract class EntityServiceBase<TDto, TEntity, TKey>
        : IEntityServiceBase<TDto, TEntity, TKey>
        where TEntity : class
        where TDto : class
        where TKey : notnull
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly ILogger<EntityServiceBase<TDto, TEntity, TKey>> _logger;

        public EntityServiceBase(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitOfWork = unitofWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
            _mapper = mapper;
        }

        public EntityServiceBase(IUnitOfWork unitofWork, IMapper mapper, ILogger<EntityServiceBase<TDto, TEntity, TKey>> logger)
        {
            _unitOfWork = unitofWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<bool> AddAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity, cancellationToken);

            var affectd = await _unitOfWork.SaveChangeAsync(cancellationToken);

            return affectd > 0;
        }

        public virtual async Task<bool> AddRangeAsync(
            IEnumerable<TDto> dtos, CancellationToken cancellationToken = default)
        {
            var entities = new List<TEntity>();
            foreach (var dto in dtos)
            {
                entities.Add(_mapper.Map<TEntity>(dto));
            }

            await _repository.AddRangeAsync(entities, cancellationToken);

            var affectd = await _unitOfWork.SaveChangeAsync(cancellationToken);

            return affectd > 0;
        }

        public virtual async Task<bool> DeleteAsync(TKey key, CancellationToken cancellationToken = default)
        {
            if (key is object[] keys)
            {
                await _repository.DeleteAsync(keys, cancellationToken);
            }
            else
            {
                await _repository.DeleteAsync(new object[] { key }, cancellationToken);
            }

            var affectd = await _unitOfWork.SaveChangeAsync(cancellationToken);

            return affectd > 0;
        }

        public virtual async Task<bool> UpdateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            _repository.Update(_mapper.Map<TEntity>(dto));

            var affectd = await _unitOfWork.SaveChangeAsync(cancellationToken);

            return affectd > 0;
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default)
        {
            var entities = new List<TEntity>();
            foreach (var dto in dtos)
            {
                entities.Add(_mapper.Map<TEntity>(dto));
            }

            _repository.UpdateRange(entities);

            var affectd = await _unitOfWork.SaveChangeAsync(cancellationToken);

            return affectd > 0;
        }

        public virtual async Task<TDto?> GetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            if (key is object[] keys)
            {
                var entity = await _repository.FindAsync(keys, cancellationToken);
                return _mapper.Map<TDto>(entity);
            }
            else
            {
                var entity = await _repository.FindAsync(new object[] { key }, cancellationToken);
                return _mapper.Map<TDto>(entity);
            }
        }

        public virtual async Task<IEnumerable<TDto>> GetListAsync(CancellationToken cancellationToken = default)
        {
            var results = await _repository.GetListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TDto>>(results);
        }

        public virtual async Task<PagedResult<TDto>> GetPageAsync(
            PageParameter parameter, CancellationToken cancellationToken = default)
        {
            var result = new PagedResult<TDto>();

            result.Total = await _repository.CountAsync(cancellationToken);

            var results = await _repository.GetListAsync(parameter, cancellationToken);

            result.Data = _mapper.Map<IEnumerable<TDto>>(results);

            return result;
        }

        public virtual Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return _repository.CountAsync(cancellationToken);
        }
    }
}
