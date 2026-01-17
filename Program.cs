using Humanizer;
using Microsoft.Build.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TextTemplating;
using Newtonsoft.Json.Linq;
using Portfolio_site_hw.Data;
using Portfolio_site_hw.Models;
using Portfolio_site_hw.Services;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PortfolioContext>(op =>
    op.UseInMemoryDatabase("portfolioDb"));
builder.Services.AddScoped<EmailService>();

List<Skill> skills = new List<Skill>
{
    new Skill(
        1,
        "C#",
        "Strong proficiency in C# with solid experience in object-oriented programming, asynchronous programming, and .NET ecosystem development. Skilled in building structured applications using ASP.NET Core, MVC architecture, Entity Framework, and Windows-based applications. Focused on clean architecture, maintainability, and performance.",
        90
    ),

    new Skill(
        2,
        "C++",
        "Advanced understanding of C++ with hands-on experience in object-oriented programming, memory management, pointers, references, operator overloading, and file handling. Comfortable with designing class-based systems and implementing efficient algorithms in console and system-level applications.",
        80
    ),

    new Skill(
        3,
        "Python",
        "Working knowledge of Python for backend development, scripting, and data handling. Familiar with Python syntax, core libraries, and writing clean, readable code. Used primarily for backend logic, automation, and web development support.",
        60
    ),

    new Skill(
        4,
        "JavaScript",
        "Expert-level proficiency in JavaScript with deep understanding of core language concepts including functions, closures, objects, DOM manipulation, events, asynchronous programming, and modern ES6+ features. Experienced in building dynamic, interactive, and user-focused web interfaces.",
        100
    ),

    new Skill(
        5,
        "Django",
        "Strong experience with Django framework for building scalable and secure web applications. Proficient in MVT architecture, template rendering, URL routing, forms, authentication systems, and database integration. Focused on rapid development and clean backend structure.",
        75
    ),

    new Skill(
        6,
        "Microsoft Office",
        "High proficiency in Microsoft Office tools including Word, Excel, PowerPoint, and related applications. Experienced in technical documentation, data organization, presentations, and professional reporting.",
        80
    ),

    new Skill(
        7,
        "Adobe Photoshop & Illustrator",
        "Advanced skills in graphic design and visual content creation using Adobe Photoshop and Illustrator. Experienced in UI assets, branding materials, image editing, vector design, and preparing visuals for web and digital platforms.",
        90
    ),

    new Skill(
        8,
        "Figma",
        "Expert-level proficiency in Figma for UI/UX design, wireframing, prototyping, and collaborative design workflows. Skilled in creating responsive layouts, design systems, and developer-ready interface specifications.",
        100
    ),

    new Skill(
        9,
        "Blender",
        "Strong experience in Blender for 3D modeling, texturing, lighting, and rendering. Capable of producing optimized 3D assets for visualization, presentations, and digital products.",
        75
    )
};


List<SocialMedia> socialMedias = new List<SocialMedia>
{
    new SocialMedia
    {
        Id = 1,
        Platform = "Facebook",
        PlatformIconRoot = "fab fa-facebook-f",
        Url = "https://www.facebook.com/tuqay.nasibli",
        PersonId = 1
    },

    new SocialMedia
    {
        Id = 2,
        Platform = "Instagram",
        PlatformIconRoot = "fab fa-instagram",
        Url = "",
        PersonId = 1
    },

    new SocialMedia
    {
        Id = 3,
        Platform = "GitHub",
        PlatformIconRoot = "fab fa-github",
        Url = "https://github.com/tugaynas1bl1",
        PersonId = 1
    },

    new SocialMedia
    {
        Id = 4,
        Platform = "TikTok",
        PlatformIconRoot = "fab fa-tiktok",
        Url = "https://www.tiktok.com/elmejes.ty",
        PersonId = 1
    }
};

Person person = new Person();

person = Person.GetInstance(
    1,
    "Tuqay",
    "Nasibli",
    "Fullstack Programmer",
    @"My name is Tugay Nasibli, and I am a Fullstack Programmer with a strong academic background and a passion for building practical, impactful software solutions.

I completed my secondary education at the 132–134 Education Complex, where I developed an early interest in technology and logical problem - solving.I later graduated with a high - grade Bachelor’s degree from Azerbaijan Technical University, where I strengthened my foundations in computer science, programming, and engineering thinking.

As a developer, I work across both frontend and backend technologies, focusing on creating scalable, user - oriented, and well - structured applications.I have hands - on experience with modern web development concepts, object - oriented programming, databases, and software architecture.I value clean code, maintainability, and understanding why a solution works—not just how.

Beyond technical skills, I am highly analytical and constantly question assumptions to improve ideas and implementations.I enjoy turning complex problems into clear, efficient solutions and continuously learning new technologies to stay up to date in the fast - evolving tech world.

My goal is to grow as a software engineer by contributing to meaningful projects, improving system quality, and building products that solve real - world problems.",
    "grey.samsung.j7@gmail.com",
    "+994 51 303 48 48",
    @"images/me_on_wedding_2-removebg-preview.png",
    skills,
    socialMedias);



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PortfolioContext>();

 
    if (!context.Persons.Any())
    {
        context.Persons.Add(person);

        context.Skills.AddRange(skills);
        context.SocialMedias.AddRange(socialMedias);

        context.SaveChanges();
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=People}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
