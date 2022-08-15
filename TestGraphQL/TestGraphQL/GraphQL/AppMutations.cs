using GraphQL;
using GraphQL.Types;

namespace TestGraphQL.GraphQL
{

    public partial class AppMutations : ObjectGraphType
    {
        public AppMutations()
        {
            Name = "AppMutations";

            Field<StringGraphType>(
                "exampleMutation",
                resolve:
                    context =>
                    {
                        return "exampleMutation Response";
                    }
            );

            Field<UserType>(
                "addUser",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInput>> { Name = "user" }
                    ),
                resolve:
                    context =>
                    {
                        var user = context.GetArgument<User>("user");

                        user.Address = new Address { Street = "" };
                        user.CreatedAt = DateTime.UtcNow; 
                        user.Id = 1;    
                        return user;
                    }
            );
        }
    }
}
