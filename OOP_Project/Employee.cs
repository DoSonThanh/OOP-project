
using System.Collections.Generic;

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
        return "ID: " + this.id + ", Name: " + this.name + ", Role: " + this.role + ", Position: " + this.position;
    }
}