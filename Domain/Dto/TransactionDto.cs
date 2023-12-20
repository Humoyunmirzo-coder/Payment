using Payment.Domain.Enititys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
	public  class TransactionDto
	{
		
		public double UserAccountId { get; set; }
		public string SendorId { get; set; }
		public bool Result { get; set; }
		public string Amaunt { get; set; }
		public string CardNumber { get; set; }
		public string PaymentServise { get; set; }
		public DateTime DateTime { get; set; } 

		public virtual  ICollection<int> UserAccountids { get; set; }
	}
}
