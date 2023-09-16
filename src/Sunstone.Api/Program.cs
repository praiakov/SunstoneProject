using Microsoft.EntityFrameworkCore;
using Sunstone.Application;
using Sunstone.Domain;
using Sunstone.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICreateGemstoneUseCase, CreateGemstoneUseCase>();
builder.Services.AddScoped<IGetGemstoneListUseCase, GetGemstoneUseCase>();
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SunstoneInMemoryContext>(o =>
{
    o.UseInMemoryDatabase("SunstoneDb");
});

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
