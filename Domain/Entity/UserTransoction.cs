using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Enititys
{
	public  class UserTransoction
	{

		[Key]
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public string TransactionDate { get; set; }
		public string Amaunt { get; set; }
		public bool Result { get; set; }
		public UserAccount UserAccountId { get; set; }
		public string AaymentServise { get; set; }
		public string SendorId { get; set; }
		public ICollection<UserAccount> UserAccounts { get; set; }


	}
}
