using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private static List<Dictionary<string, string>> jobResults = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            if (jobResults.Count > 0)
            {
                ViewBag.jobs = jobResults;
            }
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
            
        }
        public IActionResult Results(string searchType, string searchTerm)
        {
            jobResults.Clear();
            jobResults = JobData.FindByColumnAndValue(searchType, searchTerm);
            if (jobResults.Count == 0)
            {
                Dictionary<string, string> resultToAdd = new Dictionary<string, string>();
                resultToAdd.Add("noResult", searchTerm);
                jobResults.Add(resultToAdd);

            }
            return Redirect("Index");
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
