namespace Portfolio.Models;

public class GitHubCommit
{
    public string Sha { get; set; }
    public string Commiter { get; set; }
    public DateTime? WhenCommited { get; set; }
    public string CommitMessage { get; set; }
    public string HtmlURL { get; set; }
}