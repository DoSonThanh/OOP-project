public class SystemContext //singleton
{
    protected SystemContext()
    {
        
    }
    public static SystemContext Instance { get; } = new SystemContext();

    public SystemContext GetContext()
    {
        if (Instance == null)
        {
            return new SystemContext();
        }
        else { return Instance; }

    }
    Project currentProject { get; set; }
    List<Project> ProjectList { get; set; }
}