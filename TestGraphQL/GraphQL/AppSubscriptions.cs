
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace TestGraphQL.GraphQL
{

    public partial class AppSubscriptions : ObjectGraphType
    {
        
        public AppSubscriptions(ReviewMessageService messageService)
        {
            Name = "AppSubscriptions";

            Field<ReviewAddedMessageType>("reviewAdded")
                .Resolve(c => c.Source as ReviewAddedMessage)
                .ResolveStream(c => messageService.GetMessages());
        }
    }
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream = new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(ProductReview review)
        {
            var message = new ReviewAddedMessage
            {
                ProductId = review.ProductId,
                Title = review.Title,
            };
            _messageStream.OnNext(message);
            return message;
        }
            
        public IObservable<ReviewAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
    public class ReviewAddedMessage
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
    }

    public class ProductReview
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
    }

    public class ReviewAddedMessageType : ObjectGraphType<ReviewAddedMessage>
    {
        public ReviewAddedMessageType()
        {
            Name = "ReviewAddedMessageType";
            Field(_ => _.ProductId, nullable: true);
            Field(_ => _.Title, nullable: true);
        }
    }

    public class ProductReviewInputType : InputObjectGraphType<ProductReview>
    {
        public ProductReviewInputType()
        {
            Name = "ProductReviewInput";
            Field(_ => _.ProductId, nullable: true);
            Field(_ => _.Title, nullable: true);
        }
    }

    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Name = "ProductReviewType";
            Field(_ => _.ProductId, nullable: true);
            Field(_ => _.Title, nullable: true);
        }
    }
}
