using System;

public class Project : AbsProject
{
    public Employee leader {get; set;}

    public EmumProjectType projectType {get; set;}
    List<Employee> list_employees {get; set;}

    public Project(string projectId, string projectName) : base(projectId, projectName)
    {
        list_employees = new List<Employee>();
    }

    public override void DisplayProjectDetails()
    {
        throw new NotImplementedException(); // Cứ để đây, sau này code sau
    }

    public override bool CheckProjectStatus()
    {
        throw new NotImplementedException(); // Cứ để đây, sau này code sau
    }
}
