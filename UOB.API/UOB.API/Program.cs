using Microsoft.EntityFrameworkCore;
using UOB.API.Middlewares;
using UOB.Repository;
using UOB.Repository.EF.Context;
using UOB.Services;

var builder = WebApplication.CreateBuilder(args);

//Added connection string config for DbContext
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddServiceDependencies();
builder.Services.AddRepositoryDependencies();

//Add cors policty
builder.Services.AddCustomCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Adding middlewares
app.UseExceptionHandlingMiddleware();

//Register cors
app.UseCors("AllowAll");
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
