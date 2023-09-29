using FeautureManagementDemo;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Configuration.AddAzureAppConfiguration(connectionString);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("FeatureFlagsPOC:Settings"));
var app = builder.Build();

// Configure the HTTP request pipeline. // Enabled in any environment
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
