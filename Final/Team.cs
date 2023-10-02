public class Team {
    public Team(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public string Name { get; set; }
}
