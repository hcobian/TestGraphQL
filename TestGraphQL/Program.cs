using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using TestGraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ReviewMessageService>();
builder.Services.AddSingleton<ISchema, AppSchema>(services 
    => new AppSchema(new SelfActivatingServiceProvider(services))
);

builder.Services.AddHttpContextAccessor();

//register graphQL
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Schema>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseWebSockets();
app.UseGraphQL("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/graphql/playground",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });
await app.RunAsync();
