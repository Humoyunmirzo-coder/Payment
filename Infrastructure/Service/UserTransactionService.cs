using Aplication.Service;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Enititys;
using Payment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public class UserTransactionService : IUserTransactionService
	{
		private readonly ServerDbcontext _dbcontext;

		public UserTransactionService(ServerDbcontext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public  async Task<UserTransoction> CreateAysnc(UserTransoction transoction)
		{
			 _dbcontext.Transactions.Attach(transoction);
			await _dbcontext.SaveChangesAsync();
			return transoction;
		}

		public Task<IEnumerable<UserTransoction>> GetAllAsync()
		{
			_dbcontext.Transactions.AsNoTracking().AsEnumerable();
			return Task.FromResult(Enumerable.Empty<UserTransoction>());
		}

		public Task<IEnumerable<object>> GetAllTransactionsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<UserTransoction> GetByIdAsync(int Id)
		{
			UserTransoction? entity = await  _dbcontext.Transactions.FindAsync(Id);
			return entity;
		}

		public Task<IEnumerable<object>> GetByIdTransaction(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserTransoction>> GetTransactionsAsync()
		{
			throw new NotImplementedException();
		}
	}
}
