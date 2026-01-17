using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio_site_hw.Data;
using Portfolio_site_hw.Models;
using Portfolio_site_hw.Services;

namespace Portfolio_site_hw.Controllers;

public class PeopleController : Controller
{
    private readonly PortfolioContext _context;
    private readonly EmailService _emailService;

    public PeopleController(PortfolioContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }


    public async Task<IActionResult> Index() => View(await _context.Persons.ToListAsync());

    public async Task<IActionResult> About() => View(await _context.Persons.ToListAsync());

    public async Task<IActionResult> Skills() {
        var people = await _context.Persons
            .Include(p => p.Skills)
            .ToListAsync();

        return View(people);
    }

    public async Task<IActionResult> Contact() => View(await _context.Persons.Include(p => p.SocialMedias).ToListAsync());
    

    public async Task<IActionResult> Hire() => View(await _context.Persons.ToListAsync());

    [HttpPost]
    public IActionResult SubmitHire(HiringPerson person)
    {
        if (!ModelState.IsValid) return RedirectToAction("Hire");

        _emailService.SendHireMeEmails(person);
        return RedirectToAction("Index");
    }
}
