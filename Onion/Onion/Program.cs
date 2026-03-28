using Onion.Api.Endpoints;
using Onion.Api.Middlewares;
using Onion.Application;
using Onion.Infastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfastructure(builder.Configuration);

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ErrorHandleMiddleware>();

app.AddMaintEndpoints();

app.Run();