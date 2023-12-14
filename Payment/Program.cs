
using Aplication.Service;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Enititys;
using Payment.Infrastructure.Data;

namespace Payment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IUserAccountService , UserAccountService>();
			builder.Services.AddScoped<IUserTransactionService , UserTransactionService>();
			builder.Services.AddDbContext<ServerDbcontext>(options =>
		options.UseNpgsql(builder.Configuration.GetConnectionString("AZServicesConfugretion")));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}