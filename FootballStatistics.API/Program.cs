using FootballStatistics.Application.Commands.CreateUser;
using FootballStatistics.Core.Repositories;
using FootballStatistics.Infrastructure.Persistence;
using FootballStatistics.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<CreateUserCommand>());

builder.Services.AddScoped<IUserRepository,UserRepository>();

var conectionString = builder.Configuration.GetConnectionString("FootBallStatisticsCs");
builder.Services.AddDbContext<FootballStatisticsDbContext>(options => options.UseSqlServer(conectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
