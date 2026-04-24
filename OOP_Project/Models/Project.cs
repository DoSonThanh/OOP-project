using System;
using System.Collections.Generic;

public class Project : AbsProject
{
    // Association 1-1: Project lien ket voi mot Leader kieu Employee.
    public Employee? leader { get; private set; }

    public EmumProjectType projectType { get; set; }

    // Association 1-n: Mot Project quan ly danh sach nhieu Employee.
    private readonly List<Employee> list_employees;
    public IReadOnlyList<Employee> members
    {
        get { return list_employees.AsReadOnly(); }
    }

    public Project(string projectId, string projectName) : base(projectId, projectName)
    {
        list_employees = new List<Employee>();
        status = EnumStatus.Pending;
    }

    public void SetLeader(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        leader = employee;

        // Dam bao leader luon thuoc nhom members de quan he Association nhat quan.
        bool exists = false;
        for (int i = 0; i < list_employees.Count; i++)
        {
            if (list_employees[i].id == employee.id)
            {
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            list_employees.Add(employee);
        }
    }

    public bool AddMember(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        for (int i = 0; i < list_employees.Count; i++)
        {
            if (list_employees[i].id == employee.id)
            {
                return false;
            }
        }

        list_employees.Add(employee);
        return true;
    }

    public bool RemoveMember(string employeeId)
    {
        Employee? member = null;
        for (int i = 0; i < list_employees.Count; i++)
        {
            if (list_employees[i].id == employeeId)
            {
                member = list_employees[i];
                break;
            }
        }

        if (member == null)
        {
            return false;
        }

        list_employees.Remove(member);

        if (leader?.id == employeeId)
        {
            leader = null;
        }

        return true;
    }

    public override void DisplayProjectDetails()
    {
        var leaderName = leader == null ? "N/A" : leader.name;
        Console.WriteLine($"{ToString()}, Leader: {leaderName}, Members: {list_employees.Count}, Type: {projectType}");
    }

    public override bool CheckProjectStatus()
    {
        return status == EnumStatus.Completed;
    }
}
