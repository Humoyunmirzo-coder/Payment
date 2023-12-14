using Aplication.Service;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Enititys;

namespace Payment.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserAccountService _userAccountService;

		public AccountController(IUserAccountService userAccountService)
		{
			_userAccountService = userAccountService;
		}
			
		[HttpGet]
		public async Task <ResponsModel<IEnumerable< UserAccount>>> GetAllAsync()
		{
			IEnumerable<UserAccount> userAccounts = (await _userAccountService.GetAllAsync())
				   .Select(x => new UserAccount
				   {
					   Id = x.Id,
					   UserId = x.UserId,
					   CardNamber = x.CardNamber,
					   CardValidData = x.CardValidData,
					   TotalBalance = x.TotalBalance,
					   UserTransoctions = x.UserTransoctions,

				   });
			return  new  (userAccounts);
		}
		[HttpGet]
		public async Task<ResponsModel<UserAccount>> GetByIdAsync( int Id) 
		{
			UserAccount userAccount = await  _userAccountService.GetByIdAsync(Id);
			var userAccountEntity = new UserAccount()
			{
				Id = userAccount.Id,
				UserId = userAccount.UserId,
				CardNamber = userAccount.CardNamber,
				CardValidData = userAccount.CardValidData,
				TotalBalance = userAccount.TotalBalance,
				UserTransoctions = userAccount.UserTransoctions,

			};
			return new (userAccountEntity);
		}

		[HttpPost] 
		public async Task < ResponsModel < UserAccount >> CreateAsync( UserAccount user)
		{
			UserAccount account = await _userAccountService.CreateAsync(user);
			var userAccountEntity = new UserAccount()
			{
				Id = account.Id,
				UserId = account.UserId,
				CardNamber = account.CardNamber,
				CardValidData = account.CardValidData,
				TotalBalance = account.TotalBalance,
				UserTransoctions = account.UserTransoctions
			};	
			return  new  (userAccountEntity);

		}

	}
}
