using Aplication.Service;
using Domain;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Enititys;

namespace Payment.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly IUserTransactionService _userTransactionService;

		public TransactionController(IUserTransactionService userTransactionService)
		{
			_userTransactionService = userTransactionService;
		}

		[HttpGet] 
		public async Task <ResponsModel<IEnumerable< UserTransoction>>> GetAllAsync()
		{
			IEnumerable<UserTransoction> transoctions = (await _userTransactionService.GetAllAsync())
				.Select(x => new UserTransoction
				{
					Id = x.Id,
					Result = x.Result,
					Amaunt	= x.Amaunt,
					SendorId = x.SendorId,
					CardNumber = x.CardNumber,
					UserAccounts = x.UserAccounts,
					UserAccountId = x.UserAccountId,
					PaymentServise = x.PaymentServise,
					TransactionDate = x.TransactionDate,

				});
			return new ResponsModel<IEnumerable<UserTransoction>>( transoctions);
		}
		[HttpGet ]
		public async Task <ResponsModel <UserTransoction>> GetByIdAsync(int Id)
		{
			UserTransoction transoction = await _userTransactionService.GetByIdAsync(Id);
			var transactionEntity = new UserTransoction
			{
				Id = transoction.Id,
				Result = transoction.Result,
				Amaunt = transoction.Amaunt,
				SendorId = transoction.SendorId,
				CardNumber = transoction.CardNumber,
				UserAccounts = transoction.UserAccounts,
				UserAccountId = transoction.UserAccountId,
				PaymentServise = transoction.PaymentServise,
				TransactionDate = transoction.TransactionDate,

			};
			return new(transactionEntity);
		}

		[HttpPost]
		public async Task<ResponsModel<UserTransoction>> CreateAsync(UserTransoction user)
		{
			UserTransoction account = await _userTransactionService.CreateAysnc(user);
			var usertransactionEntity = new UserTransoction()
			{
				Id= account.Id,
				Result= account.Result,
				Amaunt = account.Amaunt,
				SendorId= account.SendorId,
				CardNumber= account.CardNumber,
				UserAccounts = account.UserAccounts,
				UserAccountId = account.UserAccountId,
				PaymentServise = account.PaymentServise,
				TransactionDate = account.TransactionDate,
			
			};
			return new(usertransactionEntity);

		}
	}
}
