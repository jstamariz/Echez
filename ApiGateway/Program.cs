using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddOcelot();

var app = builder.Build();

app.UseCors(static x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .DisallowCredentials()
);

await app.UseOcelot();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();