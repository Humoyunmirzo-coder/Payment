using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.Domain.Enititys
{
	public class UserTransoction
	{

		[Key]
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public string TransactionDate { get; set; }
		public string Amaunt { get; set; }
		public bool Result { get; set; }
		public double  UserAccountId { get; set; }
		public string AaymentServise { get; set; }
		public string SendorId { get; set; }

		public virtual ICollection<UserAccount> UserAccounts { get; set; }


	}
}
