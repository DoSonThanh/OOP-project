public interface IProjectService
{
    public Project CreateProject(ProjectBuilder builder);
    public bool UpdateProject(Project project);
    public bool DeleteProject(string projectId);
    public Project? GetProject(string projectId);

    public bool AssignLeader(string projectId, Employee employee);
    public bool AddMember(string projectId, Employee employee);
    public bool RemoveMember(string projectId, string employeeId);
}