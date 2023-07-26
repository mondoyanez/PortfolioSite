using Portfolio.Models.DTO;
using System.Text.Json;

namespace Portfolio.Models;

public class GitHubRepository
{
   public string Name { get; set; }
   public string Owner { get; set; }
   public string HtmlURL { get; set; }
   public string FullName { get; set; }
   public string OwnerAvatarURL { get; set; }
   public string LastUpdated { get; set; }

    public void FromJSON(string jsonResponse, out GitHubRepository gitRepository)
    {
        try
        {
            var deserializedJson = JsonSerializer.Deserialize<GitRepo>(jsonResponse);
            GitHubRepository newRepo = new GitHubRepository()
            {
                Name = deserializedJson?.name,
                Owner = deserializedJson?.owner?.login,
                HtmlURL = deserializedJson?.html_url,
                FullName = deserializedJson?.full_name,
                OwnerAvatarURL = deserializedJson?.owner?.avatar_url,
                LastUpdated = (DateTime.Now - deserializedJson?.updated_at)?.Days.ToString()
            };
            gitRepository = newRepo;
        }
        catch (JsonException)
        {

            throw new JsonException("Did not receive JSON data");
        }
    }
}