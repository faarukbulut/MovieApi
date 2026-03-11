using MovieApi.Persistence.Context;
using MovieApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>();

builder.Services.AddApplicationServices().AddIdentityServices().AddMediatorServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
