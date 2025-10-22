using VB.BookStore.Api.Extensions;
using VB.BookStore.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ResolveDependencies(builder.Configuration);

var app = builder.Build();

app.UseGraphQlConfiguration();

app.UseHttpsRedirection();

app.Run();
