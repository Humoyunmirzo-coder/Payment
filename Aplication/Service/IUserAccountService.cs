using Aplication.Repository;
using Domain.Dto;
using Payment.Domain.Enititys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
	public  interface IUserAccountService : IRepository<UserAccount>
 	{
		Task <string> GetUserAccamountAsync (string username);
		Task<IEnumerable<UserAccount>> GetAllAccountAsync();
		Task<UserAccount> GetByIdAsync( int id);
		Task<UserAccount> CreateAsync ( AccountDto user) ;
		
	}
}
