using AutoMapper;
using Domain.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Common
{
    public interface IBaseSearchUseCase<TEntity, TOutput>
        where TEntity : class, IBase
        where TOutput : class
    {
        Task<ICollection<TOutput>> SearchAll();
        Task<TOutput> SearchById(Guid input);
    }

    public class BaseSearchUseCase<TEntity, TOutput> : IBaseSearchUseCase<TEntity, TOutput>
        where TEntity : class, IBase
        where TOutput : class
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;

        public BaseSearchUseCase(IMapper mapper, IBaseRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<TOutput>> SearchAll()
        {
            var response = await _repository.Query().ToListAsync();
            return _mapper.Map<List<TOutput>>(response);
        }

        public async Task<TOutput> SearchById(Guid input)
        {
            var response = await _repository.GetAsNoTraking(input);
            return _mapper.Map<TOutput>(response);
        }
    }
}
