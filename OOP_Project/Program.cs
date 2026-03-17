using System;

namespace Program
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var leader = new ProjectLeader("E01", "Linh", 30, "linh@example.com", "Lead Engineer");
            var member1 = new Employee("E02", "An", 26, "an@example.com", "Developer");
            var member2 = new Employee("E03", "Binh", 28, "binh@example.com", "Tester");

            var builder = new ProjectBuilder()
                .SetId("P01")
                .SetName("OOP Management")
                .SetDescription("Demo Association")
                .SetStatus(EnumStatus.OnGoing)
                .SetProjectType(EmumProjectType.SoftwareDevelopment)
                // Association: gan truc tiep Employee vao vai tro Leader cua Project.
                .SetLeader(leader);

            var service = new ProjectService();
            var project = service.CreateProject(builder);

            service.AddMember(project.projectId, member1);
            service.AddMember(project.projectId, member2);

            // Association: cap nhat lien ket Leader-Project thong qua service layer.
            service.AssignLeader(project.projectId, leader);

            var savedProject = service.GetProject(project.projectId);
            if (savedProject != null)
            {
                savedProject.DisplayProjectDetails();
            }
        }
    }
}