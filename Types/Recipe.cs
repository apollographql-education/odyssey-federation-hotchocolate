using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using SpotifyWeb;

namespace Odyssey.MusicMatcher;

public class Recipe
{
    [ID]
    [Key]
    public string Id { get; }

    [External]
    public string? Name { get; }

    [ReferenceResolver]
    public static Recipe GetRecipeById(string id, string? name)
    {
        return new Recipe(id, name);
    }

    [GraphQLDescription(
        "A list of recommended playlists for this particular recipe. Returns 1 to 3 playlists."
    )]
    [Requires("name")]
    public async Task<List<Playlist>> RecommendedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.SearchAsync(
            this.Name,
            new List<SearchType> { SearchType.Playlist },
            3,
            0,
            null
        );

        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }

    public Recipe(string id, string? name)
    {
        Id = id;
        if (name != null)
        {
            Name = name;
        }
    }
}
