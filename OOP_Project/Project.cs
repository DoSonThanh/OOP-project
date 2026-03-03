using System;

public class Project : AbsProject
{
    public Employee leader {get; set;}

    public EmumProjectType projectType {get; set;}
    List<Employee> list_employees {get; set;}

}
