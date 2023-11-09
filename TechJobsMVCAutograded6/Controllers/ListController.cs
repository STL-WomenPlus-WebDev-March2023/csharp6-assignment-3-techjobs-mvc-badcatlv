using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVCAutograded6.Controllers;

public class ListController : Controller
{
    internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"employer", "Employer"},
            {"location", "Location"},
            {"positionType", "Position Type"},
            {"coreCompetency", "Skill"}
        };
    internal static Dictionary<string, List<JobField>> TableChoices = new Dictionary<string, List<JobField>>()
        {
            //{"all", JobData.FindAll() },
            {"employer", JobData.GetAllEmployers()},
            {"location", JobData.GetAllLocations()},
            {"positionType", JobData.GetAllPositionTypes()},
            {"coreCompetency", JobData.GetAllCoreCompetencies()}
        };

    public IActionResult Index()
    {
        ViewBag.columns = ColumnChoices;
        ViewBag.tableChoices = TableChoices;
        ViewBag.employers = JobData.GetAllEmployers();
        ViewBag.locations = JobData.GetAllLocations();
        ViewBag.positionTypes = JobData.GetAllPositionTypes();
        ViewBag.skills = JobData.GetAllCoreCompetencies();
        ViewBag.jobs = JobData.FindAll();

        return View();
    }

    // TODO #2 - Complete the Jobs action method
    public IActionResult Jobs(string column, string value)
    {
        List<Job> jobs = new List<Job>();
        if (column == "All")
        {
            jobs = JobData.FindAll();           
        }
        else
        {
            jobs = JobData.FindByColumnAndValue(column, value);
        }
        ViewBag.title = value;
        ViewBag.jobs = jobs;
        return View();
        
    }
}

