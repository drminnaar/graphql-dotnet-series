using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyView.Api.Games;

var builder = WebApplication.CreateBuilder(args);

builder
   .Services
   .AddGraphQLServer() // Adds a GraphQL server configuration to the DI
   .AddMutationType<GamesMutation>() // Add GraphQL root mutation type
   .AddQueryType<GamesQuery>() // Add GraphQL root query type
   .ModifyRequestOptions(options =>
   {
      options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
   });

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapGraphQL("/"); // Adds a GraphQL endpoint to the endpoint configurations

app.Run();
