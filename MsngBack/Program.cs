using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MsngBack.DataLayer.Db;
using MsngBack.DataLayer.IContext;
using MsngBack.DataLayer.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MacOs")));

builder.Services.AddSingleton<IUserContext, InMemoryUserContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    try
    {
        Console.WriteLine($"Request to: {context.Request.Path}");
        await next();
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("--- Exception ---");
        Console.WriteLine(e);
        Console.WriteLine("-----------------");
        Console.ResetColor();
    }
});

app.MapControllers();

app.MapPost("/TestConnection",
        (int number) => Results.Ok(number * 2))
    .WithName("Test")
    .WithOpenApi();

app.Run();