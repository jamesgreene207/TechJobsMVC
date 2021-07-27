using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        private static List<Job> jobs;
    
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        
        public IActionResult Results(string searchType, string searchTerm)
        {

            if (searchType == null)
            {
                searchType = "all";
                jobs = JobData.FindAll();
            }
            if (searchTerm == null)
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.searchtype = searchType;
            }
            
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            
            return View("~/Views/Search/Index.cshtml");

            
        }
    }
}
