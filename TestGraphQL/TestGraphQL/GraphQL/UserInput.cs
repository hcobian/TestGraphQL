using GraphQL.Types;

namespace TestGraphQL.GraphQL
{
    public class UserInput : InputObjectGraphType<User>
    {
        public UserInput()
        {
            Name = "UserInput";
            Field(_ => _.FirstName);
            Field(_ => _.LastName, nullable : true);
        }
    }
}
