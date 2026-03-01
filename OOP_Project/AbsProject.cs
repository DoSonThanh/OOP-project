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
        this.status = EnumStatus.Pending;
    }
}