using AutoMapper;
using Domain.Interfaces.Common;

namespace Application.UseCases.Common
{
    public interface IBaseManageUseCase<TEntity, TInput, TOutput>
        where TEntity : class, IBase
        where TInput : class
        where TOutput : class
    {
        Task<TOutput> Create(TInput input);
        Task<TOutput> Update(TInput input, Guid id);
    }

    public class BaseManageUseCase<TEntity, TInput, TOutput> : IBaseManageUseCase<TEntity, TInput, TOutput>
        where TEntity : class, IBase
        where TInput : class
        where TOutput : class
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;

        public BaseManageUseCase(IMapper mapper, IBaseRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TOutput> Create(TInput input)
        {
            var entity = _mapper.Map<TEntity>(input);
            var response = await _repository.Add(entity);

            return _mapper.Map<TOutput>(response);
        }

        public async Task<TOutput> Update(TInput input, Guid id)
        {
            var entity = _mapper.Map<TEntity>(input);
            entity.Id = id;

            var response = await _repository.Update(entity);

            return _mapper.Map<TOutput>(response);
        }
    }
}
