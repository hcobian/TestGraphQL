using GraphQL;
using GraphQL.Types;

namespace TestGraphQL.GraphQL
{

    public partial class AppMutations : ObjectGraphType
    {
        public AppMutations(ReviewMessageService messageService)
        {
            Name = "AppMutations";

            Field<StringGraphType>("exampleMutation")
                .Resolve(context =>
                {
                    return "exampleMutation Response";
                });

            Field<UserType>("addUser")
                .Arguments(new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInput>> { Name = "user" })
                )
                .Resolve(context =>
                 {
                     var user = context.GetArgument<User>("user");

                     user.Address = new Address { Street = "" };
                     user.CreatedAt = DateTime.UtcNow;
                     user.Id = 1;
                     return user;
                 });

            Field<ProductReviewType>("createReview")
                .Arguments(new QueryArguments(
                        new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" })
                 )
                .Resolve(context =>
                 {
                     var review = context.GetArgument<ProductReview>("review");
                     messageService.AddReviewAddedMessage(review);
                     return review;
                 });
        }
    }
}
