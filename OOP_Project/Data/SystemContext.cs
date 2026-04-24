public class SystemContext //singleton
{
      Project currentProject { get; set; }
      List<Project> ProjectList { get; set; }
          protected SystemContext()
          {
            ProjectList = new List<Project>
            {
                  new Project("P1", "Project A"),
                  new Project("P2", "Project B")
            };
      
            currentProject = ProjectList[0];
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
   
}
