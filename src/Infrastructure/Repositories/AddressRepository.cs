using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class AddressRepository : BaseRepository<Address> , IAddressRepository
    {
        public AddressRepository(IPracticePackDbContext context)
            : base(context)
        {
            
        }
    }
}
