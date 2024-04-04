using ESourcing.Order.Extensions;
using Ordering.Infrastructure;
using Ordering.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
//builder.Services.AddInfrastructure();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase();
app.Run();
