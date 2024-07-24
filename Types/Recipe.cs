using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;

namespace Odyssey.MusicMatcher;

public class Recipe
{
    [ID]
    [Key]
    public string Id { get; }

    [ReferenceResolver]
    public static Recipe GetRecipeById(string id)
    {
        return new Recipe(id);
    }

    [GraphQLDescription(
        "A list of recommended playlists for this particular recipe. Returns 1 to 3 playlists."
    )]
    public List<Playlist> RecommendedPlaylists()
    {
        return new List<Playlist>
        {
            new Playlist("1", "GraphQL Groovin'"),
            new Playlist("2", "Graph Explorer Jams"),
            new Playlist("3", "Interpretive GraphQL Dance")
        };
    }

    public Recipe(string id)
    {
        Id = id;
    }
}
