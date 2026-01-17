namespace Portfolio_site_hw.Models;

public class SocialMedia
{
    public int Id { get; set; }
    public string Platform { get; set; }
    public string PlatformIconRoot { get; set; }
    public string Url { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
