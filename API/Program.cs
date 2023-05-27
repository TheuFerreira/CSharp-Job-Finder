using API.Repositories;
using API.Repositories.Interfaces;
using System.Data;
using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "*");
            policy.AllowAnyHeader();
        });
});

// Add services to the container.

string currentDir = AppDomain.CurrentDomain.BaseDirectory;
string connectionString = $"Data Source={currentDir}\\app.db";
IDbConnection connection = new SQLiteConnection(connectionString);

builder.Services.AddSingleton<IDbConnection>(connection);
builder.Services.AddTransient<IJobRepository, JobRepository>();

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

app.UseCors();

app.Run();
