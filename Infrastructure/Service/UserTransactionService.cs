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

		public async Task<UserTransoction> CreateAysnc(TransactionDto account)
		{

			UserTransoction usertransactionEntity = new UserTransoction()
			{
				Result = account.Result,
				Amaunt = account.Amaunt,
				SendorId = account.SendorId,
				CardNumber = account.CardNumber,
				UserAccountId = account.UserAccountId,
				PaymentServise = account.PaymentServise,
			    Date = account.DateTime = DateTime.UtcNow,
// UserAccounts = account.UserAccountids.Select (x=>x).ToList(),
				

			};
			_dbcontext.Add(usertransactionEntity);
			 _dbcontext.SaveChanges();
			return  (usertransactionEntity);


		}


		public async Task<IEnumerable<UserTransoction>> GetAllAsync()
		{
			return   await  _dbcontext.Transactions.ToListAsync();
		}

		

		public   async Task<UserTransoction> GetByIdAsync(int Id)
		{
			UserTransoction? entity = await _dbcontext.Transactions.FindAsync(Id);
			return entity;




		}

	
	}
}
