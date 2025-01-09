using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();