using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Payment.Domain.Enititys
{
	public class UserAccount
	{
		[Key]
		public int Id { get; set; }
		public string UserId { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }

	[JsonIgnore]
	 	public virtual ICollection<UserTransoction> UserTransoctions { get; set; }
	}
}
