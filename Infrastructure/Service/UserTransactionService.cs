using Aplication.Service;
using Domain;
using Domain.Dto;
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

		public async Task<UserTransoction> CreateAysnc(UserTransoction account)
		{
		
			var usertransactionEntity = new TransactionDto()
			{
				Result = account.Result,
				Amaunt = account.Amaunt,
				SendorId = account.SendorId,
				CardNumber = account.CardNumber,
				UserAccountId = account.UserAccountId,
				PaymentServise = account.PaymentServise,
				Date = account.Date,
				UserAccountids = account.UserAccounts.Select(x => x.Id).ToList(),

			};
			_dbcontext.SaveChanges();
			return  (usertransactionEntity);


		}

		public Task<UserTransoction> CreateAysnc(TransactionDto transoction)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<UserTransoction>> GetAllAsync()
		{
			_dbcontext.Transactions.AsNoTracking().AsEnumerable();
			return Task.FromResult(Enumerable.Empty<UserTransoction>());
		}

		

		public   async Task<UserTransoction> GetByIdAsync(int Id)
		{
			UserTransoction? entity = await _dbcontext.Transactions.FindAsync(Id);
			return entity;
		}

		async Task<IEnumerable<TransactionDto>> IUserTransactionService.GetAllAsync()
		{
			throw new NotImplementedException();
		}
	}
}
