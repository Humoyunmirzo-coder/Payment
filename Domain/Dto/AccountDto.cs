using Payment.Domain.Enititys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
	public  class AccountDto
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }

		public required ICollection<UserTransoction> UserTransoctions { get; set; }
	}
}
