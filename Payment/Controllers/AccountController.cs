using Aplication.Service;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Enititys;

namespace Payment.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : Controller
	{
		private readonly IUserAccountService _userAccountService;

		public AccountController(IUserAccountService userAccountService) =>
			_userAccountService = userAccountService;


		[HttpGet]
		public async Task<ResponsModel<IEnumerable<AccountDto>>> GetAllAsync()
		{
			IEnumerable<AccountDto> userAccounts = (await _userAccountService.GetAllAsync())
				   .Select(x => new AccountDto
				   {
					   Id = x.Id,
					   UserId = x.UserId,
					   CardNamber = x.CardNamber,
					   CardValidData = x.CardValidData,
					   TotalBalance = x.TotalBalance,
					   UserTransoctionids = x.UserTransoctions.Select(x => x.Id).ToList(),

				   });
			var result = await _userAccountService.GetAllAsync();
			return new ("Ok");
		}
		[HttpGet]
		public async Task<ResponsModel<AccountDto>> GetByIdAsync(int Id)
		{
			UserAccount userAccount = await _userAccountService.GetByIdAsync(Id);
			var userAccountEntity = new AccountDto()
			{
				Id = userAccount.Id,
				UserId = userAccount.UserId,
				CardNamber = userAccount.CardNamber,
				CardValidData = userAccount.CardValidData,
				TotalBalance = userAccount.TotalBalance,
				UserTransoctionids = userAccount.UserTransoctions.Select(x => x.Id).ToList(),

			};
			var resul = await _userAccountService.GetByIdAsync(Id);
			return new("Ok");
		}

		[HttpPost]
		public async Task<ResponsModel<UserAccount>> CreateAsync(AccountDto user)
		{
			var userAccountEntity = new UserAccount()
			{
				UserId = user.UserId,
				CardNamber = user.CardNamber,
				CardValidData = user.CardValidData,
				TotalBalance = user.TotalBalance,
			};
			var result = await _userAccountService.CreateAsync(userAccountEntity);
			return new("Ok");
		}
	}
}
