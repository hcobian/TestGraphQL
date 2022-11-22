using GraphQL.Types;

namespace TestGraphQL.GraphQL
{
    public class UserInput : InputObjectGraphType<User>
    {
        public UserInput()
        {
            Name = "UserInput";
            Description = "this is the description for UserInput";
            Field(_ => _.FirstName).Description("this is the description for FirstName");
            Field(_ => _.LastName, nullable : true).Description("this is the description for LastName");
        }
    }
}
