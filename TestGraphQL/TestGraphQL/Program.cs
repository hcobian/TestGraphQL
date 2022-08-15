using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using TestGraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ISchema, AppSchema>(
    services => new AppSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddHttpContextAccessor();

//register graphQL
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
})
.AddErrorInfoProvider(
    opt => opt.ExposeExceptionStackTrace = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
.AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground("/graphql/playground");

app.Run();
