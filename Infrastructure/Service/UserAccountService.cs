using Aplication.Repository;
using Aplication.Service;
using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Enititys;
using Payment.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public class UserAccountService : IUserAccountService
	{
		private readonly ServerDbcontext _dbcontext;

		public UserAccountService( ServerDbcontext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public async Task<UserAccount> CreateAsync(UserAccount user)
		{
			_dbcontext.Users.Attach(user);
			await _dbcontext.SaveChangesAsync();
			return user;
		}

		public async Task<UserAccount> CreateAsync(AccountDto user1)
		{
			throw new NotImplementedException();
			
		}

		public Task<IEnumerable<UserAccount>> GetAllAccountAsync()
		{
			_dbcontext.Users.AsNoTracking().AsEnumerable();
			return Task.FromResult(Enumerable.Empty<UserAccount>());
		}

		public Task<IEnumerable<UserAccount>> GetAllAsync()
		{
			throw new NotImplementedException();
			
		}

		public async Task<UserAccount> GetByIdAsync(int id)
		{
			UserAccount? entity =  await _dbcontext.Users.FindAsync(id);
			return entity;
		}

		public Task<string> GetUserAccamountAsync(string username)
		{
			throw new NotImplementedException();
		}

		Task<UserAccount> IRepository<UserAccount>.GetByIdAsync(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
