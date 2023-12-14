using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Payment.Domain.Enititys
{
	public class UserTransoction
	{

		[Key]
		public int Id { get; set; }
		public string CardNumber { get; set; }
		public DateTime Date { get; set; } 

		public string Amaunt { get; set; }
		public bool Result { get; set; }
		public double  UserAccountId { get; set; }
		public string PaymentServise { get; set; }
		public string SendorId { get; set; }

		[JsonIgnore]
		public virtual ICollection<UserAccount> UserAccounts { get; set; }


	}
}
