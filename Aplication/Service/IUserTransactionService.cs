using Aplication.Repository;
using Domain;
using Domain.Dto;
using Payment.Domain.Enititys;

namespace Aplication.Service
{
	public interface IUserTransactionService : IRepository<UserTransoction>
	{
		Task<UserTransoction> CreateAysnc( TransactionDto transoction);
		Task<IEnumerable<UserTransoction>> GetAllAsync();
		Task<UserTransoction> GetByIdAsync(int id);
	}
}
