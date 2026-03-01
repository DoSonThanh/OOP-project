public abstract class AbsPerson
{
    public string id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string email { get; set; }

    protected AbsPerson(string id, string name, int age, string email)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.email = email;
    }
}