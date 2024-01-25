using ApolloGraphQL.HotChocolate.Federation;

namespace Odyssey.MusicMatcher;

[Key("id")]
public class Recipe
{
    [ID]
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
