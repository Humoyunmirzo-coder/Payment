using Aplication.Repository;
using Aplication.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Payment.Domain.Enititys;
using Payment.Infrastructure.Data;

namespace Infrastructure.Service
{
	public class UserAccountService : IUserAccountService
	{
		private readonly ServerDbcontext _dbcontext;

		public UserAccountService(ServerDbcontext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public Task<IEnumerable<UserAccount>> GetAllAccountAsync()
		{
			_dbcontext.Users.AsNoTracking().AsEnumerable();
			return Task.FromResult(Enumerable.Empty<UserAccount>());
		}

		public async  Task<IEnumerable<UserAccount>> GetAllAsync()
		 {

			return await  GetAllAsync();  //  Task.FromResult(Enumerable.Empty<UserAccount>());

		}

		public async Task<UserAccount> GetByIdAsync(int id)
		{
			UserAccount? entity = await _dbcontext.Users.FindAsync(id);
			return entity;
		}

		public Task<string> GetUserAccamountAsync(string username)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CreateAsync(UserAccount user)
		{
			_dbcontext.Users.Attach(user);
			await _dbcontext.SaveChangesAsync();
			return user != null ? true : false;
		}

		Task<UserAccount> IRepository<UserAccount>.GetByIdAsync(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
