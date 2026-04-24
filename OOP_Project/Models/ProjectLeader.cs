// ProjectLeader is a specialized Employee with an overridden role.

 public class ProjectLeader : Employee
 {
      public override string role 
      { 
          get { return "Leader"; }
          set { }
      }

      public ProjectLeader(string id, string name, int age, string email, string position) 
          : base(id, name, age, email, position)
      {
      }
 }