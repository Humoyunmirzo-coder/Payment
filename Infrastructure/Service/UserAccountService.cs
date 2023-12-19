using Aplication.Repository;
using Aplication.Service;
using Domain;
using Domain.Dto;
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
			 return await  _dbcontext.Users.ToListAsync();

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

	
	

		public async Task<UserAccount> CreateAsync(AccountDto user)
		{
			 var  result = new AccountDto()
			{

				UserId = user.UserId,
				CardNamber = user.CardNamber,
				CardValidData = user.CardValidData,
				TotalBalance = user.TotalBalance,
			UserTransoctionids = user.UserTransoctionids.Select(x =>x).ToList(),
			};
		
			 _dbcontext.Add(user);
			await _dbcontext.SaveChangesAsync();
			return  new() ;
		}
	}
}
