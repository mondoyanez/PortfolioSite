using System.Text.Json;
using Portfolio.Models.DTO;

namespace Portfolio.Models;

public class GitHubUser
{
    public string UserName { get; set; }
    public string AvatarURL { get; set; }
    public string HtmlURL { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Location { get; set; }
    public string Email { get; set; }

    public void FromJSON(string jsonResponse, out GitHubUser gitUser)
    {
        try
        {
            var deserializedJson = JsonSerializer.Deserialize<GitUser>(jsonResponse);
            GitHubUser newUser = new GitHubUser()
            {
                UserName = deserializedJson?.login,
                AvatarURL = deserializedJson?.avatar_url,
                HtmlURL = deserializedJson?.html_url,
                Name = deserializedJson?.name,
                Company = deserializedJson?.company,
                Location = deserializedJson?.location,
                Email = deserializedJson?.email
            };
            gitUser = newUser;
        }
        catch (JsonException)
        {
            
            throw new JsonException("Did not receive JSON data");
        }
    }
}