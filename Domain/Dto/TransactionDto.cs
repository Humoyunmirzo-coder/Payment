using Payment.Domain.Enititys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
	public  class TransactionDto
	{
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public DateTime TransactionDate { get; set; }
		public string Amaunt { get; set; }
		public bool Result { get; set; }
		public double UserAccountId { get; set; }
		public string PaymentServise { get; set; }
		public string SendorId { get; set; }
		public virtual ICollection<UserAccount> UserAccounts { get; set; }
	}
}
