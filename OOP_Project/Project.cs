using System;

public class Project
{
    public string ProjectId {get; set;}
    public string ProjectName{get;set;}

    public DateTime StartDate{get; set;}
    public DateTime EndDate {get; set;}

    public Employee Leader {get; set;}

    public string Description {get; set;}

    public EnumStatus Status {get; set;}

    List<Employee> List_employees {get; set;}

}