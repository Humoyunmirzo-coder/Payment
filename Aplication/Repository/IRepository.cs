using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repository
{
	public  interface IRepository <T>
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int Id);
	}
}
