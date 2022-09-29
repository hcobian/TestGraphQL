using GraphQL.Types;

namespace TestGraphQL.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQueries>();
            Mutation = serviceProvider.GetRequiredService<AppMutations>();
            Subscription = serviceProvider.GetRequiredService<AppSubscriptions>();
        }
    }
}
