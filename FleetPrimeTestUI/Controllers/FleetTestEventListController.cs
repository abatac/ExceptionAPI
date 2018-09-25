using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ExceptionAPI.Data;
using System.Threading.Tasks;
using System;
using FleetPrimeTestUI.Util;

namespace FleetPrimeTestUI.Controllers
{
    public class FleetTestEventListController : Controller
    {
        private readonly WasteManagementDbContext _dbContext;

        public FleetTestEventListController(WasteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Details(string transactionId)
        {
            var result = _dbContext.EventLogs.Where(o => o.TransactionId == transactionId).FirstOrDefault();
            return View(result);
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "DateCreated" ? "date_desc" : "DateCreated";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
           
            ViewData["CurrentFilter"] = searchString;

            var eventLogs = from s in _dbContext.EventLogs
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                eventLogs = eventLogs.Where(s => s.TransactionId.Contains(searchString));
            }

            switch (sortOrder)
            {
             
                case "DateCreated":
                    eventLogs = eventLogs.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    eventLogs = eventLogs.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    eventLogs = eventLogs.OrderBy(s => s.DateCreated);
                    break;
            }

            var results = from el in eventLogs
                          join wme in _dbContext.WasteManagementEvents
                            on el.TransactionId equals wme.TransactionId into joinList
                          from jl in joinList.DefaultIfEmpty()
                          select new Tuple<FleetPrimeTestEvent, WasteManagementEventEntity>(el, jl);


            int pageSize = 20;
            return View(await PaginatedList<Tuple<FleetPrimeTestEvent, WasteManagementEventEntity>>.CreateAsync(results.AsNoTracking(), page ?? 1, pageSize));
          
        }
    }
}