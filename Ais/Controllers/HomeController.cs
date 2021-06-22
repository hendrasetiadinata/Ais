using Ais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ais.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReporting _reporting;

        public HomeController(ILogger<HomeController> logger, IReporting reporting)
        {
            _logger = logger;
            _reporting = reporting;
        }

        public IActionResult Index()
        {
            var model = new ResultModel();
            DataTable data = _reporting.GenerateData();
            model.Reports = _reporting.ShowReport(data);

            var valueToBeSort = new int[] { 1, -1, 3, -4, 5, -2, 7, 4, 2 };
            model.SortAndPositiveData =  string.Join(",", _reporting.SortAndGetPositiveNumber(valueToBeSort));

            return View(model);
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

    }
}
