using System.Diagnostics;
using GreetMeTool.BLL;
using GreetMeTool.BLL.Services;
using GreetMeTool.Domain.AppSettings;
using GreetMeTool.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using PrivateFlightGreetMeTool.Models;
using System.Linq;
using System.Collections.Generic;

namespace PrivateFlightGreetMeTool.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IServices<AdminService> _AdminService;
    private readonly AppSettings _appsetting;
    public HomeController(ILogger<HomeController> logger, AppSettings appSettings, IServices<AdminService> adminService)
    {
        _logger = logger;
        _appsetting = appSettings;
        _AdminService = adminService;
    }

    public async Task<IActionResult> Index(string CountryCode="")
    {

        return View(await _AdminService.Service.GetGreetings(CountryCode, DateTimeOffset.UtcNow));
    }


    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit(Greeting greeting)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EditGreeting(Greeting greeting)
    {
        greeting.StartDate = ConvertDToffset(greeting.StartDate.ToString());
        greeting.EndDate = ConvertDToffset(greeting.MessageType=="A" ? "9999-12-31T00:00:00Z" : greeting.EndDate.ToString());
        await _AdminService.Service.EditGreetings(greeting);
        return View("Index",await _AdminService.Service.GetGreetings("", DateTimeOffset.UtcNow));
      
    }
        
    [HttpPost]
    public async Task<IActionResult> index(Greeting greeting)
    {

        greeting.StartDate = ConvertDToffset(greeting.StartDate.ToString());
        greeting.EndDate = ConvertDToffset(greeting.MessageType == "A" ? "9999-12-31T00:00:00Z" : greeting.EndDate.ToString());
        await _AdminService.Service.CreateGreetings(greeting);
        return View(await _AdminService.Service.GetGreetings("", DateTimeOffset.UtcNow));

    }


    public async Task<IActionResult> Delete(long id)
    {
        await _AdminService.Service.DeleteGreetings(id);
        return View("Index", await _AdminService.Service.GetGreetings("", DateTimeOffset.UtcNow));

    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private DateTimeOffset ConvertDToffset(string sourceDateString)
    {
         
        TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); //this timezone has an offset of +01:00:00 on this date

        DateTimeOffset utc = DateTimeOffset.Parse(sourceDateString);
        DateTimeOffset result = TimeZoneInfo.ConvertTime(utc, timezone);
        return result;
    }
    private string GetGreetMe(string countryCode,DateTimeOffset departureDate)
    {
       

        return "Manoj";
    }
}

