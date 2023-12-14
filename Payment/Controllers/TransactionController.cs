using Aplication.Service;
using Domain;
using Domain.Dto;
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
		public async Task <ResponsModel<IEnumerable< TransactionDto>>> GetAllAsync()
		{
			IEnumerable<TransactionDto> transoctions = (await _userTransactionService.GetAllAsync())
				.Select(x => new TransactionDto
				{
				
					Result = x.Result,
					Amaunt	= x.Amaunt,
					SendorId = x.SendorId,
					CardNumber = x.CardNumber,
					UserAccounts = x.UserAccounts,
					UserAccountId = x.UserAccountId,
					PaymentServise = x.PaymentServise,
				    Date = x.Date,

				});
			return new( transoctions);
		}
		[HttpGet ]
		public async Task <ResponsModel <TransactionDto>> GetByIdAsync(int Id)
		{
			UserTransoction transoction = await _userTransactionService.GetByIdAsync(Id);
			var transactionEntity = new TransactionDto
			{
			
				Result = transoction.Result,
				Amaunt = transoction.Amaunt,
				SendorId = transoction.SendorId,
				CardNumber = transoction.CardNumber,
				UserAccounts = transoction.UserAccounts,
				UserAccountId = transoction.UserAccountId,
				PaymentServise = transoction.PaymentServise,
				Date = transoction.Date,
			

			};
			return new(transactionEntity);
		}

		[HttpPost]
		public async Task<ResponsModel<TransactionDto>> CreateAsync(TransactionDto user)
		{
			UserTransoction account = await _userTransactionService.CreateAysnc(user);
			var usertransactionEntity = new TransactionDto()
			{
				Result= account.Result,
				Amaunt = account.Amaunt,
				SendorId= account.SendorId,
				CardNumber= account.CardNumber,
				UserAccounts = account.UserAccounts,
				UserAccountId = account.UserAccountId,
				PaymentServise = account.PaymentServise,
				Date = account.Date 

			};
			return new(usertransactionEntity);

		}
	}
}
