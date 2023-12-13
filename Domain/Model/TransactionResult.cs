using NBitcoin;

namespace Payment.Domain.Models
{
	public class TransactionResult
	{
		public int AccountNumber { get; set; }
		public bool IsSuccessful { get; set; }
		public Money Balance { get; set; }
		public string Message { get; set; }
	}
}
