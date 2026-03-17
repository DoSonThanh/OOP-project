using System.Collections.Generic;

// Employee inherits common person attributes from AbsPerson and extends them with job-specific data.

public class Employee : AbsPerson
{
     public string position { get; set; }
     public virtual string role { get; set; }
     public List<string> infoList { get; set; }

     public Employee(string id, string name, int age, string email, string position) 
         : base(id, name, age, email)
     {
         this.position = position;
         this.role = "Employee";
         this.infoList = new List<string>(); 
     }

     public override string ToString()
     {
         return $"{base.ToString()}, Role: {role}, Position: {position}";
     }

     public override void DoWork()
     {
         throw new NotImplementedException(); // Cứ để đây, sau này code sau
     }

     public override double CalculateSalary()
     {
         throw new NotImplementedException(); // Cứ để đây, sau này code sau
     }
}