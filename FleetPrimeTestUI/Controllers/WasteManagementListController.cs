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
    public class WasteManagementEventListController : Controller
    {
        private readonly WasteManagementDbContext _dbContext;

        public WasteManagementEventListController(WasteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Details(string transactionId)
        {
            var result = _dbContext.WasteManagementEvents
                .Where(o => o.TransactionId == transactionId)
                .Include(o => o.Videos)
                .Include(o => o.Images)
                .Include(o => o.ExceptionDetails)
                .FirstOrDefault();
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

            var wasteManagementEvents = _dbContext.WasteManagementEvents.Select(o => o);
                           

            if (!String.IsNullOrEmpty(searchString))
            {
                wasteManagementEvents = wasteManagementEvents.Where(s => s.TransactionId.Contains(searchString));
            }

            switch (sortOrder)
            {

                case "DateCreated":
                    wasteManagementEvents = wasteManagementEvents.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    wasteManagementEvents = wasteManagementEvents.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    wasteManagementEvents = wasteManagementEvents.OrderBy(s => s.DateCreated);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<WasteManagementEventEntity>.CreateAsync(wasteManagementEvents.AsNoTracking(), page ?? 1, pageSize));
        }
    }
}