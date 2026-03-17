using System;

public class ProjectService : IProjectService // (Giả sử bạn đã sửa tên interface cho đúng chính tả)
{
    // Thể hiện Aggregation: Service "chứa" (giữ 1 tham chiếu tới) DataStorage
    private DataStorage _storage;

    // Constructor nhận DataStorage từ bên ngoài truyền vào (Dependency Injection)
    public ProjectService(DataStorage storage)
    {
        this._storage = storage;
    }

    public void CreateProject(ProjectBuilder builder)
    {

        Console.WriteLine("Đã thêm project mới vào DataStorage.");
    }

    public void UpdateProject()
    {
        // Logic update
    }

    public void DeleteProject()
    {
        // Logic delete
    }

    public void GetProject()
    {
        // Logic get
    }
}
using System.Collections.Generic;

public class ProjectService : IProjectService
{
    // Workaround sau khi rollback SystemContext: service tu quan ly storage tam.
    private static readonly List<Project> _projects = new List<Project>();
    private static Project? _currentProject;

    public ProjectService()
    {
    }

    private Project? FindProjectInternal(string projectId)
    {
        for (int i = 0; i < _projects.Count; i++)
        {
            if (_projects[i].projectId == projectId)
            {
                return _projects[i];
            }
        }

        return null;
    }

    public Project CreateProject(ProjectBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var project = builder.Build();
        bool exists = false;
        for (int i = 0; i < _projects.Count; i++)
        {
            if (_projects[i].projectId == project.projectId)
            {
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            _projects.Add(project);
        }

        _currentProject = project;
        return project;
    }

    public bool UpdateProject(Project project)
    {
        if (project == null)
        {
            throw new ArgumentNullException(nameof(project));
        }

        var existing = FindProjectInternal(project.projectId);
        if (existing == null)
        {
            return false;
        }

        existing.projectName = project.projectName;
        existing.description = project.description;
        existing.startDate = project.startDate;
        existing.endDate = project.endDate;
        existing.status = project.status;
        existing.projectType = project.projectType;

        if (project.leader != null)
        {
            existing.SetLeader(project.leader);
        }

        return true;
    }

    public bool DeleteProject(string projectId)
    {
        for (int i = 0; i < _projects.Count; i++)
        {
            if (_projects[i].projectId == projectId)
            {
                _projects.RemoveAt(i);
                if (_currentProject != null && _currentProject.projectId == projectId)
                {
                    _currentProject = null;
                }

                return true;
            }
        }

        return false;
    }

    public Project? GetProject(string projectId)
    {
        return FindProjectInternal(projectId);
    }

    public bool AssignLeader(string projectId, Employee employee)
    {
        var project = FindProjectInternal(projectId);
        if (project == null)
        {
            return false;
        }

        // Association: gan Employee lam Leader cho Project.
        project.SetLeader(employee);
        return true;
    }

    public bool AddMember(string projectId, Employee employee)
    {
        var project = FindProjectInternal(projectId);
        if (project == null)
        {
            return false;
        }

        // Association: them Employee vao danh sach thanh vien cua Project.
        return project.AddMember(employee);
    }

    public bool RemoveMember(string projectId, string employeeId)
    {
        var project = FindProjectInternal(projectId);
        if (project == null)
        {
            return false;
        }

        // Association: go bo lien ket giua Employee va Project.
        return project.RemoveMember(employeeId);
    }
}
