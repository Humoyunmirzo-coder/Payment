﻿using Aplication.Repository;
using Payment.Domain.Enititys;

namespace Aplication.Service
{
	public interface IUserTransactionService : IRepository<UserTransoction>
	{
		Task<IEnumerable<UserTransoction>> GetTransactionsAsync();
		Task<IEnumerable<object>> GetAllTransactionsAsync();
		Task<IEnumerable<object>> GetByIdTransaction(int Id);
	}
}