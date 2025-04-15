using Domain.Interfaces.Common;

namespace Application.UseCases.Common
{
    public interface IBaseRemoveUseCase<TEntity>
        where TEntity : class, IBase
    {
        Task<bool> Remove(Guid input);
    }

    public class BaseRemoveUseCase<TEntity> : IBaseRemoveUseCase<TEntity>
        where TEntity : class, IBase
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseRemoveUseCase(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Remove(Guid input)
        {
            var response = await _repository.Delete(input);

            if (response != null) return true;
            else return false;
        }
    }
}
