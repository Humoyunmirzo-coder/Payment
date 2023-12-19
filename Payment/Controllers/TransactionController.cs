using Aplication.Service;
using Domain;
using Domain.Dto;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Enititys;
using Payment.Infrastructure.Data;

namespace Payment.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly IUserTransactionService _userTransactionService;
		private readonly ServerDbcontext _serverDbcontext;

		public TransactionController(IUserTransactionService userTransactionService, ServerDbcontext serverDbcontext)
		{
			_userTransactionService = userTransactionService;
			_serverDbcontext = serverDbcontext;
		}

		[HttpGet] 
		public async Task <IEnumerable< UserTransoction>> GetAllAsync()
		{
			var result = await  _userTransactionService.GetAllAsync();

			return result;
		}
		[HttpGet ]
		public async Task  <UserTransoction> GetByIdAsync(int Id)
		{

			var resul = await _userTransactionService.GetByIdAsync(Id);
			return resul;
		}

		[HttpPost]
		public async Task<TransactionDto> CreateAsync(TransactionDto user)
		{

			await _userTransactionService.CreateAysnc(user);
			await   _serverDbcontext.SaveChangesAsync();
		
				return  user;

		}
	}
}
