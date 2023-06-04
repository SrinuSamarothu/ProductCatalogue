using DataService;
using DataService.Entities;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var con = builder.Configuration.GetConnectionString("CatalogueDB");
builder.Services.AddDbContext<ProductCatalogueContext>(options => options.UseSqlServer(con));


builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddScoped<ILogic, Logic>();


var AllowAllPolicy = "AllowAllPolicy";
builder.Services.AddCors(options =>
options.AddPolicy(AllowAllPolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
