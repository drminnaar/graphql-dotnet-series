using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyView.Api.Data;
using MyView.Api.Errors;
using MyView.Api.Games;
using MyView.Api.Reviewers;

var builder = WebApplication.CreateBuilder(args);

// configure in-memory database
builder
   .Services
   .AddDbContextFactory<AppDbContext>(options =>
   {
      options.UseInMemoryDatabase("myview");
      options.EnableDetailedErrors(builder.Environment.IsDevelopment());
      options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
   });

builder
   .Services
   .AddScoped<AppDbContext>(provider => provider
      .GetRequiredService<IDbContextFactory<AppDbContext>>()
      .CreateDbContext());

// configure other services
builder
   .Services
   .AddScoped<AbstractValidator<GameReviewDto>, GameReviewValidator>();

// configure GraphQL service
builder
   .Services
   .AddGraphQLServer() // Adds a GraphQL server configuration to the DI
   .AddErrorFilter(provider =>
      {
         return new ServerErrorFilter(
            provider.GetRequiredService<ILogger<ServerErrorFilter>>(),
            builder.Environment);
      })
   .AddMutationType<GamesMutation>() // Add GraphQL root mutation type
   .AddQueryType() // Add GraphQL root query type
      .AddTypeExtension<GamesQuery>()
      .AddTypeExtension<ReviewerQuery>()
   .AddProjections()
   .AddFiltering()
   .AddSorting()
   .ModifyRequestOptions(options =>
   {
      options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
   });

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapGraphQL("/"); // Adds a GraphQL endpoint to the endpoint configurations

await Seeder.SeedDatabase(app);

app.Run();
