using AutoMapper;
using MarkMyFinance.Application;
using MarkMyFinance.Persistance;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		// Services from Application layer
		IMapper mapper = MapperRegistration.RegisterMapper().CreateMapper();
		builder.Services.AddSingleton(mapper);

		builder.Services.AddServices();

		// Repository from Persistance layer
		builder.Services.AddRepository();
		builder.Services.AddDbService();

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