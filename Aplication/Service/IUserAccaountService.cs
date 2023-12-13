using Aplication.Repository;
using Payment.Domain.Enititys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
	public  interface IUserAccaountService : IRepository<UserAccount>
 	{
		Task <string> GetUserAccamountAsync (string username);
		Task<IEnumerable<UserAccount>> GetAllAccount();
		Task<IEnumerable<object>> GetById( int id);
		
	}
}
