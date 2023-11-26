using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Controllers;

[Route("api")]
[ApiController]
public class GitHubApiController : ControllerBase
{
    private readonly IGitHubService _gitHubService;

    public GitHubApiController(IGitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    [HttpGet("user")]
    public ActionResult<GitHubUser> GetUser()
    {
        GitHubUser currentUser = _gitHubService.GetUser();
        return Ok(currentUser);
    }

    [HttpGet("repository")]
    public ActionResult<GitHubRepository> GetRepo(string owner, string repo)
    {
        GitHubRepository currentRepo = _gitHubService.GetRepository(owner, repo);
        return Ok(currentRepo);
    }

    [HttpGet("repositories")]
    public ActionResult<IEnumerable<GitHubRepository>> GetAllRepositories()
    {
        return Ok(_gitHubService.GetRepositories());
    }

    [HttpGet("branches")]
    public ActionResult<IEnumerable<GitHubBranch>> GetAllBranches(string owner, string repo)
    {
        return Ok(_gitHubService.GetBranches(owner, repo));
    }

    [HttpGet("commits")]
    public ActionResult<IEnumerable<GitHubCommit>> GetAllCommits(string owner, string repo)
    {
        return Ok(_gitHubService.GetCommits(owner, repo));
    }
}