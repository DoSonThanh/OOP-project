using System;

public class ProjectBuilder
{
    private string? _projectId;
    private string? _projectName;
    private string _description = string.Empty;
    private Employee? _leader;
    private EnumStatus _status = EnumStatus.Pending;
    private DateTime _startDate = DateTime.Today;
    private DateTime _endDate = DateTime.Today.AddDays(30);
    private EmumProjectType _projectType = EmumProjectType.SoftwareDevelopment;

    public ProjectBuilder(){}

    public ProjectBuilder SetId(string id)
    {
        _projectId = id;
        return this;
    }

    public ProjectBuilder SetName(string name)
    {
        _projectName = name;
        return this;
    }

    public ProjectBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    // Association: Builder nhan tham chieu Employee de gan quan he Leader cho Project.
    public ProjectBuilder SetLeader(Employee employee)
    {
        _leader = employee;
        return this;
    }

    public ProjectBuilder SetStatus(EnumStatus status)
    {
        _status = status;
        return this;
    }

    public ProjectBuilder SetStartDate(DateTime startDate)
    {
        _startDate = startDate;
        return this;
    }

    public ProjectBuilder SetEndDate(DateTime endDate)
    {
        _endDate = endDate;
        return this;
    }

    public ProjectBuilder SetProjectType(EmumProjectType projectType)
    {
        _projectType = projectType;
        return this;
    }

    public Project Build()
    {
        var id = string.IsNullOrWhiteSpace(_projectId) ? Guid.NewGuid().ToString("N") : _projectId;
        var name = string.IsNullOrWhiteSpace(_projectName) ? "Untitled Project" : _projectName;

        var newproject = new Project(id, name)
        {
            description = _description,
            status = _status,
            startDate = _startDate,
            endDate = _endDate,
            projectType = _projectType
        };

        if (_leader != null)
        {
            newproject.SetLeader(_leader);
        }

        return newproject;
    }

}