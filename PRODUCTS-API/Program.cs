using PRODUCTS_API.Models;
using PRODUCTS_API.Repository;
using PRODUCTS_API.Tools;

var builder = WebApplication.CreateBuilder(args);

var RulesCors = "RulesCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: RulesCors,
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IRepository, Repository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(RulesCors);
cServer.Initialize(builder.Environment, builder.Configuration);
app.UseAuthorization();
app.MapControllers();
app.Run();