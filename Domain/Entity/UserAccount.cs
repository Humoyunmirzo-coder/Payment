using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.Domain.Enititys
{
	public class UserAccount
	{
		[Key]
		public int Id { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }
		
		public virtual ICollection<UserTransoction> UserTransoctions { get; set; }
	}
}
