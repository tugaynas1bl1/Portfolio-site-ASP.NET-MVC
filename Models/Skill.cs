namespace Portfolio_site_hw.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProficiencyPercentage { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }

    public Skill(int id, string name, string description, int proficiencyPercentage)
    {
        Id = id;
        Name = name;
        Description = description;
        ProficiencyPercentage = proficiencyPercentage;
    }

}
