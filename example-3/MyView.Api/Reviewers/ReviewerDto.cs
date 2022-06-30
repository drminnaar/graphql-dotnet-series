using HotChocolate;

namespace MyView.Api.Reviewers;

[GraphQLDescription("Represents basic reviewer information")]
[GraphQLName("Reviewer")]
public sealed record ReviewerDto
{
   [GraphQLDescription("An identifier that uniquely identifies a reviewer")]
   public string ReviewerId { get; init; } = string.Empty;

   [GraphQLDescription("The full name of a reviewer")]
   public string Name { get; init; } = string.Empty;

   [GraphQLDescription("A globally unique email address")]
   public string Email { get; init; } = string.Empty;

   [GraphQLDescription("A globally unique user name")]
   public string Username { get; init; } = string.Empty;

   [GraphQLDescription("A link to a reviewers picture")]
   public string PictureUrl { get; init; } = string.Empty;
}
