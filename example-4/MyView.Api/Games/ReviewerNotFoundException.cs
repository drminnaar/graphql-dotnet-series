using System;
using System.Runtime.Serialization;

namespace MyView.Api.Games;

[Serializable]
public class ReviewerNotFoundException : Exception
{
   public ReviewerNotFoundException() { }
   public ReviewerNotFoundException(string message) : base(message) { }
   public ReviewerNotFoundException(string message, Exception inner) : base(message, inner) { }
   protected ReviewerNotFoundException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }

   public Guid ReviewerId { get; set; }

   public static ReviewerNotFoundException WithReviewerId(Guid reviewerId)
      => new ReviewerNotFoundException { ReviewerId = reviewerId };
}
