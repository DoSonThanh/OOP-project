using System;

public abstract class AbsProject
{

      public string projectId { get; set; }
      public string projectName { get; set; }
      public DateTime startDate { get; set; }
      public DateTime endDate { get; set; }
      public string description { get; set; }
      public EnumStatus status { get; set; }
      protected AbsProject(string projectId, string projectName)

    {
        this.projectId = projectId;
        this.projectName = projectName;
        this.description = string.Empty;
    }
    public override string ToString()
    {
        return $"Project: {projectName} (ID: {projectId}) - Status: {status}";
    }

    public abstract void DisplayProjectDetails();
    public abstract bool CheckProjectStatus();
}
