using System.Xml.Linq;

namespace Portfolio_site_hw.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string JobTitle { get; set; }
    public string About { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ImagePath { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<SocialMedia>? SocialMedias { get; set; }

    private static Person _instance = null;

    public Person() { }
    private Person(int id, string name, string surname, string jobTitle, string about, string email, string phone, string imagePath, List<Skill> skills, List<SocialMedia> socialMedias)
    {
        Id = id;
        Name = name;
        Surname = surname;
        JobTitle = jobTitle;
        About = about;
        Email = email;
        Phone = phone;
        ImagePath = imagePath;
        Skills = skills;
        SocialMedias = socialMedias;
    }

    public static Person GetInstance(int id, string name, string surname, string jobTitle, string about, string email, string phone, string imagePath, List<Skill> skills, List<SocialMedia> socialMedias)
    {
        if (_instance is null) _instance = new(id, name, surname, jobTitle, about, email, phone, imagePath, skills, socialMedias);
        return _instance;
    }
}