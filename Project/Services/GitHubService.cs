using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Portfolio.Models;
using Portfolio.Models.DTO;

namespace Portfolio.Services;

public class GitHubService: IGitHubService
{
    private string _userName;
    private string _token;
    // This is a singleton, we are only supposed to have one per application
    // Better to use IHttpClientFactory with dependency injection but that's too much for this simple HW
    public static readonly HttpClient _httpClient = new HttpClient();

    public GitHubService(string userName, string token)
    {
        _userName = userName;
        _token = token;
    }

    public string GetJsonStringFromEndpoint(string token, string uri, string username)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
        {
            Headers =
                {
                    { "Accept", "application/json" },
                    { "Authorization", "token " + token},
                    { "User-Agent", username }
                }
        };
        HttpResponseMessage response = _httpClient.Send(httpRequestMessage);
        // This is only a minimal version; make sure to cover all your bases here
        if (response.IsSuccessStatusCode)
        {
            // Note there is only an async version of this so to avoid forcing you to use all async I'm waiting for the result manually
            string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return responseText;
        }
        else
        {
            // What to do if failure? 401? Should throw and catch specific exceptions that explain what happened
            throw new NullReferenceException();
        }
    }

    public void SetCredentials(string username, string token)
    {
        _userName = username;
        _token = token;
    }

    public GitHubUser GetUser()
    {
        string source = "https://api.github.com/user";
        string jsonResponse = GetJsonStringFromEndpoint(_token, source, _userName) ?? "";

        GitHubUser gitHubUser = new();
        gitHubUser?.FromJSON(jsonResponse, out gitHubUser);

        if (gitHubUser != null)
        {
            return gitHubUser;
        }

        throw new NullReferenceException("Empty");
    }

    public IEnumerable<GitHubRepository> GetRepositories()
    {
        string source = "https://api.github.com/user/repos";
        string jsonResponse = GetJsonStringFromEndpoint(_token, source, _userName);

        List<GitRepo> gitRepos = null;

        try
        {
            // https://makolyte.com/csharp-deserialize-a-json-array-to-a-list/#:~:text=When%20you%E2%80%99re%20working%20with%20a%20JSON%20array%2C%20you,You%20can%20use%20this%20list%20object%20like%20usual.
            gitRepos = JsonSerializer.Deserialize<List<GitRepo>>(jsonResponse);
        }
        catch (JsonException)
        {
            throw new JsonException("Something went wrong");
        }

        if (gitRepos != null)
        {
            return gitRepos.Select(r => new GitHubRepository()
            {
                Name = r?.name,
                Owner = r?.owner?.login,
                HtmlURL = r?.html_url,
                FullName = r?.full_name,
                OwnerAvatarURL = r?.owner?.avatar_url,
                LastUpdated = r?.updated_at.ToString()
            });
        }

        return Enumerable.Empty<GitHubRepository>();
    }

    public GitHubRepository GetRepository(string owner, string repositoryName)
    {
        string source = $"https://api.github.com/repos/{owner}/{repositoryName}";
        string jsonResponse = GetJsonStringFromEndpoint(_token, source, _userName) ?? "";

        GitHubRepository gitHubRepository = new();
        gitHubRepository?.FromJSON(jsonResponse, out gitHubRepository);

        if (gitHubRepository != null)
        {
            return gitHubRepository;
        }

        throw new NullReferenceException("Repository does not exist");
    }

    public IEnumerable<GitHubCommit> GetCommits(string owner, string repositoryName)
    {
        string source = $"https://api.github.com/repos/{owner}/{repositoryName}/commits";
        string jsonResponse = GetJsonStringFromEndpoint(_token, source, _userName) ?? "";

        List<GitCommit> gitCommits = null;

        try
        {
            gitCommits = JsonSerializer.Deserialize<List<GitCommit>>(jsonResponse);
        }
        catch (JsonException)
        {
            throw new JsonException("Something went wrong");
        }

        if (gitCommits != null)
        {
            return gitCommits.Select(c => new GitHubCommit()
            {
                Sha = c?.sha,
                Commiter = c?.commit?.committer?.name,
                WhenCommited = c?.commit?.committer?.date,
                CommitMessage = c?.commit?.message,
                HtmlURL = c?.html_url
            });
        }

        return Enumerable.Empty<GitHubCommit>();
    }

    public IEnumerable<GitHubBranch> GetBranches(string owner, string repositoryName)
    {
        string source = $"https://api.github.com/repos/{owner}/{repositoryName}/branches";
        string jsonResponse = GetJsonStringFromEndpoint(_token, source, _userName) ?? "";

        List<GitBranch> gitBranches = null;

        try
        {
            gitBranches = JsonSerializer.Deserialize<List<GitBranch>>(jsonResponse);
        }
        catch (JsonException)
        {
            throw new JsonException("Something went wrong");
        }

        if (gitBranches != null)
        {
            return gitBranches.Select(b => new GitHubBranch()
            {
                Name = b?.name
            });
        }

        return Enumerable.Empty<GitHubBranch>();
    }
}