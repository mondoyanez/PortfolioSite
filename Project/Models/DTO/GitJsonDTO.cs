namespace Portfolio.Models.DTO;

public class GitUser
{
    public string login { get; set; }
    public string avatar_url { get; set; }
    public string html_url { get; set; }
    public string name { get; set; }
    public string company { get; set; }
    public string location { get; set; }
    public string email { get; set; }
}

public class GitRepo
{
    public string name { get; set; }
    public Owner owner { get; set; }
    public string html_url { get; set; }
    public string full_name { get; set; }
    public DateTime? updated_at { get; set; }
}

public class Owner
{
    public string login { get; set; }
    public string avatar_url { get; set; }
}

public class GitBranch
{
    public string name { get; set; }
}

public class GitCommit
{
    public string sha { get; set; }
    public Commit commit { get; set; }
    public string html_url { get; set; }
}

public class Commit
{
    public Commiter committer { get; set; }
    public string message { get; set; }
}

public class Commiter
{
    public string name { get; set; }
    public DateTime? date { get; set; }
}